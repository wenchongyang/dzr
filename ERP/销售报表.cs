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
    public partial class 销售报表 : Telerik.WinControls.UI.ShapedForm
    {
        public 销售报表()
        {
            InitializeComponent();

            UsersDal.BindStoreAndUser(storeCbx, userCbx);
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);

        }

        private void LoadSummary()
        {

            //this.radGridView1.MasterTemplate.ShowTotals = true;
            this.radGridView1.MasterTemplate.SummaryRowsBottom.Clear();
            GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();

            item1.Add(new GridViewSummaryItem("actually_pay", "合计: {0:F0}", GridAggregateFunction.Sum));

            this.radGridView1.MasterTemplate.SummaryRowsBottom.Add(item1);
        }
        void BindData() {
            string where = "1 = 1 and sales.status !=2 ";
            where += " and  sales.create_time >='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and sales.create_time<= '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            if (!this.storeCbx.SelectedValue.Equals(-1)) {
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
            this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT 
      salesdetail.product_id,
      salesdetail.product_name, salesdetail.dimensions, salesdetail.color, 
      sum(salesdetail.count) as count, ROUND(avg(salesdetail.guide_price),0) as guide_price,
     ROUND( sum(salesdetail.actually_pay),0) as actually_pay
FROM salesdetail LEFT JOIN
      sales ON salesdetail.sales_id = sales.id LEFT JOIN
      store ON sales.store_id = store.id LEFT JOIN
      users ON sales.user_id = users.id where " + where + " group by salesdetail.product_id").Tables[0];
            LoadSummary();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void 销售报表_Load(object sender, EventArgs e)
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
