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
    public partial class 商品入库报表 : GridForm
    {
        public 商品入库报表()
        {
            InitializeComponent();
            InitGrid(this.radGridView1, "stockdetail",true);

            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.StockStatus), "key", "val", false);

            if (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员) {
                this.radGridView1.Columns["cal"].IsVisible = this.radGridView1.Columns["del"].IsVisible = false;
            }

        }

        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = " and  complete_time >=@s_rq and complete_time<=@e_rq and type  = 0";
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry("s_rq",this.dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            DateTime endDate  = this.dateTimePicker2.Value;
            list.Add(new DictionaryEntry("e_rq", this.dateTimePicker2.Value.ToString("yyyy-MM-dd")+" 23:59:59"));
            if (isAllOrNull(this.product_nameDdl))
            {
                list.Add(new DictionaryEntry("product_name", this.product_nameDdl.SelectedValue));
                whereStr += " and product_name = @product_name";
            }
            if (isAllOrNull(this.colorDdl))
            {
                list.Add(new DictionaryEntry("color", this.colorDdl.SelectedValue));
                whereStr += " and color = @color";
            }
            if (isAllOrNull(this.dimensionsDdl))
            {
                list.Add(new DictionaryEntry("dimensions", this.dimensionsDdl.SelectedValue));
                whereStr += " and dimensions = @dimensions";
            }


            return list.ToArray();

        }

        private void MasterTemplate_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            StockDal stockDal = new StockDal();
            if (el.Data.Name == "cal")
            {
                if (MessageBox.Show("是否需要撤销", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    stockDal.Cancel((int)el.Value);
                }
            }
            if (el.Data.Name == "del")
            {
                if (MessageBox.Show("是否需要删除", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    stockDal.Delete((int)el.Value);
                }
            }
            if (el.Data.Name == "edit")
            {
                商品出入库 f = new 商品出入库();
                f.Id = (int)el.Value;
                f.ProductId =  (int)el.RowInfo.Cells["product_id"].Value;
                f.FormType = 商品出入库.Type.入库;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    this.BindData();
                } return;
            }
            this.BindData();
        }

        private void MasterTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            int status = Convert.ToInt32(e.Row.Cells["status"].Value);
            int is_store_out = e.Row.Cells["is_store_out"] == null || DBNull.Value.Equals(e.Row.Cells["is_store_out"]) ? 0 : Convert.ToInt32(e.Row.Cells["is_store_out"].Value);
            if (e.Column.Name == "cal" || e.Column.Name == "del" || e.Column.Name == "edit")
            {
                GridCommandCellElement commandCell = (GridCommandCellElement)e.CellElement;
                RadButtonElement buttonElement = (RadButtonElement)commandCell.Children[0];

                DateTime create_time = Convert.ToDateTime(e.Row.Cells["complete_time"].Value);

                buttonElement.Enabled = (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员 && create_time.Date == DataUtil.Now.Date)
                    || UsersDal.CurUser.UserRole == UsersDal.Role.超级管理员;

                if (status == (int)DataUtil.StockStatus.正常 && 1!=is_store_out)
                {
                    buttonElement.Enabled = buttonElement.Enabled  && true;
                }
                else
                {
                    buttonElement.Enabled = false;
                }

            }
        }

    }
}
