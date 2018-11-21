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
    public partial class 商品出入库 : Telerik.WinControls.UI.ShapedForm
    {
        public int ProductId
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

        public 商品出入库()
        {
            InitializeComponent();
            this.radDateTimePicker1.Value = DateTime.Now;
        }

        public void LoadInfo()
        {
            
            radLabel7.Text = FormType.ToString() + "日期";
            this.Text ="商品" +  FormType.ToString();

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

            if (Id != 0)
            {
                var rows = Data.DataUtil.ExecuteDataSet("select * from stockdetail where id=" + this.Id).Tables[0].Rows;
                if (rows.Count > 0)
                {
                    var row = rows[0];
                    this.ProductId = (int)row["product_id"];
                    this.countTbx.Value = Math.Abs((decimal)Convert.ToInt32(row["count"]));
                    this.radDateTimePicker1.Value = (DateTime)row["complete_time"];
                    this.remarksTbx.Text = (string)row["remarks"];
                    this.nameTbx.Enabled =
                    this.dimensionsTbx.Enabled =
                    this.radDateTimePicker1.Enabled = 
                    
                    this.colorTbx.Enabled = false;
                }

            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        StockDal dal = new StockDal();
        private void New() {
            throw new Exception("不允许新建");
        }

        private void Edit()
        {
            try
            {
                dal.ReInOrOutStock(Id,this.nameTbx.Text, this.colorTbx.Text,
                this.dimensionsTbx.Text, this.ProductId, Convert.ToInt32(this.countTbx.Value), this.remarksTbx.Text,
                this.radDateTimePicker1.Value, FormType == Type.出库 ? StockDal.Type.Out : StockDal.Type.IN);
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
