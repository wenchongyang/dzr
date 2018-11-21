using Aspose.Cells;
using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ERP
{
    public partial class 订单管理 : Telerik.WinControls.UI.ShapedForm
    {
        public 订单管理()
        {
            InitializeComponent();
            statusCbx.DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.SalesStatus),true);
            statusCbx.DisplayMember = "key";
            statusCbx.ValueMember = "val";

            UsersDal.BindStoreAndUser(storeCbx, userCbx);

            ((GridViewComboBoxColumn)this.radGridView1.Columns["status"]).DataSource = DataUtil.Enum2DataTable(typeof(DataUtil.SalesStatus), "key", "val",true);

            dateTimePicker1.Value = DateTime.Now.AddDays(-14);
            BindData();

        }
        void BindData()
        {
            string where = " where sales.create_time >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and sales.create_time <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59'";

            if (!this.statusCbx.SelectedValue.Equals(-1))
            {
                where += " and status =" + this.statusCbx.SelectedValue;
            }
            else
            {
                where += " and status !=2 ";
            }

            if (!string.IsNullOrWhiteSpace(this.customTbx.Text))
            {
                where += " and customer_name like '%" + this.customTbx.Text + "%'";
            }
            if (!this.storeCbx.SelectedValue.Equals(-1))
            {
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
            if (!userCbx.SelectedValue.Equals(-1))
            {
                where += " and user_id = " + this.userCbx.SelectedValue;
            }
            this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT sales.id,
    sales.bill_id,sales.customer_name,sales.phone,sales.address,sales.status,Round(sales.need_pay,0) need_pay, ROUND(sales.front_pay,0) front_pay ,sales.create_time,
      sales.delivery_pay,sales.delivery_date,GROUP_CONCAT(CONCAT(product_name,dimensions,color,CONVERT(count,char),'件') SEPARATOR ' ') AS sales_detail,
      sales.store_id, sales.user_id, sales.customer_name,ROUND(sales.need_pay - sales.front_pay,0)  as left_pay,
      store.name AS store_name,length( sapshot) as sapshot_length
FROM sales LEFT JOIN
      salesdetail ON salesdetail.sales_id = sales.id LEFT JOIN
      store ON sales.store_id = store.id" + where + " group by sales.id").Tables[0];
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "viewlist")
            {
                ImageForm img = new ImageForm();
                img.ImgBtyes = ERP.Data.SalesDal.GetBuffer((int)el.Value);
                img.ShowDialog();
                //img.ImgBtyes = ERP.Data.SalesDal
            }
            else if (el.Data.Name == "view")
            {
                订单录入 f = new 订单录入();
                f.Id = (int)el.Value;
                f.Actions = 订单录入.Action.查看;
                f.ShowDialog();
                
            }
            else if (el.Data.Name == "upload")
            {
                int id = (int)el.Value;
                if (MessageBox.Show("是否需要拍照上传？选择“是”现场拍照，选择”否“从已有图片中选择", "选择上传方式", MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.Yes)
                {
                    CameraForm cameraForm = new CameraForm();
                    cameraForm.salesId = id;
                    cameraForm.ShowDialog();
                }
                else
                {
                    if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        Stream stream = this.openFileDialog1.OpenFile();
                        byte[] img = new byte[stream.Length];
                        stream.Read(img, 0, (int)stream.Length);
                        SalesDal.upLoadFile(img, id);
                    }
                }
                this.BindData();
            }
            else if (el.Data.Name == "edit")
            {
                订单录入 f = new 订单录入();
                f.Id = (int)el.Value;
                f.Actions = 订单录入.Action.订单修改;
                f.ShowDialog();

            }
            else if (el.Data.Name == "cal")
            {
                if (MessageBox.Show("是否确认要撤销此订单！", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SalesDal.Cancel((int)el.Value);
                    this.BindData();
                }

            }
        }

        private bool EnAbleEdit(GridViewRowInfo dr) { 
            int user_id = Convert.ToInt32(dr.Cells["user_id"].Value);
            DateTime create_time = Convert.ToDateTime(dr.Cells["create_time"].Value);
            return (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员 && user_id == UsersDal.CurUser.UserId &&
                create_time.Date == DataUtil.Now.Date
                ) ||  UsersDal.CurUser.UserRole == UsersDal.Role.超级管理员;
        }
        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            
            int status = Convert.ToInt32(e.Row.Cells["status"].Value);

          
            if (e.Column.Name == "sales_detail") {
                string sales_detail = Convert.ToString(e.Row.Cells["sales_detail"].Value);
                e.CellElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
                e.CellElement.TextWrap = true;
                var b = sales_detail.Replace(" ", "\n");
                //e.CellElement.ToolTipText = b;
                e.CellElement.Text = b;
            }

            //e.Row.Height = e.Row.Height * (detail.Split(' ').Length);

            if (e.Column.Name == "edit")
            {
                GridCommandCellElement commandCell = (GridCommandCellElement)e.CellElement;
                RadButtonElement buttonElement = (RadButtonElement)commandCell.Children[0];
                if (status == (int)DataUtil.SalesStatus.待出库 && EnAbleEdit(e.Row))
                {
                    buttonElement.Enabled = true;
                }
                else
                {
                    buttonElement.Enabled = false;
                }
            }
            else if (e.Column.Name == "cal")
            {
                GridCommandCellElement commandCell = (GridCommandCellElement)e.CellElement;
                RadButtonElement buttonElement = (RadButtonElement)commandCell.Children[0];
                if (status != (int)DataUtil.SalesStatus.撤销 && EnAbleEdit(e.Row))
                {
                    buttonElement.Enabled = true;
                }
                else
                {
                    buttonElement.Enabled = false;
                }
            }
            else if (e.Column.Name == "viewlist")
            {
                GridCommandCellElement commandCell = (GridCommandCellElement)e.CellElement;
                RadButtonElement buttonElement = (RadButtonElement)commandCell.Children[0];
                if (e.Row.Cells["sapshot_length"].Value == DBNull.Value || e.Row.Cells["sapshot_length"].Value.Equals(0))
                {
                    buttonElement.Enabled = false;
                }
                else
                {
                    buttonElement.Enabled = true;
                }
            }

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Microsoft Excel|*.xls";
            saveFileDialog1.FileName = "订单";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportExcel.export(saveFileDialog1.FileName, radGridView1);
            }
        }

        private void MasterTemplate_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            
        }

        private void storeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
