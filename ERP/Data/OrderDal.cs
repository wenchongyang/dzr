using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ERP.Data
{
    public  class OrderDal
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(OrderDal));

        public void create(List<DictionaryEntry> list, int count, int product_id)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        //更新订货数量
                        //DataUtil.ExecuteScalar("update stock  set order_count = ifnull(order_count,0) + " + count + " where product_id = " + product_id, conn, tran);
                        list.Add(new  DictionaryEntry("product_id",product_id));
                        DataUtil.Add("productorder", list.ToArray(), conn, tran);
                        tran.Commit();
                    }
                    catch(Exception e)
                    {
                        log.Error("新加订货出错", e);
                        tran.Rollback();
                        throw new Exception("新加订货出错");
                    }
                }
            }
        }
        public void update(List<DictionaryEntry> list, int count, int product_id, int id, int status)
        {
            using (DbConnection conn = DataUtil.DB.CreateConnection())
            {
                  conn.Open();
                  using (DbTransaction tran = conn.BeginTransaction())
                  {
                      try
                      {
                          int raw_count = (int)Data.DataUtil.ExecuteScalar("select count from productorder where id = " + id);
                          Data.DataUtil.ExecuteNonQuery("update productorder set price = @price, count = @count ,remarks=@remarks,status=@status,order_time = @order_time where id=@id", list.ToArray(), conn, tran);
                          if(status == 1 ){
                              DataUtil.ExecuteNonQuery("update stock  set order_count = ifnull(order_count,0) + " + count + " where product_id = " + product_id, conn, tran);
                          }

                          tran.Commit();
                      }
                      catch (Exception e)
                      {
                          log.Error("更新订货出错", e);
                          tran.Rollback();
                          throw new Exception("更新订货出错");
                      }
                  }
            }
        }


    }
}
