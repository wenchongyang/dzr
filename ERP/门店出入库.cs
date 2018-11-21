using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class 门店出入库 : Telerik.WinControls.UI.ShapedForm
    {
        public int ProductId
        {
            get;
            set;
        }
        public int StoreId
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public Type FormType { get; set; }
        public enum Type
        {
            出库,
            入库
        }

        public 门店出入库()
        {
            InitializeComponent();

            this.comboBox1.SelectedIndex = 0;
            UsersDal.BindStore(storeCbx, false,true);
            this.radDateTimePicker1.Value = DateTime.Now;
            this.storeCbx.Enabled = false;
           

        }

        public void LoadInfo()
        {
            
            radLabel7.Text = FormType.ToString() + "日期";

            this.Text = "门店" + FormType;
            if (FormType == Type.出库)
            {
                comboBox1.Visible = true;
            }
            else {
                comboBox1.Visible = false;
            }
           

            if (Id != 0)
            {
                var rows = Data.DataUtil.ExecuteDataSet("select * from storestockdetail where id=" + this.Id).Tables[0].Rows;
                if (rows.Count > 0)
                {
                    var row = rows[0];
                    this.ProductId = (int)row["product_id"];
                    this.StoreId = (int)row["store_id"];
                    this.countTbx.Value = Math.Abs((decimal)Convert.ToInt32(row["count"]));
                    this.radDateTimePicker1.Value = (DateTime)row["complete_time"];
                    this.remarksTbx.Text = (string)row["remarks"];
                    this.nameTbx.Enabled =
                    this.dimensionsTbx.Enabled =
                    this.colorTbx.Enabled =
                    this.storeCbx.Enabled = false;
                    this.comboBox1 .SelectedIndex = (int )row["out_type"];
                    this.comboBox1.Enabled = false;
                }

            }

            if (ProductId != 0)
            {
                DataRow[] drs = Data.DataUtil.ProductTableWithOutAll.Select("id = " + ProductId);
                if (drs.Length > 0)
                {
                    DataRow dr = drs[0];
                    this.nameTbx.Text = Convert.ToString(dr["name"]);
                    this.dimensionsTbx.Text = Convert.ToString(dr["dimensions"]);
                    this.colorTbx.Text = Convert.ToString(dr["color"]);
                    this.storeCbx.SelectedValue = StoreId;
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        StockDal dal = new StockDal();
        private void New() {
            try
            {
                if (this.comboBox1.Text == "顾客自提")
                {
                    dal.InOrOutStoreStock(this.nameTbx.Text, this.colorTbx.Text,
                    this.dimensionsTbx.Text, this.ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text,
                    (int)this.storeCbx.SelectedValue, this.radDateTimePicker1.Value,
                    FormType == Type.出库 ? StockDal.Type.Out : StockDal.Type.IN, StockDal.OutType.Stock
                    );
                }
                else {
                    dal.OutStoreStockToStock(this.nameTbx.Text, this.colorTbx.Text,
                    this.dimensionsTbx.Text, this.ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text,
                    (int)this.storeCbx.SelectedValue, this.radDateTimePicker1.Value);
                }
                MessageBox.Show("操作成功！");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit()
        {
            try
            {
                if (this.comboBox1.Text == "顾客自提")
                {
                    dal.ReInOrOutStoreStock(Id, this.nameTbx.Text, this.colorTbx.Text,
                    this.dimensionsTbx.Text, this.ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text,
                    (int)this.storeCbx.SelectedValue, this.radDateTimePicker1.Value, FormType == Type.出库 ? StockDal.Type.Out : StockDal.Type.IN);
                }
                else {
                    dal.ReOutStoreStockToStock(Id,this.nameTbx.Text, this.colorTbx.Text,
                   this.dimensionsTbx.Text, this.ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text,
                   (int)this.storeCbx.SelectedValue, this.radDateTimePicker1.Value);
                }
                MessageBox.Show("操作成功！");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (this.radDateTimePicker1.Value == null)
            {
                MessageBox.Show(FormType.ToString() + "日期必填！");
                return;
            }

            if (Id == 0)
            {
                New();
            }
            else {
                Edit();
            }
        }


        private void 门店出库_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }
    }
}
