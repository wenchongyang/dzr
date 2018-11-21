using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ERP
{
    public partial class 订货明细 : GridForm
    {
        public 订货明细()
        {
            InitializeComponent();
            DataUtil.BindEnum2(statusCbx, typeof(DataUtil.OrderStatus), true);
            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.OrderStatus), true);
            InitGrid(this.radGridView1, "productorder", true);
            if (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员) { 
                this.radGridView1.Columns["price"].IsVisible = false;
            }
            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                this.radGridView1.Columns["operate"].IsVisible = this.radGridView1.Columns["complete"].IsVisible = false;
            }
        }
        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            List<DictionaryEntry> list = new List<DictionaryEntry>();
            whereStr = " and  create_time >=@s_rq and create_time<=@e_rq ";
            list.Add(new DictionaryEntry("s_rq", this.dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            DateTime endDate = this.dateTimePicker2.Value;
            list.Add(new DictionaryEntry("e_rq", this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"));


            getPorductSearch(list, ref whereStr, product_nameDdl, colorDdl, dimensionsDdl, false);
            return list.ToArray();

        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
              GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
              if (el.Data.Name == "operate")
              {
                  订货 f = new 订货();
                  f.Id = (int)el.Value;
                  f.ShowDialog();
                  if(f.DialogResult == System.Windows.Forms.DialogResult .OK){
                      this.BindData();
                  }
              }
              else if (el.Data.Name == "complete")
              {
                  StockDal stockDal = new StockDal();
                  try {
                      stockDal.CgInStock(Convert.ToString(el.RowInfo.Cells["product_name"].Value), Convert.ToString(el.RowInfo.Cells["color"].Value),
                         Convert.ToString(el.RowInfo.Cells["dimensions"].Value), Convert.ToInt32(el.RowInfo.Cells["product_id"].Value),
                         Convert.ToInt32(el.RowInfo.Cells["count"].Value), DateTime.Now, "采购入库",(int)el.Value);
                      MessageBox.Show("采购完成，自动入库成功！");
                      this.BindData();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }
        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            DateTime create_time = Convert.ToDateTime(e.Row.Cells["create_time"].Value);
            int status = (int)e.Row.Cells["status"].Value;

            if (e.Column.Name == "complete")
            {
                e.CellElement.Enabled = (status == (int)Data.DataUtil.OrderStatus.已订货);
            }
            if (e.Column.Name == "operate")
            {
                e.CellElement.Enabled = (status == (int)Data.DataUtil.BackStatus.待处理) && ((UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员 &&
                create_time.Date == DataUtil.Now.Date
                ) ||  UsersDal.CurUser.UserRole == UsersDal.Role.超级管理员);
            }
        }
    }
}
