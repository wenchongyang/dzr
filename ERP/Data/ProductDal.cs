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
     public class ProductDal
    {
         static log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProductDal));
         public static void DelProduct(int id) {
             using (DbConnection conn = DataUtil.DB.CreateConnection())
             {
                 conn.Open();
                 using (DbTransaction tran = conn.BeginTransaction())
                 {
                     try
                     {
                         //更新可用库存
                         DataUtil.ExecuteScalar("delete from stock where product_id = " +id, conn, tran);
                         DataUtil.ExecuteScalar("delete from stockdetail where product_id = " + id, conn, tran);
                         DataUtil.ExecuteScalar("delete from storestock where product_id = " + id, conn, tran);
                         DataUtil.ExecuteScalar("delete from storestockdetail where product_id = " + id, conn, tran);
                         DataUtil.ExecuteScalar("delete from product where id = " + id, conn, tran);

                          
                         tran.Commit();
                     }
                     catch
                     {
                         tran.Rollback();
                     }
                 }
             }
         }
         public static int GetProduct(string product_name, string dimensions, string color) {
             //DataTable productTable = DataUtil.ExecuteDataSet("SELECT * FROM product where color ='" +
             //    color + "' and name = '" + product_name + "' and dimensions = '" + dimensions + "'").Tables[0];
             foreach (DataRow dr in DataUtil.ProductTableWithOutAll.Rows)
             {
                 if (Convert.ToString(dr["name"]) == product_name && dimensions == 
                     Convert.ToString(dr["dimensions"]) && 
                     color == Convert.ToString(dr["color"]))
                 {
                     return (int)dr["id"];
                 }
             }
             return 0;
             //return DataUtil.Add("product", new System.Collections.DictionaryEntry[] {
             //  new DictionaryEntry("name",product_name),
             //  new DictionaryEntry("dimensions",dimensions),
             //  new DictionaryEntry("color",color)
             //});
         }
         public static int GetProduct(string product_name, string dimensions, string color, out decimal? guide_price, out decimal? cost_price, bool enableAdd)
         {
             //DataTable productTable = DataUtil.ExecuteDataSet("SELECT * FROM product where color ='" +
             //    color + "' and name = '" + product_name + "' and dimensions = '" + dimensions + "'").Tables[0];
             guide_price = null;
             cost_price = null;
             foreach (DataRow dr in DataUtil.ProductTableWithOutAll.Rows)
             {
                 
                 if (Convert.ToString(dr["name"]) == product_name && dimensions == 
                     Convert.ToString(dr["dimensions"]) && 
                     color == Convert.ToString(dr["color"])) {
                     var tmp = dr["guide_price"];
                     if (!DBNull.Value.Equals(tmp))
                     {
                         guide_price = Convert.ToDecimal(tmp);
                     }
                     tmp = dr["cost_price"];
                     if (!DBNull.Value.Equals(tmp))
                     {
                         cost_price = Convert.ToDecimal(tmp);
                     }
                     return (int)dr["id"];
                 }
             }
             if (enableAdd)
             {
                 return DataUtil.Add("product", new System.Collections.DictionaryEntry[] {
               new DictionaryEntry("name",product_name),
               new DictionaryEntry("dimensions",dimensions),
               new DictionaryEntry("color",color)
             });
             } return 0;
         }
         public static void BindProduct(RadDropDownList product_nameDdl, RadDropDownList colorDdl, RadDropDownList dimensionsDdl, bool hasAll)
         {

             //DataUtil.ExecuteDataSet("Select '--全部--' name, '--全部--' color, '--全部--' dimensions from dual union all SELECT name,color,dimensions FROM product ").Tables[0];
             DataTable dt = hasAll ? DataUtil.ProductTable : DataUtil.ProductTableWithOutAll;
             product_nameDdl.DataSource = dt.DefaultView.ToTable(true, "name");
             product_nameDdl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             product_nameDdl.ValueMember = "name";
             product_nameDdl.DisplayMember = "name";
             product_nameDdl.SelectedIndexChanged += product_nameDdl_SelectedIndexChanged;
             product_nameDdl.Tag = hasAll;

             colorDdl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             colorDdl.DataSource = dt.DefaultView.ToTable(true, "color");
             colorDdl.ValueMember = "color";
             colorDdl.DisplayMember = "color";
             //colorDdl.SelectedIndexChanged += colorDdl_SelectedIndexChanged;

             dimensionsDdl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             dimensionsDdl.DataSource = dt.DefaultView.ToTable(true, "dimensions");
             dimensionsDdl.ValueMember = "dimensions";
             dimensionsDdl.DisplayMember = "dimensions";
             dimensionsDdl.SelectedIndexChanged += dimensionsDdl_SelectedIndexChanged;

             product_nameDdl_SelectedIndexChanged(product_nameDdl, null);
             dimensionsDdl_SelectedIndexChanged(dimensionsDdl, null);
         }

         private static void dimensionsDdl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
         {
             var product_nameDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("product_nameDdl", true)[0];
             var colorDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("colorDdl", true)[0];
             var dimensionsDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("dimensionsDdl", true)[0];


             colorDdl.DataSource = DataUtil.GetPorductColor("" + product_nameDdl.SelectedValue, "" + dimensionsDdl.SelectedValue, (bool)product_nameDdl.Tag);
             colorDdl.ValueMember = "text";
             colorDdl.DisplayMember = "text";
            
         }

         private static void colorDdl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
         {
             var product_nameDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("product_nameDdl", true)[0];
             var colorDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("colorDdl", true)[0];
             var dimensionsDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("dimensionsDdl", true)[0];


             dimensionsDdl.DataSource = DataUtil.GetPorductDimensions(""+product_nameDdl.SelectedValue, ""+colorDdl.SelectedValue, (bool) product_nameDdl.Tag);
             dimensionsDdl.ValueMember = "text";
             dimensionsDdl.DisplayMember = "text";

             //colorDdl.SelectedIndexChanged -= colorDdl_SelectedIndexChanged;
         }

         private static void product_nameDdl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
         {
             var product_nameDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("product_nameDdl", true)[0];
             var colorDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("colorDdl", true)[0];
             var dimensionsDdl = (RadDropDownList)((RadDropDownList)sender).Parent.Controls.Find("dimensionsDdl", true)[0];

           
             dimensionsDdl.DataSource = DataUtil.GetPorductDimensions("" + product_nameDdl.SelectedValue, "" + colorDdl.SelectedValue, (bool)product_nameDdl.Tag);
             dimensionsDdl.ValueMember = "text";
             dimensionsDdl.DisplayMember = "text";

             colorDdl.DataSource = DataUtil.GetPorductColor("" + product_nameDdl.SelectedValue, "" + dimensionsDdl.SelectedValue, (bool)product_nameDdl.Tag);
             colorDdl.ValueMember = "text";
             colorDdl.DisplayMember = "text";

            // colorDdl.SelectedIndexChanged += colorDdl_SelectedIndexChanged;
         }


         internal static void Back(List<DictionaryEntry> list, int count, int product_id)
         {

             using (DbConnection conn = DataUtil.DB.CreateConnection())
             {
                 conn.Open();
                 using (DbTransaction tran = conn.BeginTransaction())
                 {
                     try
                     {
                         //更新可用库存
                         DataUtil.ExecuteScalar("update stock  set saleable_count = saleable_count - " + count + " where product_id = " + product_id, conn, tran);

                         DataUtil.Add("productsentback", list.ToArray(), conn, tran);
                         tran.Commit();
                     }
                     catch
                     {
                         tran.Rollback();
                     }
                 }
             }
         }

         internal static void Return(int Id) {
             DataUtil.ExecuteScalar(string.Format("update productsentback set status = 2,complete_time = now() where id = {0}; "
                 +"update stock set saleable_count = saleable_count +(select count from productsentback where id = {0}) "+
                 "where product_id = (select product_id from productsentback where id = {0});  ",Id));
         }

         internal static void Update(GridViewRowInfo dr)
         {
             using (DbConnection conn = DataUtil.DB.CreateConnection())
             {
                 conn.Open();
                 using (DbTransaction tran = conn.BeginTransaction())
                 {
                     try
                     {
                         string name = dr.Cells["name"].Value.ToString().Trim(), dimensions = dr.Cells["dimensions"].Value.ToString().Trim(), color = dr.Cells["color"].Value.ToString().Trim();
                         int id = (int)dr.Cells["id"].Value;
                         DataUtil.Update("product", dr, conn, tran);
                         DataUtil.ExecuteNonQuery("update stock set product_name = '" + name + "' , dimensions = '" + dimensions + "',color='" + color + "' where product_id = " + id, conn, tran);
                         DataUtil.ExecuteNonQuery("update stockdetail set product_name = '" + name + "' , dimensions = '" + dimensions + "',color='" + color + "' where product_id = " + id, conn, tran);

                         DataUtil.ExecuteNonQuery("update storestock set product_name = '" + name + "' , dimensions = '" + dimensions + "',color='" + color + "' where product_id = " + id, conn, tran);
                         DataUtil.ExecuteNonQuery("update storestockdetail set product_name = '" + name + "' , dimensions = '" + dimensions + "',color='" + color + "' where product_id = " + id, conn, tran);
                         tran.Commit();
                     }
                     catch(Exception e)
                     {
                         log.Error("", e);
                         MessageBox.Show("修改商品错误");
                     }
                 }
             }
         }
    }
}
