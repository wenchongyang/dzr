using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ERP.Data
{
    public class SalesDal
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(SalesDal));
        public static void upLoadFile(byte[] img, int salesId)
        {
            log.Debug("上传文件" + salesId + " 大小：" + img.Length);
            DbCommand cmd = DataUtil.DB.GetSqlStringCommand("update sales set sapshot = @sapshot where @id = id");
            DataUtil.DB.AddParameter(cmd, "@sapshot", System.Data.DbType.Binary, img.Length, System.Data.ParameterDirection.Input, false, (byte)2, (byte)2, "sapshot", new DataRowVersion(), img);
            DataUtil.DB.AddInParameter(cmd, "@id", System.Data.DbType.Int32, salesId);
            DataUtil.DB.ExecuteNonQuery(cmd);
        }
        public static byte[] GetBuffer(int salesId)
        {

            DbCommand cmd = DataUtil.DB.GetSqlStringCommand("select sapshot from  sales where id =" + salesId);
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                cmd.Connection = conn;

                System.Data.Common.DbDataReader reader = cmd.ExecuteReader();
                byte[] buffer = null;
                try
                {

                    if (reader.HasRows)
                    {
                        reader.Read();
                        long len = reader.GetBytes(0, 0, null, 0, 0);//1是picture   
                        buffer = new byte[len];
                        len = reader.GetBytes(0, 0, buffer, 0, (int)len);
                    }
                }
                catch { }
                return buffer;
            }
        }

        public static void SaveMargins(GridViewRowCollection drs)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (var dr in drs)
                    {
                        decimal margins = dr.Cells["margins"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["margins"].Value;
                        decimal commission = dr.Cells["commission"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["commission"].Value;
                        decimal cost_price = dr.Cells["cost_price"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["cost_price"].Value;
                        string cal_way = Convert.ToString(dr.Cells["cal_way"].Value);
                        int id = Convert.ToInt32(dr.Cells["id"].Value);
                        DataUtil.ExecuteNonQuery("update salesdetail set cost_price =" + cost_price + ", margins=" + margins + ", commission=" + commission + ",cal_way ='" + cal_way + "' where id=" + id, conn, tran);
                    }
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    log.Error("订单录入错误", e);
                }
            }
        }

        private static void SetCost(GridViewRowInfo row)
        {
            DataRow[] products = Data.DataUtil.ProductTableWithOutAll.Select("id = " + row.Cells["product_id"].Value);
            decimal cost_price = 0;
            var tmp = products[0]["cost_price"];
            if (!DBNull.Value.Equals(tmp))
            {
                cost_price = Convert.ToDecimal(tmp);
            }
            int count = Convert.ToInt32(row.Cells["count"].Value);
            decimal pay = Convert.ToDecimal(row.Cells["actually_pay"].Value);
            row.Cells["margins"].Value = pay - (count * cost_price);
            row.Cells["cost_price"].Value = count * cost_price;
        }
        public static int Add(DictionaryEntry[] salesInfo, GridViewRowCollection saleDetail)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                int id = 0;
                try
                {
                    id = DataUtil.Add("sales", salesInfo, conn, tran);
                    foreach (GridViewRowInfo row in saleDetail)
                    {
                        row.Cells["sales_id"].Value = id;
                        if (row.Cells["product_id"].Value == null || row.Cells["product_id"].Value == DBNull.Value)
                        {
                            tran.Rollback();
                            return 0;
                        }

                        SetCost(row);

                        //减去可用库存
                        DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count - "
                            + row.Cells["count"].Value + " where product_id = "
                            + row.Cells["product_id"].Value, conn, tran);
                    }
                    DataUtil.Add("salesdetail", saleDetail, conn, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    log.Error("订单录入错误", e);
                    MessageBox.Show("订单录入错误");
                }
                return id;
            }
        }

        internal static void Edit(int salesID, DictionaryEntry[] salesInfo, GridViewRowCollection saleDetail)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();

                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        StockDal stock = new StockDal();
                        stock.ResetStock(salesID, conn, tran);


                        int id = DataUtil.Update("sales", salesInfo, conn, tran);
                        //删除出库信息
                        DataUtil.ExecuteNonQuery("delete from stockdetail where ref_id in (select id from salesdetail where sales_id=" + salesID + ");", conn, tran);
                        DataUtil.ExecuteNonQuery("delete from salesdetail where sales_id =" + salesID, conn, tran);
                        foreach (var row in saleDetail)
                        {

                            row.Cells["sales_id"].Value = salesID;
                            //减去可用库存
                            DataUtil.ExecuteNonQuery("update stock set saleable_count = saleable_count - "
                                + row.Cells["count"].Value + " where product_id = "
                                + row.Cells["product_id"].Value, conn, tran);
                            SetCost(row);
                        }

                        DataUtil.Add("salesdetail", saleDetail, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        log.Error("订单录入错误", e);
                        MessageBox.Show("修改订单错误");
                    }
                }
            }
        }



        internal static void Cancel(int salesID)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                log.Debug("撤销订单" + salesID);
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    StockDal stock = new StockDal();
                    stock.ResetStock(salesID, conn, tran);
                    //作废出库单
                    DataUtil.ExecuteNonQuery("update stockdetail set status = 1  where ref_id in (select id from salesdetail where sales_id=" + salesID + ");");
                    DataUtil.ExecuteNonQuery("update sales set status = 2 where id = " + salesID, conn, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    log.Error("撤销订单错误", e);
                    MessageBox.Show("撤销订单错误");
                }
            }
        }

        internal static void SaveMargins(GridViewRowInfo dr)
        {
            decimal margins = dr.Cells["margins"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["margins"].Value;
            decimal commission = dr.Cells["commission"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["commission"].Value;
            decimal cost_price = dr.Cells["cost_price"].Value == DBNull.Value ? 0 : (decimal)dr.Cells["cost_price"].Value;
            string cal_way = Convert.ToString(dr.Cells["cal_way"].Value);
            object id_ = dr.Cells["id"].Value;
            if (id_ != DBNull.Value)
            {
                int id = Convert.ToInt32(id_);
                DataUtil.ExecuteNonQuery("update salesdetail set cost_price =" + cost_price + ", margins=" + margins + ", commission=" + commission + ",cal_way ='" + cal_way + "' where id=" + id);

            }
            else
            {
                log.Error(dr.Cells["id"].Value);
            }

        }

        internal static void CKEdit(int Id, DictionaryEntry[] dictionaryEntry)
        {
            DataUtil.ExecuteNonQuery("update sales set delivery_number=@delivery_number,delivery_pay=@delivery_pay,delivery_date =@delivery_date,delivery_remarks=@delivery_remarks,paymet_method2=@paymet_method2 where id = " + Id, dictionaryEntry);
        }
    }
}
