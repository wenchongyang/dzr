using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
namespace ERP
{
    public partial class 用户管理 : GridForm
    {
        public 用户管理()
        {
            InitializeComponent();

            ((GridViewComboBoxColumn)this.radGridView1.Columns[3]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.Gender), "key", "val",false);
            ((GridViewComboBoxColumn)this.radGridView1.Columns[4]).DataSource = DataUtil.BindData("roles", null, null);
            ((GridViewComboBoxColumn)this.radGridView1.Columns[6]).DataSource = DataUtil.BindData("store", null, null);

            this.storeCbx.DataSource = DataUtil.BindComboBoxData("store", null, null);
            this.storeCbx.ValueMember = "id";
            this.storeCbx.DisplayMember = "name";

            InitGrid(this.radGridView1, "users");

            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                addBtn.Visible = false;
                this.radGridView1.Columns["delete"].IsVisible = this.radGridView1.Columns["edit"].IsVisible = this.radGridView1.Columns["resetPwd"].IsVisible = false;                 
            }
        }

        protected override bool Adding(GridViewRowInfo[] dr)
        {
            return CheckSame(dr);
        }
        protected override bool Updateing(GridViewRowInfo dr)
        {
            return CheckSame(null);
        }

        private bool CheckSame(GridViewRowInfo[] newRow)
        {
            Hashtable k = new Hashtable();
            bool same = false;



            foreach (var dr in this.radGridView1.Rows)
            {

                string key = "" + dr.Cells["username"].Value;
                if (!k.ContainsKey(key))
                {
                    k.Add(key, null);
                }
                else
                {
                    same = true;
                }

            }
            if (null != newRow)
                foreach (var dr in newRow)
                {

                    string key = "" + dr.Cells["username"].Value;
                    if (!k.ContainsKey(key))
                    {
                        k.Add(key, null);
                    }
                    else
                    {
                        same = true;
                    }

                }
            if (same)
            {
                MessageBox.Show("有重复用户名！请核对");
            }
            return !same;
        }
        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {
            whereStr = string.Empty;
            List<DictionaryEntry> list = new List<DictionaryEntry>();

            if (!String.IsNullOrWhiteSpace(userNameTbx.Text))
            {
                whereStr += " and username like @username";
                list.Add(new DictionaryEntry("username", "%" + userNameTbx.Text + "%"));
            }
            if (!String.IsNullOrWhiteSpace(nameTbx.Text))
            {
                whereStr += " and name like @name";
                list.Add(new DictionaryEntry("name", "%" + nameTbx.Text + "%"));
            }
            if (!this.storeCbx.SelectedValue.Equals(-1)) {
                whereStr += " and store_id =  @store_id";
                list.Add(new DictionaryEntry("store_id",this.storeCbx.SelectedValue));
            }
            return list.ToArray();
        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "resetPwd")
            {
                var id = (int)el.Value;
                DataUtil.ExecuteNonQuery("update users set password ='88888888' where id = " + id);
                MessageBox.Show("重置密码成功！");
            }
            else if (el.Data.Name == "delete")
            {
                var id = (int)el.Value;
                DataUtil.Delete("users", id);
                this.BindData();
            }
            else if (el.Data.Name == "edit") {

                el.RowInfo.Cells[1].BeginEdit();
            }
        }

        private void radGridView1_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "join_date" && e.Value == DBNull.Value)
            {
                e.Row.Cells[e.Column.Name].Value = DateTime.Now;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //this.radGridView1.AllowAddNewRow = false;
            //(new 用户()).ShowDialog();
        }
        private void updataInfo() {
           // DataUtil.ExecuteNonQuery("update store set lead = (select  name from users where users.store_id = store.id and role_id = 4 limit 1)");
            ERP.Data.DataUtil.LoadUsers();
        }
        protected override void AddComplete(GridViewRowInfo[] drs)
        {
            updataInfo();
        }

        protected override void UpdateComplete(GridViewRowInfo dr)
        {
            updataInfo();
        }
        protected override bool GetNotNullColumn(GridViewCellInfo cell)
        {
            return cell.ColumnInfo.IsVisible && !cell.ColumnInfo.ReadOnly &&
                cell.ColumnInfo.Name != "remarks" && cell.ColumnInfo.Name != "salary"
                &&  cell.ColumnInfo.Name != "store_id" ;
        }
    }
}
