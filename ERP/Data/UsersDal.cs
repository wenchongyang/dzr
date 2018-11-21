using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ERP.Data
{

    public class UsersDal
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(UsersDal));
        public string UserName { protected set; get; }
        public string RoleName { protected set; get; }
        public string Name { protected set; get; }
        public int UserId { get; protected set; }

        public int DefStoreId {
            get {
                if (string.IsNullOrWhiteSpace(Stores)) {
                    return -1;
                }
                var l = Stores.Split(',')[0];
                int id = -1;
                int.TryParse(l, out id);
                return id;
            }
        }
        public String Stores { get;set; }


        public static bool inStore(string id) {
            return ("," + curUser.Stores + ",").Contains("," + id + ",");
        }
        private static UsersDal curUser = null;
        public static UsersDal CurUser
        {
            get
            {
                return curUser;
            }
        }
        private static void SetUser(string username)
        {
            DataRow dr = DataUtil.ExecuteDataSet(@"SELECT users.*,GROUP_CONCAT(store.id  SEPARATOR ',' ) stores,users.store_id,
      roles.id AS role_id, roles.name AS role_name
FROM users INNER JOIN
      roles ON users.role_id = roles.id LEFT JOIN
      store ON users.id = store.lead  where users.username = '" + username + "'").Tables[0].Rows[0];

            var store = dr["store_id"] == DBNull.Value || dr["store_id"] == null ?"":dr["store_id"].ToString();
            String stores  ="";
            if(dr["stores"] != DBNull.Value && dr["stores"] != null){
                if (dr["stores"] is byte[]) {
                    stores = System.Text.Encoding.UTF8.GetString((byte[])dr["stores"]);
                }else{
                    stores = Convert.ToString(dr["stores"]);
                }
            }

            if (stores.Length > 0 && store.Length > 0 )
            {
                if(!("," + stores + ",").Contains("," + store + ","))
                    stores += "," + store;
            }
            else if (stores.Length == 0 && store.Length > 0)
            {
                stores = store;
            }
            curUser = new UsersDal()
            {
                UserName = (string)dr["username"],
                Name = (string)dr["name"],
                UserId = (int)dr["id"],
                RoleName = (string)dr["role_name"],
                Stores = stores,
                //StoreId = dr["store_id"] == null || dr["store_id"] == DBNull.Value ? 0 : (int)dr["store_id"]
            };
        }
        public static bool CheckVersion()
        {
            DataSet ds = DataUtil.ExecuteDataSet("select * from erp_version where version = '" + DataUtil .Version+ "'");
            return ds.Tables[0].Rows.Count > 0;
            
        }
         
        public static bool Login(string username, string pwd)
        {
            DataSet ds = DataUtil.ExecuteDataSet("select count(1) from users where username =@username and( password=@password)",
                 new System.Collections.DictionaryEntry[]{
                    new  DictionaryEntry("username",username),
                    new  DictionaryEntry("password",pwd),
                });

            bool login = Convert.ToInt32(ds.Tables[0].Rows[0][0]) != 0;
            if (login)
            {
                SetUser(username);
                
                ERP.Data.DataUtil.LoadProduct();
                ERP.Data.DataUtil.LoadStore();
                ERP.Data.DataUtil.LoadUsers();
            }

            return login;
        }
        public static bool ChangePwd(string oldPwd, string newPwd)
        {
            String pwd = (String)DataUtil.ExecuteScalar("select password from users where id =" + curUser.UserId + ";");
            if (pwd != oldPwd)
            {
                return false;
            }
            else
            {
                DataUtil.ExecuteNonQuery("update users set password = @password where id =" + curUser.UserId, new DictionaryEntry[]{
                    new DictionaryEntry("password",newPwd)
                });
                return true;
            }
        }

        public enum Role
        {
            超级管理员,
            总经理,
            财务,
            店长,
            导购,
            仓管,
        }
        public static void BindStore(ComboBox storeCbx, bool showAll,bool limited)
        {
            
            bool hasAll = true;
            string where = "1=1";
            if (limited)
            {
              
                if (UsersDal.CurUser.UserRole == UsersDal.Role.店长
                    || UsersDal.CurUser.UserRole == UsersDal.Role.导购
                    )
                {
                    if (string.IsNullOrWhiteSpace(UsersDal.CurUser.Stores)) {
                        MessageBox.Show("该用户没有属于任何店铺，请马上联系管理员！！！");
                        return;
                    }
                    where += " and id in (" + UsersDal.CurUser.Stores+")";
                    hasAll = false;
                }
                
            }
            
          
            DataTable drs = DataUtil.StoreTable.Clone();
            drs.Clear();
            foreach (DataRow dr in (DataUtil.StoreTable.Select(where)))
            {
                drs.ImportRow(dr);
            }

            if (hasAll && showAll)
            {
                var dr = drs.NewRow();
                dr["id"] = -1;
                dr["name"] = "--全部--";
                drs.Rows.InsertAt(dr, 0);
            }

            storeCbx.DataSource = drs;
            storeCbx.ValueMember = "id";
            storeCbx.DisplayMember = "name";
            if (UsersDal.CurUser.DefStoreId != -1)
             storeCbx.SelectedValue = curUser.DefStoreId;

            if (curUser.UserRole == Role.店长 || UsersDal.CurUser.UserRole == UsersDal.Role.导购)
            {
                storeCbx.SelectedIndexChanged += storeCbx_SelectedIndexChanged;
                storeCbx_SelectedIndexChanged(storeCbx, null);
            }
            
        }
        public static void BindStoreAndUser(ComboBox storeCbx, ComboBox userCbx)
        {
            string where = "";
            bool hasAll = true;
            BindStore(storeCbx, true,false);
      
            DataTable drs = DataUtil.UsersTable.Clone();
            hasAll = true;
            where = "1 = 1";
            //where = " (role_id = 5 or role_id = 4) ";
            if (UsersDal.CurUser.UserRole == UsersDal.Role.店长 || UsersDal.CurUser.UserRole == UsersDal.Role.导购 
               )
            {
                //where += " and store_id in (" + UsersDal.CurUser.Stores+")";
            }
            else if ( UsersDal.Role.仓管 == UsersDal.CurUser.UserRole)
            {
                where += " and id = " + UsersDal.CurUser.UserId;
                hasAll = false;
            }
            foreach (DataRow dr in (DataUtil.UsersTable.Select(where)))
            {
                drs.ImportRow(dr);
            }
            if (hasAll)
            {
                var dr = drs.NewRow();
                dr["id"] = -1;
                dr["name"] = "--全部--";
                drs.Rows.InsertAt(dr, 0);
            }
            userCbx.DataSource = drs;
            userCbx.ValueMember = "id";
            userCbx.DisplayMember = "name";

        }

        private static void storeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox storeCbx = (ComboBox)sender;
            try
            {
                ComboBox userCbx = (ComboBox)storeCbx.Parent.Controls.Find("userCbx", false)[0];
                DataTable drs = DataUtil.UsersTable.Clone();

                string where = "1 = 1";
                    //" store_id in (" + curUser.Stores+")";
                bool hasAll = true;
                if (!(","+curUser.Stores+",").Contains(","+storeCbx.SelectedValue.ToString()+","))
                {
                    where += " and id = " + curUser.UserId;
                    if (!storeCbx.SelectedValue.Equals(-1))
                    {
                        hasAll = false;
                    }
                }

                foreach (DataRow dr in (DataUtil.UsersTable.Select(where)))
                {
                    drs.ImportRow(dr);
                }
                if (hasAll)
                {
                    var dr2 = drs.NewRow();
                    dr2["id"] = -1;
                    dr2["name"] = "--全部--";
                    drs.Rows.InsertAt(dr2, 0);
                }
                userCbx.DataSource = drs;
                userCbx.ValueMember = "id";
                userCbx.DisplayMember = "name";

            }
            catch { }

        }

        public Role UserRole
        {
            get { return (Role)Enum.Parse(typeof(Role), RoleName); }
        }
    }
}
