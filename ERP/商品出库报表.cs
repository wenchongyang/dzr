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
    public partial class 商品出库报表 : GridForm
    {
        public 商品出库报表()
        {
            InitializeComponent();
            InitGrid(this.radGridView1, "v_stockdetail", true);
            ((GridViewComboBoxColumn)this.radGridView1.Columns["store_id"]).DataSource = Data.DataUtil.StoreTable;
            ((GridViewComboBoxColumn)this.radGridView1.Columns["is_store_out"]).DataSource = Data.DataUtil.Enum2DataTable(typeof(ERP.Data.StockDal.OutTypeName2), false);
            UsersDal.BindStore(storeCbx, true, true);

        }

        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = " and  create_time >=@s_rq and create_time<=@e_rq ";
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
            if (null!= this.storeCbx.SelectedValue && !(-1).Equals(this.storeCbx.SelectedValue))
            {
                whereStr += " and store_id = " + this.storeCbx.SelectedValue;
            }


            return list.ToArray();

        }

    }
}
