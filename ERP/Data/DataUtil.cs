using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ERP.Data
{
    public class DataUtil
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataUtil));
        public static String Version = "1.6";
        static readonly Database db = DatabaseFactory.CreateDatabase();
        public static Database DB
        {
            get { return db; }
        }
        private DataUtil()
        { }

       

        #region Cache
        public static DataTable ProductTable;
        public static DataTable ProductTableWithOutAll;
        public static DataTable StoreTable;
        public static DataTable UsersTable;
        public static DateTime Now;
        public static void LoadStore()
        {
            Now = (DateTime)DataUtil.ExecuteScalar("SELECT now();");
            StoreTable = DataUtil.ExecuteDataSet(" SELECT name,id FROM store ").Tables[0];
        }
        public static void LoadUsers()
        {
            UsersTable = DataUtil.ExecuteDataSet(" SELECT name,id,role_id,store_id FROM users ").Tables[0];
        }
        public static void LoadProduct()
        {
            //Select '--全部--' name, '--全部--' color, '--全部--' dimensions from dual union all
            ProductTableWithOutAll = DataUtil.ExecuteDataSet(" SELECT name,color,dimensions,id,guide_price,cost_price FROM product order by id,name,color,dimensions").Tables[0];
            ProductTable = ProductTableWithOutAll.Copy();
            var dr = ProductTable.NewRow();
            dr[0] = dr[1] = dr[2] = "--全部--";
            ProductTable.Rows.InsertAt(dr, 0);
        }

        #endregion 
        
        #region Enum 
        public enum OrderStatus2
        {
            待处理, 已订货
        }

        public enum StockStatus
        {
            正常, 已撤销
        }
        public enum OrderStatus {
            待处理,已订货,已完成
        }
        public enum BackStatus2
        {
            待处理, 已返厂
        }
        public enum BackStatus
        {
            待处理, 已返厂, 完成
        }

        public enum Gender
        {
            男, 女
        }

        public enum SalesStatus
        {
           待出库, 完成, 撤销
        }
        #endregion 
     
        #region 
        public static List<DictionaryEntry> GetFormInfo(Control root)
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            foreach (Control c in root.Controls)
            {
                if (c.Tag != null)
                {
                    string key = c.Tag.ToString();
                    if (!String.IsNullOrWhiteSpace(key))
                    {
                        object value = c.Text;
                        if (c is RadSpinEditor)
                        {
                            value = ((RadSpinEditor)c).Value;
                        }
                        else if (c is RadDateTimePicker)
                        {
                            value = ((RadDateTimePicker)c).Value;
                        }
                        else if (c is ComboBox)
                        {
                            value = ((ComboBox)c).SelectedValue;
                        }
                        list.Add(new DictionaryEntry(key, value));
                    }

                }
            }
            return list;
        }
        public static void BindEnum2(ListControl list, System.Type enumType, bool hasAll)
        {
            list.DataSource = Enum2DataTable(enumType, hasAll);
            list.DisplayMember = "key";
            list.ValueMember = "val";
        }
        public static DataTable Enum2DataTable(System.Type enumType,bool hasAll)
        {
            return Enum2DataTable(enumType, "key", "val", hasAll);
        }
        public static DataTable GetPorductDimensions(string name,string color, bool hasAll)
        {
            DataTable newDt = new DataTable();


            newDt.Columns.Add("text");
            if (hasAll)
            {
                DataRow newDr = newDt.NewRow();
                newDr[0] = "--全部--";
                newDt.Rows.Add(newDr);
            }

            Hashtable hs = new Hashtable();
            foreach (DataRow dr in ProductTable.Rows)
            {
                if (name.Equals(dr["name"]) || name == "--全部--" || name == "")
                {
                    //if (color.Equals(dr["color"]) || color == "--全部--" || color == "")
                    {
                        if (!hs.ContainsKey(dr["dimensions"]))
                        {
                            hs.Add(dr["dimensions"], null);
                            DataRow newDr = newDt.NewRow();
                            newDr[0] = dr["dimensions"];
                            if (!"--全部--".Equals(newDr[0]))
                            {
                                newDt.Rows.Add(newDr);
                            }
                        }
                    }
                }
            }

            return newDt;
        }
        public static DataTable GetPorductColor(string name, string dimensions, bool hasAll)
        {
            DataTable newDt = new DataTable();


            newDt.Columns.Add("text");
            Hashtable hs = new Hashtable();
            if (hasAll)
            {
                DataRow newDr = newDt.NewRow();
                newDr[0] = "--全部--";
                newDt.Rows.Add(newDr);
                hs.Add("--全部", null);
            }


            foreach (DataRow dr in ProductTable.Rows)
            {
                if (name.Equals(dr["name"]) || name == "--全部--")
                {
                    if (dimensions.Equals(dr["dimensions"]) || dimensions == "--全部--")
                    {
                        if (!hs.ContainsKey(dr["color"]))
                        {
                            hs.Add(dr["color"], null);
                            DataRow newDr = newDt.NewRow();
                            newDr[0] = dr["color"];
                            if (!"--全部--".Equals(newDr[0]))
                            {
                                newDt.Rows.Add(newDr);
                            }
                        }
                    }
                }
            }
           
            return newDt;
        }
        public static DataTable Clone(DataTable dt)
        {
            DataTable newDt = new DataTable();

            DataColumnCollection cols = dt.Columns;
            foreach (DataColumn dc in cols)
            {
                newDt.Columns.Add(dc.ColumnName, dc.DataType);
            }
            foreach (DataRow dr in dt.Rows)
            {
                DataRow nDr = newDt.NewRow();

                foreach (DataColumn dc in cols)
                {
                    nDr[dc.ColumnName] = dr[dc.ColumnName];
                }
                newDt.Rows.Add(nDr);
            }
            return newDt;
        }
        public static DataTable Enum2DataTable(System.Type enumType, string key, string val,bool hasAll)
        {
            // 获取所有枚举的名称
            //string[] names = Enum.GetNames(enumType);
            // 获取所有枚举的值
            Array values = Enum.GetValues(enumType);
            DataTable dict = new DataTable();
            dict.Columns.Add(new DataColumn(key));
            dict.Columns.Add(new DataColumn(val));
            dict.Columns[val].Unique = true;
            dict.Columns[val].AllowDBNull = false;
            //如果这里不指定和DataGrid对应列相同的列类型就会抛出DataError异常
            dict.Columns[val].DataType = System.Type.GetType("System.Int32");
            if (hasAll)
            {
                DataRow drNull = dict.NewRow();
                drNull[key] = "---全部---";
                drNull[val] = -1;
                dict.Rows.Add(drNull);
            }
            for (int i = 0; i < values.Length; i++)
            {
                DataRow dr = dict.NewRow();
                dr[key] = values.GetValue(i);
                dr[val] =(int)values.GetValue(i);
                dict.Rows.Add(dr);
            }
            return dict;
        }
        public static DataTable BindComboBoxData(string tablename, DictionaryEntry[] wheres, string whereStr)
        {
            return BindComboBoxData("name", "id", tablename, wheres, whereStr, true);
        }
        public static DataTable BindComboBoxData(string tablename, DictionaryEntry[] wheres, string whereStr, bool hasAll)
        {
            return BindComboBoxData("name", "id", tablename, wheres, whereStr, hasAll);
        }
        public static DataTable BindComboBoxData(string columnName, string columnIdName, string tablename, DictionaryEntry[] wheres, string whereStr, bool hasAll)
        {
            DataTable dt = BindData(tablename, wheres, whereStr);
            if (hasAll)
            {
                DataRow dr = dt.NewRow();
                dr[columnIdName] = -1;
                dr[columnName] = "---全部---";
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }
        public static DataTable BindData(string tablename, DictionaryEntry[] wheres, string whereStr)
        {
            string sql = "select * from " + tablename + " where 1=1 " + whereStr;
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DataTable dt = new DataTable(tablename);
                    DbDataAdapter adp = db.GetDataAdapter();

                    adp.SelectCommand = db.GetSqlStringCommand(sql);
                    if (null != wheres)
                        foreach (DictionaryEntry where in wheres)
                        {
                            db.AddInParameter(adp.SelectCommand, "@" + where.Key, DbType.String, where.Value);
                        }
                    //adp.SelectCommand.CommandText = sql + whereStr;
                    adp.SelectCommand.Connection = conn;
                    adp.FillSchema(dt, SchemaType.Mapped);
                    adp.Fill(dt);
                    return dt;
                }
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }

        }

        public static DataTable BindForm(Control root, String tableName, int id)
        {
            DataTable salesTable = DataUtil.BindData(tableName, null, " and id=" + id);
            DataRow dr = salesTable.Rows[0];
            foreach (Control c in root.Controls)
            {
                if (c.Tag != null)
                {
                    string key = c.Tag.ToString();
                    if (salesTable.Columns.Contains(key))
                    {
                        var obj = dr[key];
                        try
                        {
                            
                            if (c is RadSpinEditor)
                            {
                                ((RadSpinEditor)c).Value = obj == DBNull.Value || obj == null ? (decimal)0 : Convert.ToDecimal(dr[key]);
                            }
                            else if (c is RadDateTimePicker)
                            {
                                if (null != dr[key] && DBNull.Value != dr[key])
                                    ((RadDateTimePicker)c).Value = (DateTime)dr[key];
                            }
                            else if (c is ComboBox)
                            {
                                if (null != dr[key] && DBNull.Value != dr[key])
                                    ((ComboBox)c).SelectedValue = dr[key];
                            }
                            else if (c is RadMaskedEditBox)
                            {
                                ((RadMaskedEditBox)c).Text = dr[key] + "";
                            }
                            else
                            {
                                c.Text = dr[key] + "";
                            }
                        }
                        catch (Exception e) {
                            log.Error("设置错误" + obj + ":" + obj.GetType() + ": " + c.Name, e);
                            throw e;
                        }
                    }

                }
            }
            return salesTable;
        }

        #endregion       

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    cmd.Connection = conn;
                    return db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception e) {
                log.Error("执行错误！"+ sql, e);
                throw e;
            }
        }
        public static int ExecuteNonQuery(string sql, DictionaryEntry[] parms)
        {
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    foreach (DictionaryEntry de in parms)
                    {
                        db.AddInParameter(cmd, "@" + de.Key, DbType.String, de.Value);
                    }
                    cmd.Connection = conn;
                    return db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }

        }

        public static int ExecuteNonQuery(string sql, DictionaryEntry[] parms, DbConnection conn, DbTransaction tran)
        {
            try
            {
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    foreach (DictionaryEntry de in parms)
                    {
                        db.AddInParameter(cmd, "@" + de.Key, DbType.String, de.Value);
                    }
                    cmd.Connection = conn;
                    return db.ExecuteNonQuery(cmd);
                
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }

        }
        public static int ExecuteNonQuery(string sql, DbConnection conn, DbTransaction tran)
        {
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }
        }
        #endregion 
       
        #region ExecuteDataSet
       
        public static DataSet ExecuteDataSet(string sql, DictionaryEntry[] parms)
        {
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    foreach (DictionaryEntry de in parms)
                    {
                        db.AddInParameter(cmd, "@" + de.Key, DbType.String, de.Value);
                    }
                    cmd.Connection = conn;
                    return db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }
        }
        public static DataSet ExecuteDataSet(string sql, DbConnection conn, DbTransaction tran)
        {
            
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    return db.ExecuteDataSet(cmd);
                
             
        }
        public static DataSet ExecuteDataSet(string sql)
        {
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("数据库无法链接，请检查网络情况或联系管理员！");
                        Application.ExitThread();
                        throw e;
                    }
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    cmd.Connection = conn;
                    return db.ExecuteDataSet(cmd);
                }

            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }
        }

        #endregion 
        
        #region ExecuteScalar
       
        public static Object ExecuteScalar(string sql)
        {
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    cmd.Connection = conn;
                    return db.ExecuteScalar(cmd);
                }
            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }
        }
        public static Object ExecuteScalar(string sql, DbConnection conn, DbTransaction tran)
        {
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                return db.ExecuteScalar(cmd);

            }
            catch (Exception e)
            {
                log.Error("执行错误！" + sql, e);
                throw e;
            }
        }

        #endregion 

       
        #region Command
        private static Hashtable sqlCommonds = null;
        public class Command
        {
            DbCommand insertCommond;
            DbCommand deleteCommond;
            DbCommand updateCommond;
            public static DbCommand GetDbCommand(string tablename, Type type)
            {

                if (null == sqlCommonds)
                {

                    sqlCommonds = new Hashtable();

                    #region users
                    sqlCommonds.Add("users", new Command("users", @"INSERT INTO users
     (name,username,store_id,role_id,sex,phone,address,id_card,join_date,remarks,salary,password)
     VALUES (@name,@username,@store_id,@role_id,@sex,@phone,@address,@id_card,@join_date,@remarks,@salary,'88888888')",
               @"UPDATE users SET name = @name,username = @username,store_id = @store_id
      ,role_id = @role_id      ,sex = @sex
      ,phone = @phone      ,address = @address
      ,id_card = @id_card      ,join_date = @join_date,salary = @salary
      ,remarks = @remarks   where id=@id"));
                    #endregion

                    #region store
                    sqlCommonds.Add("store", new Command("store", @"INSERT INTO store (name, phone, address, lead, remarks) VALUES (@name, @phone, @address, @lead, @remarks)",
                @"UPDATE store SET name = @name, phone = @phone, address = @address, lead = @lead, remarks = @remarks WHERE id=@id
     "));
                    #endregion

                    #region product
                    sqlCommonds.Add("product", new Command("product", @"INSERT INTO product
           (name
           ,guide_price
           ,remarks
           ,dimensions
           ,color
           ,price
            ,cost_price
           ,market_price)
     VALUES
           (@name
           ,@guide_price
           ,@remarks
           ,@dimensions
           ,@color
           ,@price
           ,@cost_price
           ,@market_price)", @"
UPDATE product
   SET name = @name
      ,guide_price = @guide_price
      ,remarks = @remarks
      ,dimensions = @dimensions
      ,color = @color
      ,price = @price
       ,cost_price =@cost_price
      ,market_price = @market_price
 WHERE id = @id"));
                    #endregion

                    #region sales
                    sqlCommonds.Add("sales", new Command("sales", @"INSERT INTO sales
           (store_id,bill_id
           ,user_id
           ,customer_name
           ,phone
           ,address
           ,remarks
           ,product_count
           ,need_pay
           ,actually_pay
           ,paymet_method1
           ,paymet_method2
           ,status
           ,sapshot
           ,create_time
           ,create_user
           ,modfied_user
           ,modfied_time,delivery_number,delivery_pay,delivery_date,delivery_remarks,front_pay)
     VALUES
           (@store_id,@bill_id
           ,@user_id
           ,@customer_name
           ,@phone
           ,@address
           ,@remarks
           ,@product_count
           ,@need_pay
           ,@actually_pay
           ,@paymet_method1
           ,@paymet_method2
           ,@status
           ,@sapshot
           ,@create_time
           ,@create_user
           ,@modfied_user
           ,@modfied_time,@delivery_number,@delivery_pay,@delivery_date,@delivery_remarks,@front_pay)", @"UPDATE sales
SET
bill_id = @bill_id,
store_id = @store_id,
customer_name = @customer_name,
phone = @phone,
address = @address,
remarks = @remarks,
product_count = @product_count,
need_pay = @need_pay,
front_pay = @front_pay,
actually_pay = @actually_pay,
paymet_method1 = @paymet_method1,
paymet_method2 = @paymet_method2,
status = @status,
modfied_user = @modfied_user,
modfied_time = @modfied_time,
delivery_number = @delivery_number,
delivery_pay = @delivery_pay,
delivery_date = @delivery_date,
delivery_remarks = @delivery_remarks
WHERE id=@id"));

                    #endregion

                    #region salesdetail
                    sqlCommonds.Add("salesdetail", new Command("salesdetail", @"INSERT INTO salesdetail
           (sales_id
           ,product_id
           ,product_name
           ,dimensions
           ,color
           ,count
           ,guide_price
           ,discount
           ,need_pay
           ,actually_pay
           ,paymet_method
           ,margins
           ,cost_price
           ,commission,remarks)
     VALUES
           (@sales_id
           ,@product_id
           ,@product_name
           ,@dimensions
           ,@color
           ,@count
           ,@guide_price
           ,@discount
           ,@need_pay
           ,@actually_pay
           ,@paymet_method
           ,@margins
           ,@cost_price
           ,@commission,@remarks)", @"UPDATE salesdetail
   SET sales_id = @sales_id 
      ,product_id = @product_id
      ,product_name = @product_name
      ,dimensions = @dimensions
      ,color = @color
      ,count = @count
      ,guide_price = @guide_price
      ,discount = @discount
      ,need_pay = @need_pay
      ,actually_pay = @actually_pay
      ,paymet_method = @paymet_method
      ,margins = @margins
      ,cost_price = @cost_price
      ,commission = @commission
      ,remarks =@remarks
 WHERE id=@id"));
                    #endregion

                    #region stock
                    sqlCommonds.Add("stock", new Command("stock", @"
INSERT INTO stock
           (product_id
           ,product_name
           ,dimensions
           ,color
           ,count
           ,saleable_count)
     VALUES
           (@product_id
           ,@product_name
           ,@dimensions
           ,@color
           ,@count
           ,@saleable_count)", @"UPDATE stock
   SET product_id = @product_id
      ,product_name = @product_name
      ,dimensions = @dimensions
      ,color = @color
      ,count = @count
      ,saleable_count = @saleable_count
 WHERE @id=id"));
                    #endregion

                    #region stockdetail
                    sqlCommonds.Add("stockdetail", new Command("stockdetail", @"INSERT INTO stockdetail
           (product_id
           ,product_name
           ,dimensions
           ,color
           ,count
           ,type
           ,create_time,ref_id,complete_time,bill_id,remarks,is_store_out)
     VALUES
           (@product_id
           ,@product_name
           ,@dimensions
           ,@color
           ,@count
           ,@type
           ,@create_time,@ref_id,@complete_time,@bill_id,@remarks,@is_store_out)", @"UPDATE stockdetail
   SET product_id = @product_id
      ,product_name = @product_name
      ,dimensions = @dimensions
      ,color = @color
      ,count = @count
      ,type = @type
      ,create_time = @create_time
,complete_time = @complete_time,bill_id= @bill_id,remarks=@remarks
 WHERE @id =id"));
                    #endregion

                    #region productorder
                    sqlCommonds.Add("productorder", new Command("productorder", @"INSERT INTO `productorder`
(
`product_id`,
`count`,
`remarks`,
`create_time`,
`create_user`,
`modfied_user`,
`modfied_time`,
`status`,
`status_comments`,
`complete_time`,
`order_time`,
`product_name`,
`dimensions`,
`price`,
`color`)
VALUES
(
@product_id,
@count,
@remarks,
@create_time,
@create_user,
@modfied_user,
@modfied_time,
@status,
@status_comments,
@complete_time,
@order_time,
@product_name,
@dimensions,
@price,
@color
)
", @"UPDATE `productorder`
SET
`product_id` = @product_id,
`count` = @count,
`remarks` = @remarks,
`modfied_user` = @modfied_usee,
`modfied_time` = @modfied_time,
`status` = @status,
`status_comments`=@status_comments,
`complete_time` =@complete_time,
`order_time`= @order_time,
`product_name` =@product_name,
`dimensions` =@dimensions,
`color` = @color,
`price` = @price
WHERE id =@id
"));
                    #endregion
 
                    #region productsentback
                    sqlCommonds.Add("productsentback", new Command("productsentback", @"INSERT INTO `productsentback`
(
`product_id`,
`count`,
`remarks`,
`reasons`,
`create_time`,
`create_user`,
`modfied_user`,
`modfied_time`,
`status`,
`status_comments`,
`complete_time`,
`plant_time`,
`product_name`,
`dimensions`,
`color`)
VALUES
(
@product_id,
@count,
@remarks,
@reasons,
@create_time,
@create_user,
@modfied_user,
@modfied_time,
@status,
@status_comments,
@complete_time,
@plant_time,
@product_name,
@dimensions,
@color
)", @"UPDATE `productsentback`
SET
`product_id` = @product_id,
`count` = @count,
`remarks` = @remarks,
`reasons` = @reasons,
`modfied_user` = @modfied_user,
`modfied_time` = @modfied_time,
`status` = @status ,
`status_comments`=@status_comments,
`complete_time` =@complete_time,
`plant_time`= @plant_time,
`product_name` =@product_name,
`dimensions` =@dimensions,
`color` = @color
WHERE @id = id"));
                    #endregion

                    #region storestock
                    sqlCommonds.Add("storestock", new Command("storestock", @"
INSERT INTO storestock
           (product_id
           ,product_name
           ,dimensions
           ,color
           ,count
           ,saleable_count,store_id,remarks)
     VALUES
           (@product_id
           ,@product_name
           ,@dimensions
           ,@color
           ,@count
           ,@saleable_count,@store_id,@remarks)", @"UPDATE storestock
   SET product_id = @product_id
      ,product_name = @product_name
      ,dimensions = @dimensions
      ,color = @color
      ,count = @count
      ,saleable_count = @saleable_count
      ,store_id = @store_id
      ,remarks =@remarks
 WHERE @id=id"));
                    #endregion

                    #region storestockdetail
                    sqlCommonds.Add("storestockdetail", new Command("storestockdetail", @"INSERT INTO storestockdetail
           (product_id
           ,product_name
           ,dimensions
           ,color
           ,count
           ,type
           ,create_time,store_id,remarks,complete_time,out_type)
     VALUES
           (@product_id
           ,@product_name
           ,@dimensions
           ,@color
           ,@count
           ,@type
           ,@create_time,@store_id,@remarks,@complete_time,@out_type)", @"UPDATE storestockdetail
   SET product_id = @product_id
      ,product_name = @product_name
      ,dimensions = @dimensions
      ,color = @color
      ,count = @count
      ,type = @type
      ,store_id = @store_id
      ,create_time = @create_time
       ,remarks =@remarks
,complete_time =@complete_time
 WHERE @id =id"));
                    #endregion
                }

                return ((Command)sqlCommonds[tablename]).GetByType(type);
            }

            public DbCommand GetByType(Type type)
            {
                switch (type)
                {
                    case Type.Insert:
                        return insertCommond;
                    case Type.Update:
                        return updateCommond;
                    case Type.Delete:
                        return deleteCommond;
                }
                return null;
            }
            private string __tablename;
            public Command(string tablename, string insertSql, string updateSql)
            {
                this.__tablename = tablename;
                this.insertCommond = InitSQL(insertSql);
                this.insertCommond.CommandText = this.insertCommond.CommandText + ";SELECT LAST_INSERT_ID() ; ";
                this.updateCommond = InitSQL(updateSql);
                this.deleteCommond = db.GetSqlStringCommand("delete from " + tablename + "where id=@id");
                this.deleteCommond.Connection = db.CreateConnection();
                db.AddInParameter(this.deleteCommond, "@id", DbType.Int16);
            }
            private DbCommand InitSQL(string sql)
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                cmd.Connection = db.CreateConnection();
                GetParam(sql, cmd);
                return cmd;
            }

            private static List<string> ParseParameters(string sql)
            {
                List<string> result = new List<string>();
                Regex paramReg = new Regex(@"[^@@](?<p>@\w+)");
                MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));
                foreach (Match m in matches)
                    result.Add(m.Groups["p"].Value);
                return result;
            }
            private static void GetParam(string sql, DbCommand cmd)
            {
                foreach (string p in ParseParameters(sql))
                {
                    db.AddInParameter(cmd, p, DbType.String, p.Substring(1), DataRowVersion.Current);
                }
            }
        }
        #endregion

        #region  Add DataRow
        public static void Add(DataRow dr)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand cmd = Command.GetDbCommand(dr.Table.TableName, Type.Insert);
                cmd.Connection = conn;
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    var obj = dr[parameter.SourceColumn];
                    parameter.DbType = getDbType(obj);
                    parameter.Value = obj;
                    if (parameter.Value is string)
                    {
                        parameter.Value = (parameter.Value as string).Trim();
                    }
                }
                cmd.ExecuteNonQuery();
            }
        }
        public static void Add(DataRow dr, DbConnection conn, DbTransaction tran)
        {

            DbCommand cmd = Command.GetDbCommand(dr.Table.TableName, Type.Insert);
            cmd.Transaction = tran;
            cmd.Connection = conn;
            foreach (IDataParameter parameter in cmd.Parameters)
            {
                var obj = dr[parameter.SourceColumn];
                parameter.DbType = getDbType(obj);
                parameter.Value = obj ;
                if (parameter.Value is string)
                {
                    parameter.Value = (parameter.Value as string).Trim();
                }
            }
            cmd.ExecuteNonQuery();

        }
        public static void Add(DataRow[] drs)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();

                DbCommand cmd = Command.GetDbCommand(drs[0].Table.TableName, Type.Insert);
                foreach (DataRow dr in drs)
                {
                    cmd.Connection = conn;
                    foreach (IDataParameter parameter in cmd.Parameters)
                    {
                        var obj = dr[parameter.SourceColumn];
                        parameter.Value = dr[parameter.SourceColumn];
                        if (parameter.Value is string)
                        {
                            parameter.Value = (parameter.Value as string).Trim();
                        }
                        parameter.DbType = getDbType(obj);
                    }
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
        }
        public static void Add(DataRow[] drs, DbConnection conn, DbTransaction tran)
        {


            DbCommand cmd = Command.GetDbCommand(drs[0].Table.TableName, Type.Insert);
            foreach (DataRow dr in drs)
            {
                cmd.Connection = conn;
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    var obj = dr[parameter.SourceColumn];
                    parameter.Value = dr[parameter.SourceColumn];
                    if (parameter.Value is string)
                    {
                        parameter.Value = (parameter.Value as string).Trim();
                    }
                    parameter.DbType = getDbType(obj);
                }
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


        public static int Add(string tablename, DictionaryEntry[] valuse)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Insert);
                cmd.Connection = conn;
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    foreach (DictionaryEntry de in valuse)
                    {
                        if ("@" + de.Key == parameter.ParameterName)
                        {
                            parameter.Value = de.Value;
                            if (parameter.Value is string)
                            {
                                parameter.Value = (parameter.Value as string).Trim();
                            }
                            parameter.DbType = getDbType(de.Value);
                        }
                    }
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int Add(string tablename, DictionaryEntry[] valuse, DbConnection conn, DbTransaction tran)
        {
            DbCommand cmd = Command.GetDbCommand(tablename, Type.Insert);
            cmd.Connection = conn;
            cmd.Transaction = tran;
            foreach (IDataParameter parameter in cmd.Parameters)
            {
                foreach (DictionaryEntry de in valuse)
                {
                    if ("@" + de.Key == parameter.ParameterName)
                    {
                        parameter.Value = de.Value;
                        if (parameter.Value is string)
                        {
                            parameter.Value = (parameter.Value as string).Trim();
                        }
                        parameter.DbType = getDbType(de.Value);
                    }

                }
            }
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static int Add(string tablename, IEnumerable<DictionaryEntry> list)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Insert);
                cmd.Connection = conn;
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    foreach (DictionaryEntry de in list)
                    {
                        if ("@" + de.Key == parameter.ParameterName)
                        {
                            parameter.Value = de.Value;
                            if (parameter.Value is string)
                            {
                                parameter.Value = (parameter.Value as string).Trim();
                            }
                            parameter.DbType = getDbType(de.Value);
                        }
                    }
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
     
        public static void Add(string tablename, GridViewRowInfo[] drs)
        {

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();


                DbCommand cmd = Command.GetDbCommand(tablename, Type.Insert);
                foreach (GridViewRowInfo dr in drs)
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    foreach (IDataParameter parameter in cmd.Parameters)
                    {
                        var obj = dr.Cells[parameter.SourceColumn].Value;
                        if (obj is string) {
                            obj = (obj as string).Trim();
                        }
                        parameter.Value = obj;
                        parameter.DbType = getDbType(obj);
                    }
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
        }
        public static void Add(string tableName, IEnumerable<GridViewRowInfo> enumerable)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                DbCommand cmd = Command.GetDbCommand(tableName, Type.Insert);
                cmd.Transaction = tran;
                cmd.Connection = conn;
                foreach (GridViewRowInfo dr in enumerable)
                {

                    foreach (IDataParameter parameter in cmd.Parameters)
                    {
                        try
                        {
                            var obj = dr.Cells[parameter.SourceColumn].Value;
                            if (obj is string)
                            {
                                obj = (obj as string).Trim();
                            }
                            parameter.Value = obj;
                        }
                        catch (Exception e)
                        {
                            log.Warn("添加错误", e);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
        }
        public static void Add(string tableName, IEnumerable<GridViewRowInfo> enumerable, DbConnection conn, DbTransaction tran)
        {

            DbCommand cmd = Command.GetDbCommand(tableName, Type.Insert);
            cmd.Transaction = tran;
            cmd.Connection = conn;
            foreach (GridViewRowInfo dr in enumerable)
            {

                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    try
                    {
                        var obj = dr.Cells[parameter.SourceColumn].Value;
                        if (obj is string)
                        {
                            obj = (obj as string).Trim();
                        }
                        parameter.Value = obj;
                    }
                    catch (Exception e) {
                        log.Warn("添加错误2", e);
                    }
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(string tablename, IEnumerable<GridViewRowInfo> enumerable)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);
                foreach (GridViewRowInfo dr in enumerable)
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    foreach (IDataParameter parameter in cmd.Parameters)
                    {
                        parameter.Value = dr.Cells[parameter.SourceColumn].Value;
                        if (parameter.Value is string) {
                            parameter.Value = (parameter.Value as string).Trim();
                        }
                        parameter.DbType = getDbType(parameter.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
        }
        public static void Update(string tablename, GridViewRowInfo dr)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);

                cmd.Connection = conn;
                cmd.Transaction = tran;
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    parameter.Value = dr.Cells[parameter.SourceColumn].Value;
                    if (parameter.Value is string)
                    {
                        parameter.Value = (parameter.Value as string).Trim();
                    }
                    parameter.DbType = getDbType(parameter.Value);
                }
                cmd.ExecuteNonQuery();

                tran.Commit();
            }
        }
        public static void Update(string tablename, IEnumerable<GridViewRowInfo> enumerable, DbConnection conn, DbTransaction tran)
        {
           
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);
                foreach (GridViewRowInfo dr in enumerable)
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    foreach (IDataParameter parameter in cmd.Parameters)
                    {
                        parameter.Value = dr.Cells[parameter.SourceColumn].Value;
                        if (parameter.Value is string)
                        {
                            parameter.Value = (parameter.Value as string).Trim();
                        }
                        parameter.DbType = getDbType(parameter.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
        }
        public static int Update(string tablename, DictionaryEntry[] valuse, DbConnection conn, DbTransaction tran)
        {
            DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);
            cmd.Connection = conn;
            cmd.Transaction = tran;
            foreach (IDataParameter parameter in cmd.Parameters)
            {
                foreach (DictionaryEntry de in valuse)
                {
                    if ("@" + de.Key == parameter.ParameterName)
                    {
                        parameter.Value = de.Value;
                        if (parameter.Value is string)
                        {
                            parameter.Value = (parameter.Value as string).Trim();
                        }
                        parameter.DbType = getDbType(de.Value);
                    }

                }
            }
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        internal static void Update(string tablename, List<DictionaryEntry> list)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    foreach (DictionaryEntry de in list)
                    {
                        if ("@" + de.Key == parameter.ParameterName)
                        {
                            parameter.Value = de.Value;
                            if (parameter.Value is string)
                            {
                                parameter.Value = (parameter.Value as string).Trim();
                            }
                            parameter.DbType = getDbType(de.Value);
                        }

                    }
                }
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(string tablename, int pk)
        {
            DbCommand cmd = db.GetSqlStringCommand("delete from " + tablename + "  where id = @id");
            db.AddInParameter(cmd, "@id", DbType.Int16, pk);
            db.ExecuteNonQuery(cmd);
        }

        public static void Delete(string tablename, int pk, DbConnection conn, DbTransaction tran)
        {
            DbCommand cmd = db.GetSqlStringCommand("delete from " + tablename + "  where id = @id");
            cmd.Connection = conn;
            cmd.Transaction = tran;
            db.AddInParameter(cmd, "@id", DbType.Int16, pk);
            db.ExecuteNonQuery(cmd);
        }


        public enum Type
        {
            Insert,
            Update,
            Delete
        }
        private static DbType getDbType(object val)
        {
            if (val == null) return DbType.String;
            switch (val.GetType().Name.ToLower())
            {
                case "int":
                case "int16":
                case "int32":
                case "int64":
                case "uint64":
                case "uint32":
                case "uint16":
                case "long":
                case "short":
                    return DbType.Int64;
                case "float":
                case "double":
                    return DbType.Decimal;
                case "datetime":
                    return DbType.DateTime;
                case "byte[]":
                    return DbType.Binary;
                default:
                    return DbType.String;
            }

        }

        internal static void Update(string tablename, GridViewRowInfo dr, DbConnection conn, DbTransaction tran)
        {

            DbCommand cmd = Command.GetDbCommand(tablename, Type.Update);

            cmd.Connection = conn;
            cmd.Transaction = tran;
            foreach (IDataParameter parameter in cmd.Parameters)
            {
                parameter.Value = dr.Cells[parameter.SourceColumn].Value;
                if (parameter.Value is string)
                {
                    parameter.Value = (parameter.Value as string).Trim();
                }
                parameter.DbType = getDbType(parameter.Value);
            }
            cmd.ExecuteNonQuery();

        }
    }
}
