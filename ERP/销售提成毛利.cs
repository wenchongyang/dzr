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
    public partial class 销售提成毛利 : Telerik.WinControls.UI.ShapedForm
    {
        public 销售提成毛利()
        {
            InitializeComponent();
            this.storeCbx.DataSource = DataUtil.BindComboBoxData("store", null, null);
            this.storeCbx.ValueMember = "id";
            this.storeCbx.DisplayMember = "name";

            this.userCbx.DataSource = DataUtil.BindComboBoxData("users", null, " and  role_id = 5");
            this.userCbx.ValueMember = "id";
            this.userCbx.DisplayMember = "name";
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);

            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理) {
                this.radGridView1.Columns["cost_price"].IsVisible = false;
                this.radGridView1.Columns["margins"].IsVisible = false;
            }

        }

        void BindData()
        {
            string where = "1 = 1 ";
            where += " and  sales.create_time >='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and sales.create_time<= '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            if (!this.storeCbx.SelectedValue.Equals(-1))
            {
                where += " and sales.store_id = " + this.storeCbx.SelectedValue;
            }
            else
            {
                where += " and status !=2 ";
            }
            if (!this.userCbx.SelectedValue.Equals(-1))
            {
                where += " and sales.user_id = " + this.userCbx.SelectedValue;
            }
            this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT salesdetail.count,salesdetail.discount, salesdetail.product_name,salesdetail.color,salesdetail.dimensions, ROUND(salesdetail.need_pay,0) need_pay,ROUND(salesdetail.actually_pay,0) actually_pay,ROUND(sales.actually_pay - sales.front_pay ,0) as left_pay,
    ROUND(margins,0) margins ,ROUND(cost_price,0) cost_price,ROUND(commission,0) commission,
      sales.store_id, sales.user_id, sales.customer_name, case sales.status when 0 then '待出库' when 1 then  '完成' when 2 then '撤销' end as status,sales.bill_id,
      store.name AS store_name, users.name AS user_name,sales.create_time
FROM salesdetail LEFT JOIN
      sales ON salesdetail.sales_id = sales.id INNER JOIN
      store ON sales.store_id = store.id INNER JOIN
      users ON sales.user_id = users.id where " + where).Tables[0];

            LoadSummary();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
           
            BindData();
        }

        private void 销售明细_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            SalesDal.SaveMargins(radGridView1.Rows);
            MessageBox.Show("修改成功！");
        }
        private System.Windows.Forms.SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        private void exportBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Microsoft Excel|*.xls";
            saveFileDialog1.FileName = this.Text;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportExcel.export(saveFileDialog1.FileName, radGridView1);
            }
        }
        private void LoadSummary()
        {

            this.radGridView1.MasterTemplate.ShowTotals = true;
            this.radGridView1.MasterTemplate.SummaryRowsBottom.Clear();
            GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();

            item1.Add(new GridViewSummaryItem("need_pay", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("actually_pay", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("commission", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("cost_price", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("margins", "{0:F0}", GridAggregateFunction.Sum));

            this.radGridView1.MasterTemplate.SummaryRowsBottom.Add(item1);
        }
        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            GridCellElement cellElement = this.radGridView1.TableElement.GetCellElement(e.Row, e.Column);
            Point cellLocation = this.radGridView1.PointToScreen(cellElement.ControlBoundingRectangle.Location);
                cellLocation.Y = cellLocation.Y + 10;
                更新ToolStripMenuItem.Tag = e.Row;
                contextMenuStrip1.Show(cellLocation);
          
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridViewRowInfo dr = (GridViewRowInfo)((ToolStripMenuItem)sender).Tag;
            SalesDal.SaveMargins(dr);
            contextMenuStrip1.Hide();
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
            this.BindData();
        }

        private void radGridView1_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
         
        }
    }
}
