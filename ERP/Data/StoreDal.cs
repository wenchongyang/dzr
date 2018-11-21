using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Data
{
   public class StoreDal
    {
       public static int GetBillNo(int storeId)
       {
           var year = DateTime.Now.Year * 100000;
           var maxId = DataUtil.ExecuteScalar("select IFNULL(max(CONVERT(bill_id,SIGNED)),10000) from sales where store_id =" + storeId).ToString();
           maxId = maxId.Substring(4);
           int id = int.Parse(maxId);

           return year + id + 1;
       }
    }
}
