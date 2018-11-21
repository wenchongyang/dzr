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
    public partial class 门店库存报表: GridForm
    {
        public 门店库存报表()
        {
            InitializeComponent();
            UsersDal.BindStore(storeCbx, true,true);
            ((GridViewComboBoxColumn)this.radGridView1.Columns["store_id"]).DataSource = Data.DataUtil.StoreTable;
            InitGrid(this.radGridView1, "storestock", true);
            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                this.radGridView1.Columns["out"].IsVisible = this.radGridView1.Columns["in"].IsVisible = false;
            }
        }

        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = "";
            List<DictionaryEntry> list = new List<DictionaryEntry>();

            if (!this.storeCbx.SelectedValue.Equals(-1))
            {
                list.Add(new DictionaryEntry("store_id", this.storeCbx.SelectedValue));
                whereStr += " and store_id = @store_id";
            }
            getPorductSearch(list, ref whereStr, product_nameDdl, colorDdl, dimensionsDdl,false);
            return list.ToArray();

        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
             GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
             if (el.Data.Name == "out")
             {
                 门店出入库 f = new 门店出入库();
                 f.ProductId = (int)el.Value;
                 f.FormType = 门店出入库.Type.出库;
                 f.StoreId = (int)el.RowInfo.Cells["store_id"].Value;
                 f.ShowDialog();
                 if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                 {
                     this.BindData();
                 }
             }
             else {
                 门店出入库 f = new 门店出入库();
                 f.ProductId = (int)el.Value;
                 f.FormType = 门店出入库.Type.入库;
                 f.StoreId = (int)el.RowInfo.Cells["store_id"].Value;
                 f.ShowDialog();
                 if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                 {
                     this.BindData();
                 }
             }
        }

    }
}
