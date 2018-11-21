using ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ERP
{
    public partial class 订单出库 : Telerik.WinControls.UI.ShapedForm
    {
        public int SalesId { get; set; }
        public 订单出库()
        {
            InitializeComponent();
            this.radDateTimePicker1.Value = DateTime.Now;
            storeCbx.DataSource = DataUtil.StoreTable;
            storeCbx.ValueMember = "id";
            storeCbx.DisplayMember = "name";
        }

        private void 订单出库_Load(object sender, EventArgs e)
        {
            Data.DataUtil.BindForm(this, "sales", SalesId);
            BindData();
           
        }
        private void BindData() {
            this.radGridView1.DataSource = DataUtil.ExecuteDataSet("select a.*,GROUP_CONCAT(CONCAT(DATE_FORMAT(b.complete_time,'%y-%m-%d'),'日，出库',CONVERT(abs(b.count),char),'件',',编号：',b.bill_id)  SEPARATOR ' ') AS stock_detail " +
                " from salesdetail a left join stockdetail b  on a.id = b.ref_id and b.type = 1  where a.sales_id = " + SalesId + " group by a.id").Tables[0];
        }

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.Name == "out") {
                if (e.Row.Cells["is_out_all"].Value != DBNull.Value &&  1 == Convert.ToInt32(e.Row.Cells["is_out_all"].Value))
                {
                    e.CellElement.Enabled = false;
                }else{
                    e.CellElement.Enabled = true;
                }
            }

            if (e.Column.Name == "stock_detail")
            {
                string sales_detail = Convert.ToString(e.Row.Cells["stock_detail"].Value);
                e.CellElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
                e.CellElement.TextWrap = true;
                var b = sales_detail.Replace(" ", "\n");
                e.CellElement.Text = b;
            }
        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "out")
            {
                出库详情 ckxq = new 出库详情();
                ckxq.ProductId = Convert.ToInt32(el.RowInfo.Cells["product_id"].Value);
                ckxq.SalesId = SalesId;
                ckxq.OutTime = this.radDateTimePicker1.Value;
                ckxq.SalesDetailId = Convert.ToInt32(el.RowInfo.Cells["id"].Value);
                ckxq.ShowDialog();

                if (ckxq.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    this.BindData();
                }
            }
          

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
