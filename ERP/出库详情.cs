using ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class 出库详情 : Telerik.WinControls.UI.ShapedForm
    {
        public 出库详情()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.radDateTimePicker1.Value = DateTime.Now;
        }
        public int SalesId { set; get; }
        public int SalesDetailId { set; get; }
        public int ProductId { set; get; }
        public DateTime OutTime { set; get; }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.billTbx.Text))
            {
                MessageBox.Show("出库编号必填！");
                return;
            }
            StockDal stockDal = new StockDal();
            try
            {
                stockDal.OutStock(SalesId, SalesDetailId, this.radDateTimePicker1.Value, ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text, this.billTbx.Text,
                    this.comboBox1.Text == "总仓" ? StockDal.OutType.Stock : StockDal.OutType.StoreStock
                    );
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 出库详情_Load(object sender, EventArgs e)
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
            if (null != OutTime) {
                this.radDateTimePicker1.Value = OutTime;
            }
        }
    }
}
