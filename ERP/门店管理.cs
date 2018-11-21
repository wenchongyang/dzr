using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace ERP
{
    public partial class 门店管理 : GridForm
    {
        public 门店管理()
        {
            InitializeComponent();
            InitGrid(this.radGridView1, "store");
            ((GridViewComboBoxColumn)this.radGridView1.Columns["lead"]).DataSource = Data.DataUtil.ExecuteDataSet("select * from users where role_id  = 4;").Tables[0];
        }

        private void 门店管理_Load(object sender, EventArgs e)
        {
            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                addBtn.Visible = false;
                this.radGridView1.Columns["delete"].IsVisible = this.radGridView1.Columns["edit"].IsVisible = false;
            }
        }
        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {
            whereStr = string.Empty;
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            if (!String.IsNullOrWhiteSpace(storeTbx.Text))
            {
                whereStr += " and name like @name";
                list.Add(new DictionaryEntry("name", "%"+storeTbx.Text+"%"));
            }
            if (!String.IsNullOrWhiteSpace(addressTbx.Text))
            {
                whereStr += " and address like @address";
                list.Add(new DictionaryEntry("address", "%" + addressTbx.Text + "%"));
            }
            if (!String.IsNullOrWhiteSpace(leadTbx.Text))
            {
                whereStr += " and lead like @lead";
                list.Add(new DictionaryEntry("lead", "%" + leadTbx.Text + "%"));
            }
            return list.ToArray();
        }
        protected override bool GetNotNullColumn(GridViewCellInfo cell)
        {
            return cell.ColumnInfo.IsVisible && !cell.ColumnInfo.ReadOnly &&
                cell.ColumnInfo.Name != "remarks";
        }
        protected override void AddComplete(GridViewRowInfo[] drs)
        {
            updataInfo();
        }

        private void updataInfo()
        {
            DataUtil.LoadStore();
        }

        protected override void UpdateComplete(GridViewRowInfo dr)
        {
            updataInfo();
        }

        private void MasterTemplate_CommandCellClick(object sender, EventArgs e)
        {

            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "edit") {
                this.radGridView1.Rows[el.RowIndex].Cells[1].BeginEdit();
               
            }
                if(el.Data.Name =="delete"){
                    int id = (int)el.Value;
                    DataUtil.Delete("store", id);
                    this.BindData();
                }
        }
    }
}
