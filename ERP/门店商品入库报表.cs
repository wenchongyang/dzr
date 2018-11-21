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
    public partial class 门店商品入库报表 : GridForm
    {
        public 门店商品入库报表()
        {
            InitializeComponent();
            UsersDal.BindStore(storeCbx, true,true);

            ((GridViewComboBoxColumn)this.radGridView1.Columns["store_id"]).DataSource = Data.DataUtil.StoreTable;
            InitGrid(this.radGridView1, "storestockdetail",true);
            if (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员) {
                this.radGridView1.Columns["del"].IsVisible = this.radGridView1.Columns["edit"].IsVisible = false;
            }

        }

        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = " and  complete_time >=@s_rq and complete_time<=@e_rq  and type = 0 ";
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry("s_rq",this.dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            DateTime endDate  = this.dateTimePicker2.Value;
            list.Add(new DictionaryEntry("e_rq", this.dateTimePicker2.Value.ToString("yyyy-MM-dd")+" 23:59:59"));
            if (isAllOrNull(this.product_nameDdl))
            {
                list.Add(new DictionaryEntry("product_name", this.product_nameDdl.SelectedValue));
                whereStr += " and product_name = @product_name";
            }
            if (!this.storeCbx.SelectedValue.Equals(-1)) {
                list.Add(new DictionaryEntry("store_id", this.storeCbx.SelectedValue));
                whereStr += " and store_id = @store_id";
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

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.Name == "count") {
                e.CellElement.Value = Math.Abs((int)e.CellElement.Value);
            }
        }
        StockDal dal = new StockDal();
        private void MasterTemplate_CommandCellClick(object sender, EventArgs e)
        {
            
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);

            if (el.Data.Name == "edit")
            {
                门店出入库 f = new 门店出入库();
                var row = this.radGridView1.Rows[el.RowIndex];
                f.Id = (int)el.Value;
                f.FormType = 门店出入库.Type.入库;
                f.StoreId = (int)row.Cells["store_id"].Value;
                f.ProductId = (int)row.Cells["product_id"].Value;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.BindData();
                }
            }
            else {
                if (MessageBox.Show("是否需要删除", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    dal.DeleteStoreStock((int)el.Value);
                    this.BindData();
                }
            }

        }

    }
}
