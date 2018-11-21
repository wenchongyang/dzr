using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ERP.Data
{
    public class StockDal
    {

        public class StockException : Exception
        {
            public StockException(string msg) : base(msg) { 
                
            }
        }
        public enum Type
        {
            IN, Out, Switch
        }
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(StockDal));
        public enum OutType
        {
            Stock,StoreStock
        }
        public enum OutTypeName
        {
            客户自提, 转移到仓库
        }
        public enum OutTypeName2
        {
            总仓, 门店
        }

        public void OutStock(int sales_id,int sales_detail_id, DateTime time,int product_id, int count, string remarks, string bill_id,OutType type)
        {
            DataSet ds = DataUtil.ExecuteDataSet("select product_id ,product_name ,color,dimensions,count ,'销售出库' as remarks from salesdetail where sales_id =" + sales_id + " and product_id = " + product_id + ";"
                + "select IFNULL(sum(abs(count)),0) count from  stockdetail where type = 1 and ref_id = " + sales_detail_id + " and product_id =" + product_id + ";"
                + "select count(1) from salesdetail where sales_id =" + sales_id + " and (is_out_all = 0 or is_out_all is null)");
            DataRow dr = ds.Tables[0].Rows[0];
            int all_count = Convert.ToInt32(dr["count"]);
            int out_count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            int last_product = Convert.ToInt32(ds.Tables[2].Rows[0][0]);
            if (count + out_count > all_count) {
                throw new Exception("订单中该商品没有那么多需要出库了。");
            }
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                
                using (DbTransaction tran = conn.BeginTransaction()) {
                    try
                    {
                        if (type == OutType.Stock)
                        {
                            Stock(Convert.ToString(dr["product_name"]), Convert.ToString(dr["color"]), Convert.ToString(dr["dimensions"]),
                                      Convert.ToInt32(dr["product_id"]), count, time, remarks, sales_detail_id, bill_id, Type.Out, type, conn, tran);
                        }
                        else {
                            StockWithStore(Convert.ToString(dr["product_name"]), Convert.ToString(dr["color"]), Convert.ToString(dr["dimensions"]),
                                      Convert.ToInt32(dr["product_id"]), count, time, remarks, sales_detail_id, bill_id, conn, tran);
                        }
                        DataUtil.ExecuteScalar("update sales set delivery_date = '" + time + "' where id = " + sales_id + " ", conn, tran);

                        if (count + out_count == all_count )
                        {
                            DataUtil.ExecuteScalar("update salesdetail set is_out_all = 1 where id = " + sales_detail_id + " ", conn, tran);
                            if (last_product <= 1)
                            {
                                DataUtil.ExecuteScalar("update sales set status = 1 where id = " + sales_id, conn, tran);
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        log.Error("出库错误", e);
                        tran.Rollback();
                        throw new Exception("出库错误:" + e.Message);
                    }
                }
            }
        }
        //出库门店库存
        private void StockWithStore(string product_name,
            string color,
            string dimensions,
            int product_id,
            int count, DateTime complete_time,
           string remarks, int sales_detail_id, string bill_id, DbConnection conn, DbTransaction tran)
        {
            //只需加回可用库存
            DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count + " + count + " where product_id = " + product_id);
            DataUtil.Add("stockdetail", new DictionaryEntry[] { 
                        new DictionaryEntry("color",color),
                        new DictionaryEntry("product_name",product_name),
                        new DictionaryEntry("dimensions",dimensions),
                        new DictionaryEntry("product_id",product_id),
                        new DictionaryEntry("count",count),
                        new DictionaryEntry("create_time",DateTime.Now),
                        new DictionaryEntry("type",(int)Type.Out),
                        new DictionaryEntry("is_store_out",1),
                        new DictionaryEntry("complete_time",complete_time),
                        new DictionaryEntry("ref_id",sales_detail_id),
                        new DictionaryEntry("bill_id",bill_id),
                        new DictionaryEntry("remarks",remarks),
                    }, conn, tran);


        }

        //点击出库的时间就是出库时间
        public void OutStock(int salesId)
        {
            DataSet ds = DataUtil.ExecuteDataSet("select product_id ,product_name ,color,dimensions,count ,'销售出库' as remarks from salesdetail where sales_id =" + salesId);
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            
                            Stock(Convert.ToString(dr["product_name"]), Convert.ToString(dr["color"]), Convert.ToString(dr["dimensions"]),
                                Convert.ToInt32(dr["product_id"]), Convert.ToInt32(dr["count"]), DateTime.Now, Convert.ToString(dr["remarks"]), 0, Guid.NewGuid().ToString(), Type.Out,OutType.Stock, conn, tran);
                        }
                        DataUtil.ExecuteScalar("update sales set status = 1 where id = " + salesId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        log.Error("出库错误", e);
                        tran.Rollback();
                        throw new Exception("出库错误:"+e.Message);
                    }
                }
            }
        }

        public void CgInStock(string product_name,
            string color,
            string dimensions,
            int product_id,
            int count, DateTime create_time,
           string remarks,int orderId)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction()) {
                    try
                    {
                        DataUtil.ExecuteScalar("update stock set order_count = order_count - " + count + " where product_id = " + product_id, conn, tran);
                        DataUtil.ExecuteScalar("update productorder set status = 2 ,complete_time = now() where id = " + orderId, conn, tran);
                        Stock(product_name, color, dimensions, product_id, count, create_time, remarks,0, "",Type.IN,OutType.Stock, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        log.Error("采购入库错误", e);
                        tran.Rollback();
                        throw new Exception("采购入库错误" + e.Message);
                    }
                }
            }
        }

        private void Stock(string product_name,
            string color,
            string dimensions,
            int product_id,
            int count, DateTime complete_time,
           string remarks, int ref_id, string bill_id, Type type, OutType type2 , DbConnection conn, DbTransaction tran)
        {
            count = type == Type.IN ? Math.Abs(count) : -(Math.Abs(count));
            DataTable dt = DataUtil.ExecuteDataSet("select ifnull(count,0),ifnull(saleable_count,0)  from stock where product_id =" + product_id).Tables[0];

            if (dt.Rows.Count == 0)
            {
                if (type == Type.Out)
                {
                    throw new StockException("该货物没有入库，请先入库");
                }
                DataUtil.Add("stock", new DictionaryEntry[] { 
                    new DictionaryEntry("color",color),
                    new DictionaryEntry("product_name",product_name),
                    new DictionaryEntry("dimensions",dimensions),
                    new DictionaryEntry("product_id",product_id),
                    new DictionaryEntry("count",count),
                    new DictionaryEntry("saleable_count",count),
                    new DictionaryEntry("remarks",remarks),
                }, conn, tran);
            }
            else {
                if (type == Type.Out && - count > Convert.ToInt32(dt.Rows[0][0]) )
                {
                    throw new StockException("该货物没有库存");
                }
                if (type == Type.IN)
                {
                    DataUtil.ExecuteNonQuery("update stock set  count = count +" + count + ",saleable_count = saleable_count +" + count + "  where product_id = " + product_id, conn, tran);
                }
                else
                {

                    DataUtil.ExecuteNonQuery("update stock set  count = count +" + count + " where product_id = " + product_id, conn, tran);
                }
            }
            DataUtil.Add("stockdetail", new DictionaryEntry[] { 
                        new DictionaryEntry("color",color),
                        new DictionaryEntry("product_name",product_name),
                        new DictionaryEntry("dimensions",dimensions),
                        new DictionaryEntry("product_id",product_id),
                        new DictionaryEntry("count",count),
                        new DictionaryEntry("create_time",DateTime.Now),
                        new DictionaryEntry("type",(int)type),
                        new DictionaryEntry("is_store_out",(int) type2),
                        new DictionaryEntry("complete_time",complete_time),
                        new DictionaryEntry("ref_id",ref_id),
                        new DictionaryEntry("bill_id",bill_id),
                        new DictionaryEntry("remarks",remarks),
                    }, conn, tran);
        }

        public void InStock(Telerik.WinControls.UI.GridViewRowCollection gridViewRowCollection)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var row in gridViewRowCollection)
                        {
                            Stock(Convert.ToString(row.Cells["product_name"].Value), Convert.ToString(row.Cells["color"].Value), Convert.ToString(row.Cells["dimensions"].Value),
                                Convert.ToInt32(row.Cells["product_id"].Value), Convert.ToInt32(row.Cells["count"].Value), 
                                Convert.ToDateTime(row.Cells["create_time"].Value), Convert.ToString(row.Cells["remarks"].Value),0,Guid.NewGuid().ToString(), Type.IN,OutType.Stock,conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        log.Error("入库错误", e);
                        tran.Rollback();
                        throw new Exception("入库错误" + e.Message);
                    }
                }
               
            }
          
        }

        public void InStoreStock(Telerik.WinControls.UI.GridViewRowCollection gridViewRowCollection, int store_Id)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (var row in gridViewRowCollection)
                    {
                        StoreStock(Convert.ToString(row.Cells["product_name"].Value), Convert.ToString(row.Cells["color"].Value), Convert.ToString(row.Cells["dimensions"].Value),
                            Convert.ToInt32(row.Cells["product_id"].Value), Convert.ToInt32(row.Cells["count"].Value), Convert.ToDateTime(row.Cells["create_time"].Value),
                            Convert.ToString(row.Cells["remarks"].Value), Type.IN, store_Id, StockDal.OutType.Stock, conn, tran);
                    }
                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("入库错误", e);
                    tran.Rollback();
                    throw new Exception("门店入库错误");
                }

            }
        }

        public void InOrOutStoreStock(string product_name,
            string color,
            string dimensions,
            int product_id,
            int count,
           string remarks, int store_id, DateTime time,Type type,OutType out_type)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {

                    StoreStock(product_name, color, dimensions, product_id, count, time, remarks, type, store_id, out_type, conn, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("错误", e);
                    tran.Rollback();
                    throw new Exception(type == Type.IN ? "门店入库错误" : "门店出库错误");
                }

            }
        }
        public void ReInOrOutStoreStock(int id,string product_name,
           string color,
           string dimensions,
           int product_id,
           int count,
          string remarks, int store_id, DateTime time, Type type)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {

                    count = type == Type.IN ? Math.Abs(count) : -(Math.Abs(count));
                    var row = DataUtil.ExecuteDataSet("select * from storestockdetail where id = " + id).Tables[0].Rows[0];
                    int old_count = Math.Abs((int)row["count"]);
                    if (type == Type.Out) {
                        old_count = -old_count;
                    }
                    //返还库存重新加
                    DataUtil.ExecuteNonQuery("update storestock set  count = count +" + (count - old_count) + ",saleable_count = saleable_count +" + (count - old_count) + "  where product_id = " + product_id + " and store_id = " + store_id, conn, tran);

                    DataUtil.Update("storestockdetail", new DictionaryEntry[] { 
                        new DictionaryEntry("color",color),
                        new DictionaryEntry("product_name",product_name),
                        new DictionaryEntry("dimensions",dimensions),
                        new DictionaryEntry("product_id",product_id),
                        new DictionaryEntry("count",count),
                        new DictionaryEntry("store_id",store_id),
                        new DictionaryEntry("create_time",DateTime.Now),
                        new DictionaryEntry("complete_time",time),
                        new DictionaryEntry("type",(int)type),
                        new DictionaryEntry("id",id),
                        new DictionaryEntry("remarks",remarks),
                    }, conn, tran);



                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("错误", e);
                    tran.Rollback();
                    throw new Exception(type == Type.IN ? "门店入库错误" : "门店出库错误");
                }

            }
        }
      
        private int StoreStock(string product_name,
            string color,
            string dimensions,
            int product_id,
            int count, DateTime complete_time,
           string remarks, Type type, int store_id, OutType out_type, DbConnection conn, DbTransaction tran)
        {
            count = type == Type.IN ? Math.Abs(count) : -(Math.Abs(count));
            var i = DataUtil.ExecuteScalar("select count(1) from storestock where product_id =" + product_id + " and store_id = " + store_id);


            if (i.Equals(0L))
            {
                if (type == Type.Out)
                {
                    throw new Exception("逻辑错误！没有入库就出库了");
                }
                DataUtil.Add("storestock", new DictionaryEntry[] { 
                    new DictionaryEntry("color",color),
                    new DictionaryEntry("product_name",product_name),
                    new DictionaryEntry("dimensions",dimensions),
                    new DictionaryEntry("product_id",product_id),
                    new DictionaryEntry("count",count),
                    new DictionaryEntry("saleable_count",count),
                    new DictionaryEntry("store_id",store_id),
                    new DictionaryEntry("remarks",remarks),
                }, conn, tran);
            }
            else
            {
                DataUtil.ExecuteNonQuery("update storestock set  count = count +" + count + " ,saleable_count = saleable_count+"+count+" where product_id = " + product_id + " and store_id = " + store_id, conn, tran);
            }

            return DataUtil.Add("storestockdetail", new DictionaryEntry[] { 
                        new DictionaryEntry("color",color),
                        new DictionaryEntry("product_name",product_name),
                        new DictionaryEntry("dimensions",dimensions),
                        new DictionaryEntry("product_id",product_id),
                        new DictionaryEntry("count",count),
                        new DictionaryEntry("store_id",store_id),
                        new DictionaryEntry("out_type",(int)out_type),
                        new DictionaryEntry("create_time",DateTime.Now),
                        new DictionaryEntry("complete_time",complete_time),
                        new DictionaryEntry("type",(int)type),
                        new DictionaryEntry("remarks",remarks),
                    }, conn, tran);

        }

        internal void Cancel(int id)
        {
            var info = DataUtil.ExecuteDataSet("select count,product_id from stockdetail where id=" + id).Tables[0].Rows[0];
            int count = (int)info[0];
            int product_id = (int)info[1];
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataUtil.ExecuteNonQuery("update stock set  count = count -" + count + ",saleable_count = saleable_count -" + count + "  where product_id = " + product_id, conn, tran);
                        DataUtil.ExecuteNonQuery("update stockdetail set status = 1 where id = " + id, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {

                        log.Error("入库撤销错误", e);
                        tran.Rollback();
                        throw new Exception("入库撤销错误" + e.Message);
                    }
                }
            }
        }
        internal void InitStock()
        {
            DataUtil.ExecuteNonQuery(@"insert into stock (`product_id`,
`product_name`,
`dimensions`,
`color`,
`count`,
`saleable_count`,
`order_count`)
select `id`,
`name`,
`dimensions`,
`color`,
0,
0,
0 from product where id not in ( select product_id from stock);");
        }
        internal void DeleteStoreStock(int id)
        {
            var rows = DataUtil.ExecuteDataSet("select count,product_id,store_id from storestockdetail where id=" + id).Tables[0].Rows;
            if (rows.Count > 0)
            {

                var info = rows[0];
                int count =  (int)info[0];
                int product_id = (int)info[1];
                int store_id = (int)info[2];
                using (DbConnection conn = DataUtil.DB.CreateConnection())
                {
                    conn.Open();
                    using (DbTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            DataUtil.ExecuteNonQuery("update storestock set  count = count -" + count + ",saleable_count = saleable_count -" + count + "  where product_id = " + product_id + " and store_id = " + store_id, conn, tran);
                            DataUtil.ExecuteNonQuery("delete from  storestockdetail where id = " + id, conn, tran);
                            tran.Commit();
                        }
                        catch (Exception e)
                        {

                            log.Error("入库删除错误", e);
                            tran.Rollback();
                            throw new Exception("入库删除错误" + e.Message);
                        }
                    }
                }
            }
        }
        internal void Delete(int id)
        {

            var rows =  DataUtil.ExecuteDataSet("select count,product_id from stockdetail where id=" + id).Tables[0].Rows;
            if (rows.Count > 0)
            {

                var info = rows[0];
                int count = (int)info[0];
                int product_id = (int)info[1];
                using (DbConnection conn = DataUtil.DB.CreateConnection())
                {
                    conn.Open();
                    using (DbTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            DataUtil.ExecuteNonQuery("update stock set  count = count -" + count + ",saleable_count = saleable_count -" + count + "  where product_id = " + product_id, conn, tran);
                            DataUtil.ExecuteNonQuery("delete from  stockdetail where id = " + id, conn, tran);
                            tran.Commit();
                        }
                        catch (Exception e)
                        {

                            log.Error("入库删除错误", e);
                            tran.Rollback();
                            throw new Exception("入库删除错误" + e.Message);
                        }
                    }
                }
            }
        }

        internal void ReInOrOutStock(int id, string product_name,
           string color,
           string dimensions,
           int product_id,
           int count,
          string remarks,DateTime time, Type type)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {

                    count = type == Type.IN ? Math.Abs(count) : -(Math.Abs(count));
                    var row = DataUtil.ExecuteDataSet("select * from stockdetail where id = " + id).Tables[0].Rows[0];
                    int old_count = Math.Abs((int)row["count"]);
                    if (type == Type.Out)
                    {
                        old_count = -old_count;
                    }
                    //返还库存重新加
                    DataUtil.ExecuteNonQuery("update stock set  count = count +" + (count - old_count) + ",saleable_count = saleable_count +" + (count - old_count) + "  where product_id = " + product_id , conn, tran);

                    DataUtil.Update("stockdetail", new DictionaryEntry[] { 
                        new DictionaryEntry("color",color),
                        new DictionaryEntry("product_name",product_name),
                        new DictionaryEntry("dimensions",dimensions),
                        new DictionaryEntry("product_id",product_id),
                        new DictionaryEntry("count",count),
                        new DictionaryEntry("create_time",DateTime.Now),
                        new DictionaryEntry("complete_time",time),
                        new DictionaryEntry("type",(int)type),
                        new DictionaryEntry("id",id),
                        new DictionaryEntry("remarks",remarks),
                    }, conn, tran);



                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("错误", e);
                    tran.Rollback();
                    throw new Exception(type == Type.IN ? "门店入库错误" : "门店出库错误");
                }

            }
        }

      
        public  void ResetStock(int salesID, DbConnection conn, DbTransaction tran)
        {
            DataSet ds = DataUtil.ExecuteDataSet("select status from sales where id=" + salesID + ";select sum(count)  as count,product_id from salesdetail where sales_id=" + salesID + " group by product_id;" +
               "select stockdetail.* from stockdetail left join salesdetail sd on ref_id = sd.id where sd.sales_id = " + salesID, conn, tran);
            int status = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            //if ((int)DataUtil.SalesStatus.完成 == status)
            //{

            //    //加回库存
            //    foreach (DataRow dr in ds.Tables[1].Rows)
            //    {
            //        //DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count + "
            //        //   + dr["count"] + " , count=count+" + dr["count"] + " where product_id = "
            //        //   + dr["product_id"], conn, tran);
            //    }

            //}
            //else
            //{
               
                
            //}
            //加回可用库存
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count + "
                   + dr["count"] + " where product_id = "
                   + dr["product_id"], conn, tran);
            }
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                //加回总库出库库存
                if ((int)dr["is_store_out"] != 1)
                {
                    DataUtil.ExecuteNonQuery("update stock set count = count - "
                   + dr["count"] + " where product_id = "
                   + dr["product_id"], conn, tran);
                }
                else
                {
                    //可用库存减去门店出库库存
                    DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count - "
                    + dr["count"] + " where product_id = "
                    + dr["product_id"], conn, tran);
                }

            }



        }

        public void OutStoreStockToStock(string product_name,
         string color,
         string dimensions,
         int product_id,
         int count,
        string remarks, int store_id, DateTime time)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    int id = StoreStock(product_name, color, dimensions, product_id, count, time, remarks, Type.Out, store_id , StockDal.OutType.StoreStock, conn, tran);
                    Stock(product_name, color, dimensions, product_id, count, DateTime.Now, "门店转移到仓库", id, "", Type.IN, OutType.StoreStock, conn, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("错误", e);
                    tran.Rollback();
                    throw new Exception("门店出库总仓错误");
                }
            }
        }

        public void ReOutStoreStockToStock(int id, string product_name,
           string color,
           string dimensions,
           int product_id,
           int count,
          string remarks, int store_id, DateTime time)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    int stockdetailId = (int)DataUtil.ExecuteScalar("select id from stockdetail where ref_id=" + id + " and type = 0 and is_store_out = 1");
                    ReInOrOutStock(stockdetailId, product_name, color, dimensions, product_id, count, "门店转移到仓库", time, Type.IN);
                    ReInOrOutStoreStock(id, product_name, color, dimensions, product_id, count, remarks, store_id, time, Type.Out);
                    
                    tran.Commit();
                }
                catch (Exception e)
                {
                    log.Error("错误", e);
                    tran.Rollback();
                    throw new Exception("门店出库总仓错误");
                }
            }
        }
    }
}
