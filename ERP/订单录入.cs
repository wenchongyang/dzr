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
    public partial class 订单录入 : GridForm
    {
        DataSet dllDateSet = new DataSet();
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(订单录入));
        public void Print()
        {
            this.radPrintDocument1.Print();
        }
        public enum Action
        {
            订单录入, 订单修改, 订单出库修改, 打印,
            查看
        }
        public int Id { set; get; }
        public Action Actions { set; get; }

        private static DataTable dimensionsTd = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "dimensions");
        private static DataTable colorTd = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "color");
        public 订单录入()
        {
            InitializeComponent();
            Data.DataUtil.LoadProduct();
            radGridView1.EditorRequired += new EditorRequiredEventHandler(radGridView1_EditorRequired);
            ((GridViewComboBoxColumn)this.radGridView1.Columns[1]).DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "name");
            var dr = dimensionsTd.NewRow(); ;
           
            ((GridViewComboBoxColumn)this.radGridView1.Columns[2]).DataSource = dimensionsTd;
            ((GridViewComboBoxColumn)this.radGridView1.Columns[3]).DataSource = colorTd;

            this.radDateTimePicker1.Value = DateTime.Now;

            // this.billTbx.Text = StoreDal.GetBillNo(Users.GetUser().StoreId).ToString();
            DataTable dt = new DataTable("fkfs");
            dt.Columns.Add("key", typeof(String));
            dt.Columns.Add("value", typeof(String));

            DataRow row = dt.NewRow();
            row["key"] = "现金";
            row["value"] = "现金";

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["key"] = "刷卡";
            row["value"] = "刷卡";

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["key"] = "混合";
            row["value"] = "混合";
            dt.Rows.Add(row);
            storeCbx.DataSource = DataUtil.StoreTable;
            storeCbx.ValueMember = "id";
            storeCbx.DisplayMember = "name";
            if (UsersDal.CurUser.DefStoreId!=-1)
            storeCbx.SelectedValue = UsersDal.CurUser.DefStoreId;
            //Users.BindStore(storeCbx, false);
            //if (Users.CurUser.UserRole == Users.Role.超级管理员 || Users.CurUser.UserRole == Users.Role.总经理)
            //{
            //    storeLab.Visible = storeCbx.Visible = true;
            //}
            //else
            //{
            //    storeLab.Visible = storeCbx.Visible = false;
            //}

            this.dllDateSet.Tables.Add(dt);
            paymetMethod1Cbx.DataSource = dllDateSet.Tables["fkfs"];
            paymetMethod1Cbx.SelectedIndex = 0;
            paymetMethod2Cbx.DataSource = DataUtil.Clone(dllDateSet.Tables["fkfs"]);
            paymetMethod2Cbx.SelectedIndex = 0;
            this.radButton1.Visible = true;

        }
        public class MyDropDownListEditor : RadDropDownListEditor
        {
            private RadGridView grid;
            public MyDropDownListEditor(RadGridView grid)
            {
                this.grid = grid;
            }
            private MyDropDownListEditorElement el;
            protected override RadElement CreateEditorElement()
            {
                el = new MyDropDownListEditorElement(grid);
                return el;
            }
            public override void OnValueChanged()
            {
                base.OnValueChanged();
            }
           

        }
        public class MyDropDownListEditorElement : RadDropDownListEditorElement
        {
            RadGridView grid;
            public MyDropDownListEditorElement(RadGridView grid)
            {
                this.grid = grid;
            }
            public override void NotifyOwner(PopupEditorNotificationData notificationData)
            {
                
                base.NotifyOwner(notificationData);
                if (null != notificationData.keyEventArgs && notificationData.keyEventArgs.KeyCode == Keys.Enter)
                {
                    MyDropDownListEditorElement editorElement = (MyDropDownListEditorElement)this.EditorElement;
                    if (editorElement.DropDownStyle == RadDropDownStyle.DropDown)
                    {
                        RadTextBoxItem item = editorElement.TextBox.TextBoxItem;
                        string text = val;
                        StringComparison comparisonType = editorElement.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                   
                        foreach (RadListDataItem item2 in editorElement.Items)
                        {
                            if (item2.Text.Equals(text, comparisonType))
                            {
                                item2.Selected = true;
                                break;
                            }
                        }
                        this.Text = val;
                        
                    }
                    
                }

            }
            string val;
            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    this.val = this.Text;
                }
            }
        }
        private void radGridView1_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            if (e.EditorType == typeof(RadDropDownListEditor) && this.radGridView1.CurrentColumn.Name == "dimensions")
            {
                e.Editor = new MyDropDownListEditor(this.radGridView1);
            }
        }
        private bool init = false;
        private void BindEdit()
        {
            if (0 != Id)
            {
                DataTable salesTable = DataUtil.BindData("sales", null, " and id=" + this.Id);
                DataRow dr = salesTable.Rows[0];
                foreach (Control c in this.Controls)
                {
                    if (c.Tag != null)
                    {
                        string key = c.Tag.ToString();
                        if (salesTable.Columns.Contains(key))
                        {
                            if (c is RadSpinEditor)
                            {
                                ((RadSpinEditor)c).Value = (decimal)dr[key];
                            }
                            else if (c is RadDateTimePicker)
                            {
                                if (null != dr[key] && DBNull.Value != dr[key])
                                    ((RadDateTimePicker)c).Value = (DateTime)dr[key];
                            }else if (c.Name == "storeCbx"){
                                if (null != dr[key] && DBNull.Value != dr[key])
                                    ((ComboBox)c).SelectedValue = dr[key];
                            }
                            else
                            {
                                c.Text = dr[key] + "";
                            }
                        }

                    }
                }
                init = true;
                this.radGridView1.DataSource = DataUtil.ExecuteDataSet(@"SELECT `salesdetail`.`id`,
    `salesdetail`.`sales_id`,
    `salesdetail`.`product_id`,
    `salesdetail`.`product_name`,
    `salesdetail`.`dimensions`,
    `salesdetail`.`color`,
    `salesdetail`.`count`,
   ROUND(`salesdetail`.`guide_price`,0) guide_price,
    `salesdetail`.`discount`,
    ROUND(`salesdetail`.`need_pay`,0) need_pay,
    ROUND(`salesdetail`.`actually_pay`,0) actually_pay,
    `salesdetail`.`paymet_method`,
    ROUND(`salesdetail`.`margins`,0) margins,
    ROUND(`salesdetail`.`cost_price`,0) cost_price,
    ROUND(`salesdetail`.`commission`,0) commission,
    `salesdetail`.`cal_way`,
    `salesdetail`.`is_out_all`,`salesdetail`.remarks
FROM `salesdetail` where sales_id= " + this.Id+";").Tables[0];
                    //DataUtil.BindData("salesdetail", null, " and sales_id = " + this.Id);
                this.radButton1.Visible = false;
                this.radButton2.Text = "修改";

                if (Actions == 订单录入.Action.订单出库修改)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.AccessibleDescription == "front")
                        {
                            c.Enabled = false;
                        }

                    }
                    this.radGridView1.Columns["delete"].IsVisible = false;
                    this.radGridView1.Enabled = true;
                    this.radGridView1.ReadOnly = true;
                }
                else if (Actions == 订单录入.Action.打印)
                {
                    this.radButton2.Text = "打印";
                }
                else if (Actions == Action.查看) {
                    foreach (Control c in this.Controls)
                    {
                        
                          c.Enabled = false;
                        
                    }
                    this.cBtn.Enabled = true;
                    this.radGridView1.Enabled = true;
                    this.radGridView1.Columns["delete"].IsVisible = false;
                    this.radGridView1.ReadOnly = true;
                }
                this.cBtn.Visible = true;
            }
            else
            {
                this.cBtn.Visible = false;
            }
            init = false;

        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            this.radGridView1.AllowAddNewRow = true;
        }

        private void 订单录入_Load(object sender, EventArgs e)
        {
            BindEdit();
            this.billTbx.Focus();
        }
        private DictionaryEntry[] GetSalesInfo()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            foreach (Control c in this.Controls)
            {
                if (c.Tag != null)
                {
                    string key = c.Tag.ToString();
                    if (!String.IsNullOrWhiteSpace(key))
                    {
                        object value = c.Text;
                        if (c is RadSpinEditor)
                        {
                            value = ((RadSpinEditor)c).Value;
                        }
                        else if (c is RadDateTimePicker)
                        {
                            value = ((RadDateTimePicker)c).Value;
                        }
                        else if (c.Name == "storeCbx")
                        {
                            value = ((ComboBox)c).SelectedValue;
                        }
                        list.Add(new DictionaryEntry(key, value));
                    }

                }
            }

            //list.Add(new DictionaryEntry("store_id", (int)this.storeCbx.SelectedValue));// Users.CurUser.StoreId
            list.Add(new DictionaryEntry("status", 0));
            list.Add(new DictionaryEntry("create_time", DateTime.Now));
            if (Id != 0)
            {
                list.Add(new DictionaryEntry("id", Id));
                list.Add(new DictionaryEntry("modfied_user", UsersDal.CurUser.UserId));
                list.Add(new DictionaryEntry("modfied_time", DateTime.Now));
            }
            else
            {
                list.Add(new DictionaryEntry("create_user", UsersDal.CurUser.UserId));
                list.Add(new DictionaryEntry("user_id", UsersDal.CurUser.UserId));
            }

            if (this.openFileDialog1.FileName.Length > 0)
            {
                Stream stream = this.openFileDialog1.OpenFile();
                byte[] img = new byte[stream.Length];
                stream.Read(img, 0, (int)stream.Length);
                list.Add(new DictionaryEntry("sapshot", img));
                //SalesDal.upLoadFile(img, this.Id);
            }
            return list.ToArray();

        }
        private bool checkNull()
        {
            return !string.IsNullOrWhiteSpace(this.billTbx.Text)
                && !string.IsNullOrWhiteSpace(this.customerNameTbx.Text)
                && !string.IsNullOrWhiteSpace(this.addressTbx.Text)
                && this.storeCbx.SelectedValue != null
                && !string.IsNullOrWhiteSpace(this.phoneTbx.Text);
        }
        private bool Add()
        {
            if (this.radGridView1.Rows.Count == 0)
            {
                MessageBox.Show("产品清单为空，请录入货品清单！");
                return false;
            }
            if (!checkNull())
            {
                MessageBox.Show("请核对必填项！");
                return false;
            }
            if (!checkRow())
            {
                
                return false;
            }
            {
                Id = SalesDal.Add(GetSalesInfo(), this.radGridView1.Rows);
                if (Id == 0)
                {
                    MessageBox.Show("请核对商品！");
                    return false;
                }
                return true;

            }

        }
        private bool Edit()
        {
            if (this.radGridView1.Rows.Count == 0)
            {
                MessageBox.Show("产品清单为空，请录入货品清单！");
                return false;
            }
            if (!checkNull())
            {
                MessageBox.Show("请核对必填项！");
                return false;
            }
            if (!checkRow())
            {
               
                return false;
            }
            //
            if (Actions == 订单录入.Action.订单修改)
            {
                SalesDal.Edit(Id, GetSalesInfo(), this.radGridView1.Rows);
                MessageBox.Show("提交成功！");
                this.Close();
                return true;
            }
            else
            {
                SalesDal.CKEdit(Id, GetSalesInfo());
                MessageBox.Show("修改成功！");
                this.Close();
                return true;
            }
        }

        private bool checkRow()
        {
            bool allOk = true, same = false;
            Hashtable k = new Hashtable();
            int i = 0;
            string error = "";
            foreach (var dr in this.radGridView1.Rows)
            {
                bool ok = true;
                i++;
                if (dr.Cells["product_id"].Value == null 
                    || dr.Cells["product_id"].Value == DBNull.Value
                    || (0).Equals(dr.Cells["product_id"].Value))
                {
                    ok = false;
                }
                string key = "" + dr.Cells["product_id"].Value;
                if (!k.ContainsKey(key))
                {
                    k.Add(key, null);
                }
                else
                {
                    same = true;
                }
                string product_name = Convert.ToString(dr.Cells["product_name"].Value),
                  dimensions = Convert.ToString(dr.Cells["dimensions"].Value),
                  color = Convert.ToString(dr.Cells["color"].Value);

                if (dr.Cells["count"].Value == null
                    || dr.Cells["guide_price"].Value == null
                    || dr.Cells["discount"].Value == null
                    || dr.Cells["need_pay"].Value == null
                    || dr.Cells["actually_pay"].Value == null
                    )
                {
                    ok = false;
                }
                else
                {
                    if (key.Length == 0)
                    {
                        decimal? guide_price = null, cost_price = null;
                        int p_id = ProductDal.GetProduct(product_name, dimensions, color, out guide_price, out cost_price, false);
                        if (p_id == 0)
                        {
                            ok = false;
                        }
                        else
                        {
                            key = "" + p_id;
                            if (!k.ContainsKey(key))
                            {
                                k.Add(key, null);
                            }
                            else
                            {
                                same = true;
                            }
                        }
                    }
                }
                if (!ok)
                {
                    error += "," + i;
                    allOk = false;
                }
            }
            if (error.Length > 0)
            {
                MessageBox.Show("请核对第" + error.Substring(1) + "行数据错误，请核对货物清单！");
            }
            else if (same)
            {
                MessageBox.Show("请核对货物清单,有重复货品！");
            }

           

            return allOk && !same;
        }
        private void clearData()
        {
            this.radGridView1.Rows.Clear();
            this.billTbx.Text = "";
            foreach (Control c in this.Controls)
            {
                if (c.Tag != null)
                {
                    c.Text = "";
                }
            }

            this.Id = 0;
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            if (0 == Id)
            {
                if (Add())
                {
                    MessageBox.Show("录入成功！");
                    clearData();
                }
                //this.billTbx.Text = StoreDal.GetBillNo(Users.GetUser().StoreId).ToString();

            }
            else
            {
               
                    Edit();
             
            }
        }

        private void setId(GridViewRowInfo dr)
        {
            string product_name = Convert.ToString(dr.Cells["product_name"].Value),
                   dimensions = Convert.ToString(dr.Cells["dimensions"].Value),
                   color = Convert.ToString(dr.Cells["color"].Value);
            decimal? guide_price = null, cost_price = null;
            int p_id = ProductDal.GetProduct(product_name, dimensions, color, out guide_price, out cost_price, false);
            if (p_id == 0)
            {
                //MessageBox.Show("没有该商品请核对");
                dr.Cells["product_id"].Value  = DBNull.Value;
            }
            else
            {
                dr.Cells["product_id"].Value = p_id;
                dr.Cells["guide_price"].Value = guide_price == null ? 0 : Convert.ToInt32(decimal.Round(guide_price.Value, 0));
                dr.Cells["cost_price2"].Value = cost_price == null ? 0 : Convert.ToInt32(decimal.Round(cost_price.Value, 0));
                dr.Cells["discount"].Value = 1;
            }

        }

        private void radGridView1_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo dr = e.Row;
            if (e.Column.Name == "discount" || e.Column.Name == "color"  || e.Column.Name == "count" || e.Column.Name == "guide_price")
            {
                decimal pay = 0;
                int count = 0;
                try
                {

                    count = Convert.ToInt32(e.Row.Cells["count"].Value);
                    pay = Convert.ToDecimal(e.Row.Cells["guide_price"].Value) * count * Convert.ToDecimal(e.Row.Cells["discount"].Value);
                    e.Row.Cells["need_pay"].Value = Convert.ToInt32(decimal.Round(pay, 0));
                    e.Row.Cells["actually_pay"].Value = Convert.ToInt32(decimal.Round(pay, 0));
                   
                }
                catch (Exception ex) { log.Debug("change", ex); }
                try
                {
                    decimal cost_price2 = Convert.ToDecimal(e.Row.Cells["cost_price2"].Value);
                    int cost_price = Convert.ToInt32(decimal.Round(count * cost_price2,0));
                    e.Row.Cells["margins"].Value = Convert.ToInt32(decimal.Round(pay - cost_price, 0));
                    e.Row.Cells["cost_price"].Value = cost_price;
                }
                catch (Exception ex) { log.Debug("change", ex); }
            }
            if (e.Column.Name == "actually_pay")
            {
                try
                {
                   
                 
                }
                catch (Exception ex) { log.Debug("change", ex); }
            }

            if (e.Column.Name == "dimensions")
            {
                //((GridViewComboBoxColumn)this.radGridView1.Columns[1]).DataSource = productTable.DefaultView.ToTable(true, "name");
                setId(dr);
                //((GridViewComboBoxColumn)this.radGridView1.Columns["color"]).DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "color");
            }
            else if (e.Column.Name == "color") {
                setId(dr);
                //((GridViewComboBoxColumn)this.radGridView1.Columns["color"]).DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "color");
            }
            else if (e.Column.Name == "product_name")
            {
                e.Row.Cells["product_id"].Value = DBNull.Value;
            }
            ((GridViewComboBoxColumn)this.radGridView1.Columns["color"]).DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "color");
            ((GridViewComboBoxColumn)this.radGridView1.Columns["dimensions"]).DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "dimensions");

        }



        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            //if (e.Action != Telerik.WinControls.Data.NotifyCollectionChangedAction.Move)
            //if(e.Action!= Telerik.WinControls.Data.NotifyCollectionChangedAction.Reset)
            {
                decimal all = 0;
                foreach (var row in this.radGridView1.Rows)
                {
                    var tmp = row.Cells["actually_pay"].Value;
                    if (tmp != null && tmp != DBNull.Value)
                        all += (decimal)row.Cells["actually_pay"].Value;
                }
                if (!init)
                    frontPayTbx.Value = allTbx.Value = all;
            }
        }

        private void frontPayTbx_ValueChanged(object sender, EventArgs e)
        {
            if (allTbx.Value < frontPayTbx.Value)
            {
                MessageBox.Show("定金不能大于订单金额!");
                frontPayTbx.Value = allTbx.Value;
                return;
            }
            balanceTbx.Value = allTbx.Value - frontPayTbx.Value;

        }
        private void upload()
        {

            if (MessageBox.Show("是否需要拍照上传？选择“是”现场拍照，选择”否“从已有图片中选择", "选择上传方式", MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.Yes)
            {
                CameraForm cameraForm = new CameraForm();
                cameraForm.salesId = Id;
                cameraForm.ShowDialog();
            }
            else
            {
                if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Stream stream = this.openFileDialog1.OpenFile();
                    byte[] img = new byte[stream.Length];
                    stream.Read(img, 0, (int)stream.Length);
                    SalesDal.upLoadFile(img, this.Id);
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                if (Add())
                {
                    upload();
                    clearData();
                }
            }
            else
            {
                upload();
            }
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MasterTemplate_CommandCellClick(object sender, EventArgs e)
        {
            var el = (GridViewCellEventArgs)e;
            el.Row.Delete();
        }
        protected override bool GetNotNullColumn(GridViewCellInfo cell)
        {
            return cell.ColumnInfo.IsVisible && !cell.ColumnInfo.ReadOnly &&
                cell.ColumnInfo.Name != "remarks";
        }

        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "dimensions")
            {
                string product_name = Convert.ToString(e.Row.Cells["product_name"].Value);

                DataTable dt = new DataTable();
                dt.Columns.Add("dimensions");
                Hashtable hs = new Hashtable();
                foreach (DataRow dr in Data.DataUtil.ProductTableWithOutAll.Rows)
                {
                    if (Convert.ToString(dr["name"]) == product_name || product_name == "")
                    {
                        var val = dr["dimensions"];
                        if (!hs.ContainsKey(val))
                        {
                            var newDr = dt.NewRow();
                            newDr[0] = val;
                            dt.Rows.Add(newDr);
                            hs.Add(val, null);
                        }
                    }
                }
                ((GridViewComboBoxColumn)this.radGridView1.Columns["dimensions"]).DataSource = dt;


            }
            if (e.Column.Name == "color")
            {

                string product_name = Convert.ToString(e.Row.Cells["product_name"].Value);
                string dimensions = Convert.ToString(e.Row.Cells["dimensions"].Value);
                DataTable dt = new DataTable();
                dt.Columns.Add("color");
                Hashtable hs = new Hashtable();
                foreach (DataRow dr in Data.DataUtil.ProductTableWithOutAll.Rows)
                {
                    if ((product_name != "" && dimensions == "") ||
                        (Convert.ToString(dr["name"]) == product_name && dimensions == "")
                        || (Convert.ToString(dr["dimensions"]) == dimensions && product_name == "")
                        || (Convert.ToString(dr["name"]) == product_name && Convert.ToString(dr["dimensions"]) == dimensions)

                        )
                    {
                        var val = dr["color"];
                        if (!hs.ContainsKey(val))
                        {
                            var newDr = dt.NewRow();
                            newDr[0] = val;
                            dt.Rows.Add(newDr);
                            hs.Add(val, null);
                        }
                    }
                } 
                ((GridViewComboBoxColumn)this.radGridView1.Columns["color"]).DataSource = dt;
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            新增商品 f = new 新增商品();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
                
            }
        }
    }
}
