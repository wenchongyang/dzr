using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ERP
{
    public partial class 待送详情 : Telerik.WinControls.UI.RadForm
    {
        public 待送详情()
        {
            InitializeComponent();
            this.nameTbx.Enabled = this.dimensionsTbx.Enabled = this.colorTbx.Enabled = this.countTbx.Enabled = false;
            ((GridViewComboBoxColumn)this.radGridView1.Columns["store_id"]).DataSource = Data.DataUtil.StoreTable;
        }

        public int ProductId { get; set; }

        private void 待送详情_Load(object sender, EventArgs e)
        {
            if (ProductId != 0)
            {
                DataRow[] drs = Data.DataUtil.ProductTableWithOutAll.Select("id = " + ProductId);
                if (drs.Length > 0)
                {
                    DataRow dr = drs[0];
                    this.nameTbx.Text = Convert.ToString(dr["name"]);
                    this.dimensionsTbx.Text = Convert.ToString(dr["dimensions"]);
                    this.colorTbx.Text = Convert.ToString(dr["color"]);
                }
            }
            DataTable dt = Data.DataUtil.ExecuteDataSet(@"select salesdetail.count-ifnull(sum(abs(stockdetail.count)),0)  count,sales.bill_id,sales.store_id,sales.delivery_date from salesdetail 
join sales on salesdetail.sales_id = sales.id and sales.status!=2 
left join stockdetail on salesdetail.id = stockdetail.ref_id and stockdetail.type = 1 and stockdetail.product_id = salesdetail.product_id 
where ifnull(is_out_all,0) = 0 and salesdetail.product_id = " + ProductId+" group by salesdetail.id").Tables[0];
            this.radGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                int sum = Convert.ToInt32(dt.Compute("Sum(count)", null));
                this.countTbx.Value = sum;
            }
            else {
                this.countTbx.Value = 0;
            }
            

        }
    }
}
