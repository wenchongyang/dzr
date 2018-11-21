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
    public partial class 订单出库列表 : Telerik.WinControls.UI.ShapedForm
    {
        public 订单出库列表()
        {
            InitializeComponent();
            rqlxCbx.SelectedIndex = 0;
            DataUtil.BindEnum2(statusCbx, typeof(DataUtil.SalesStatus),true);

            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.SalesStatus), "key", "val",false);

            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);

            this.storeCbx.DataSource =  DataUtil.BindComboBoxData("store", null, null);
            this.storeCbx.ValueMember = "id";
            this.storeCbx.DisplayMember = "name";
            BindData();

            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                this.radGridView1.Columns["edit"].IsVisible = this.radGridView1.Columns["out_stock"].IsVisible = false;
            }
            LoadSummary();
        }

        private void LoadSummary()
        {
            this.radGridView1.MasterTemplate.ShowTotals = true;
            this.radGridView1.MasterTemplate.SummaryRowsBottom.Clear();
            GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();

            item1.Add(new GridViewSummaryItem("delivery_pay", "{0:F0}", GridAggregateFunction.Sum));
            item1.Add(new GridViewSummaryItem("re_pay", "{0:F0}", GridAggregateFunction.Sum));

            this.radGridView1.MasterTemplate.SummaryRowsBottom.Add(item1);
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            BindData();
        }
        StockDal stockDal = new StockDal();
        void BindData()
        {
            string where = " where sales." + (this.rqlxCbx.Text == "订单日期" ? "create_time" : "delivery_date") + " >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and sales." + (this.rqlxCbx.Text == "订单日期" ? "create_time" : "delivery_date") +" <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59'";

            if (!this.statusCbx.SelectedValue.Equals(-1))
            {
                where += " and status =" + this.statusCbx.SelectedValue;
            }

            if (!string.IsNullOrWhiteSpace(this.customTbx.Text))
            {
                where += " and customer_name like '%" + this.customTbx.Text + "%'";
            }
            if (!this.storeCbx.SelectedValue.Equals(-1)) {
                where += " and store_id = " + this.storeCbx.SelectedValue;
            }
            else if (UsersDal.CurUser.UserRole == UsersDal.Role.店长 || UsersDal.CurUser.UserRole == UsersDal.Role.导购)
            {
                where += " and (store_id in( " + UsersDal.CurUser.Stores + ") or user_id =" + UsersDal.CurUser.UserId + " ) ";
            }

            if (!string.IsNullOrWhiteSpace(this.bill_idTbx.Text))
            {
                where += " and bill_id like '%" + this.bill_idTbx.Text + "%'";
            }
            this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT sales.id,sales.bill_id,sales.customer_name,sales.phone,sales.address,sales.status,
sales.delivery_pay,sales.delivery_date,GROUP_CONCAT(CONCAT(product_name,dimensions,color,CONVERT(count,char),'件') SEPARATOR ' ') AS sales_detail,
sales.store_id, sales.user_id, sales.customer_name, store.name AS store_name,(sales.need_pay - sales.front_pay) as re_pay
    FROM sales LEFT JOIN     salesdetail ON salesdetail.sales_id = sales.id LEFT JOIN      store ON sales.store_id = store.id" + where + " group by sales.id").Tables[0];
            
        }

        
        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "out_stock")
            {

                订单出库 f = new 订单出库();
                f.SalesId = (int)el.Value;
                f.ShowDialog();
                BindData();
                /**
                var id = (int)el.Value;
                try
                {
                    stockDal.OutStock(id);
                    BindData();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }**/
            }
            else if (el.Data.Name == "print")
            {

                PrintForm f = new PrintForm();
                //订单录入 f = new 订单录入();
                f.SalesId = (int)el.Value;
                
                f.ShowDialog();

            }
            else if (el.Data.Name == "edit")
            {
                订单录入 f = new 订单录入();
                f.Id = (int)el.Value;
                f.Actions = 订单录入.Action.订单出库修改;
                f.ShowDialog();

            }
        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            int status = Convert.ToInt32(e.Row.Cells["status"].Value);


            if (e.Column.Name == "sales_detail")
            {
                string sales_detail = Convert.ToString(e.Row.Cells["sales_detail"].Value);
                e.CellElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
                e.CellElement.TextWrap = true;
                var b = sales_detail.Replace(" ", "\n");
                //e.CellElement.ToolTipText = b;
                e.CellElement.Text = b;
            }

            if ((e.CellElement.ColumnInfo).HeaderText == "出库"
                //|| (e.CellElement.ColumnInfo).HeaderText == "编辑"
                )
            {
                GridCommandCellElement commandCell = (GridCommandCellElement)e.CellElement;
                RadButtonElement buttonElement = (RadButtonElement)commandCell.Children[0];
                if (status == 0)
                {
                    buttonElement.Enabled = true;
                }
                else {
                    buttonElement.Enabled = false;
                }
            }
            
        }

      
    }
}
