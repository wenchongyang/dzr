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
    public partial class 销售明细 : Telerik.WinControls.UI.ShapedForm
    {
        public 销售明细()
        {
            InitializeComponent();

            UsersDal.BindStoreAndUser(storeCbx, userCbx);
            rqlxCbx.SelectedIndex = 0;

            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);

            statusCbx.DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.SalesStatus), true);
            statusCbx.DisplayMember = "key";
            statusCbx.ValueMember = "val";


            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.SalesStatus), "key", "val", true);

        }
        private void LoadSummary()
        {

            //this.radGridView1.MasterTemplate.ShowTotals = true;
            this.radGridView1.MasterTemplate.SummaryRowsBottom.Clear();
            GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();

            item1.Add(new GridViewSummaryItem("need_pay", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("actually_pay", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("commission", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("cost_price", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("margins", "{0:F0}", GridAggregateFunction.Sum));

            this.radGridView1.MasterTemplate.SummaryRowsBottom.Add(item1);
        }
        private enum OrderStatus2
        {
            完成, 撤销
        }
        void BindData()
        {
            string where = " 1 = 1 ";
            if (!this.storeCbx.SelectedValue.Equals(-1))
            {
                where += " and sales.store_id = " + this.storeCbx.SelectedValue;
            }
            else if (UsersDal.CurUser.UserRole == UsersDal.Role.店长 || UsersDal.CurUser.UserRole == UsersDal.Role.导购)
            {
                where += " and (sales.store_id in( " + UsersDal.CurUser.Stores + ") or sales.user_id =" + UsersDal.CurUser.UserId + " ) ";
            }

            if (!this.userCbx.SelectedValue.Equals(-1))
            {
                where += " and sales.user_id = " + this.userCbx.SelectedValue;
            }
            if (!this.statusCbx.SelectedValue.Equals(-1)) {
                where += " and sales.status = " + this.statusCbx.SelectedValue;
            }
            else
            {
                where += " and status !=2 ";
            }
            where += " and (sales." + (this.rqlxCbx.Text == "订单日期" ? "create_time" : "delivery_date") + " between '" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")  + " 23:59:59')";

            this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT salesdetail.count,salesdetail.discount, salesdetail.product_name,salesdetail.color,salesdetail.dimensions, ROUND(salesdetail.need_pay,0) need_pay,ROUND(salesdetail.actually_pay,0) actually_pay,ROUND(sales.actually_pay - sales.front_pay ,0) as left_pay,
      sales.store_id, sales.user_id, sales.customer_name, sales.status,sales.bill_id,sales.create_time,sales.delivery_date,
      store.name AS store_name, users.name AS user_name,sales.paymet_method1
FROM salesdetail LEFT JOIN
      sales ON salesdetail.sales_id = sales.id LEFT JOIN
      store ON sales.store_id = store.id LEFT JOIN
      users ON sales.user_id = users.id where " + where +" order by sales.id").Tables[0];
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
    }
}
