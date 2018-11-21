using ERP.Data;
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
    public partial class 出入库详情 : Telerik.WinControls.UI.RadForm
    {
        public 出入库详情()
        {
            InitializeComponent();

            this.mdckTbx.Enabled =  this.nameTbx.Enabled = this.dimensionsTbx.Enabled = this.colorTbx.Enabled = this.countTbx.Enabled = false;
            ((GridViewComboBoxColumn)this.radGridView1.Columns["is_store_out"]).DataSource = Data.DataUtil.Enum2DataTable(typeof(ERP.Data.StockDal.OutTypeName2), false);
            //((GridViewComboBoxColumn)this.radGridView1.Columns["store_id"]).DataSource = Data.DataUtil.StoreTable;
        }

        public int ProductId { get; set; }
        public Type FormType { get; set; }
        public enum Type
        {
            出库详情,
            入库详情
        }

        private void 待送详情_Load(object sender, EventArgs e)
        {
            this.Text = FormType.ToString();
            this.radGridView1.Columns["complete_time"].HeaderText = FormType == Type.入库详情 ? "入库时间" : "出库时间";
            if (FormType == Type.入库详情)
            {
                this.radGridView1.Columns["is_store_out"].IsVisible = false;
                this.mdckLable.Visible = this.mdckTbx.Visible = false;
            }
            radLabel5.Text = FormType == Type.入库详情 ? "总入库数量" : "总仓出库数量";
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

            if (FormType == Type.入库详情)
            {
                this.radGridView1.Columns["bill_id"].IsVisible = false;
            }
            else {
                this.radGridView1.Columns["remarks"].IsVisible = false;
            }
            string sql = @"select abs(stockdetail.count) as  count,sales.bill_id,sales.store_id,stockdetail.complete_time,stockdetail.is_store_out from  stockdetail 
left join salesdetail on salesdetail.id = stockdetail.ref_id and stockdetail.type = 1 and stockdetail.product_id = salesdetail.product_id 
left join sales on salesdetail.sales_id = sales.id
where stockdetail.status!=1 and stockdetail.type = 1  and  stockdetail.product_id = " + ProductId + "";

            if (FormType == Type.入库详情)
            {
                sql = @"select abs(count) as count,bill_id,0,complete_time,remarks from stockdetail where status != 1 and type = 0 and product_id = " + ProductId;
            }

            DataTable dt = Data.DataUtil.ExecuteDataSet(sql).Tables[0];
            this.radGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                int sum = Convert.ToInt32(dt.Compute("Sum(count)", null));

                if (FormType == Type.入库详情)
                {
                    this.countTbx.Value = sum ;
                }else{
                    sql = "select sum( abs(stockdetail.count) ) as count from stockdetail where stockdetail.status!=1 and stockdetail.type = 1 and is_store_out = 1 and  stockdetail.product_id = " + ProductId + "";
                    var obj = DataUtil.ExecuteScalar(sql);
                    int store_sun = obj == null || obj == DBNull.Value ? 0 : int.Parse(obj.ToString());
                    this.mdckTbx.Value = store_sun;
                    this.countTbx.Value = sum - store_sun;
                }
            }
            else
            {
                this.countTbx.Value = 0;
            }


        }
    }
}
