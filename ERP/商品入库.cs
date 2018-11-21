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
    public partial class 商品入库 : GridForm
    {
        public 商品入库()
        {
            InitializeComponent();
            ProductDal.BindProduct(this.product_nameDdl, this.colorDdl, this.dimensionsDdl,false);
            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                saveBtn.Visible = false;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
           
            
            StockDal stockDal = new StockDal();
            try{
                stockDal.InStock(this.radGridView1.Rows);
                MessageBox.Show("入库成功！");

                this.radGridView1.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           //stockDal.InStock(product_name, color, dimensions, p_id, count, remarks);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string product_name = product_nameDdl.Text,
               color = colorDdl.Text,
               remarks = remarksTbx.Text,
               dimensions = dimensionsDdl.Text;
            int count = Convert.ToInt32(countTbx.Value);
            int p_id = ProductDal.GetProduct(product_name, dimensions, color);
            if (p_id == 0) {
                MessageBox.Show("没有该商品，请核对！");
                return;
            }
            DateTime create_time = dateTimePicker1.Value;
            //foreach (var row in this.radGridView1.Rows)
            //{
            //    if ((long)row.Cells[0].Value == p_id)
            //    {
            //        row.Cells["count"].Value = (long)row.Cells["count"].Value + count;
            //        row.Cells["remarks"].Value = (string)row.Cells["remarks"].Value + ";" + remarks;
            //        return;
            //    }
            //}
            bool same = false;
            foreach (var dr in this.radGridView1.Rows) {
                if (Convert.ToInt32(dr.Cells["product_id"].Value) == p_id) {
                    same = true;
                }
            }
            if (!same)
            {

                this.radGridView1.Rows.Add(p_id, product_name, dimensions, color, count, create_time, remarks);
            }
            else {
                MessageBox.Show("已有此商品，请核对数据，直接修改数据即可。");
            }
        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            this.radGridView1.Rows.RemoveAt(el.RowIndex);
        }

        private void product_nameDdl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void dimensionsDdl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }
    }
}
