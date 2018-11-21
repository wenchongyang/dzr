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
    public partial class 返厂明细 : GridForm
    {
        public 返厂明细()
        {
            InitializeComponent();
            DataUtil.BindEnum2(statusCbx, typeof(DataUtil.BackStatus), true);
            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.BackStatus), true);

            if (UsersDal.CurUser.UserRole == UsersDal.Role.仓管) {
                this.radGridView1.Columns["operate"].IsVisible = false;
            }

            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                this.radGridView1.Columns["complete"].IsVisible = this.radGridView1.Columns["operate"].IsVisible = false;
            }

            InitGrid(this.radGridView1, "productsentback", true);
        }
        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            List<DictionaryEntry> list = new List<DictionaryEntry>();
            whereStr = " and  create_time >=@s_rq and create_time<=@e_rq ";
            list.Add(new DictionaryEntry("s_rq", this.dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            DateTime endDate = this.dateTimePicker2.Value;
            list.Add(new DictionaryEntry("e_rq", this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"));

            getPorductSearch(list, ref whereStr, product_nameDdl, colorDdl, dimensionsDdl, false);
            return list.ToArray();

        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "complete")
            {
                ProductDal.Return((int)el.Value);
                this.BindData();
            }
            else if (el.Data.Name == "operate")
            {
                返厂 f = new 返厂();
                f.Id = (int)el.Value;
                f.ShowDialog();
                if(f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    this.BindData();
            }

        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            DateTime create_time = Convert.ToDateTime(e.Row.Cells["create_time"].Value);
            int status = (int)e.Row.Cells["status"].Value;

            if (e.Column.Name == "complete")
            {
                e.CellElement.Enabled = (status == (int)Data.DataUtil.BackStatus.已返厂);
            }
            if (e.Column.Name == "operate")
            {
                e.CellElement.Enabled = (status == (int)Data.DataUtil.BackStatus.待处理) && ((UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员 &&
                create_time.Date == DataUtil.Now.Date
                ) || UsersDal.CurUser.UserRole == UsersDal.Role.超级管理员);
            }
        }
    }
}
