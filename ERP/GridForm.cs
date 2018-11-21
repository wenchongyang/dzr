using ERP.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace ERP
{
    public class GridForm : Telerik.WinControls.UI.ShapedForm
    {
        private string tablename;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem 更新ToolStripMenuItem;
        private ToolStripMenuItem 取消ToolStripMenuItem;
    
        public DataSet ds { private set; get; }
        private RadGridView __radGridView1;

        protected void InitGrid(RadGridView radGridView1, string tablename)
        {
          
            InitGrid(radGridView1, tablename, false);
        }

        protected bool isAllOrNull(RadDropDownList ddl) {
            return !string.IsNullOrWhiteSpace((string)ddl.SelectedValue) && "--全部--" != (string)ddl.SelectedValue;
        }
        protected void InitGrid(RadGridView radGridView1, string tablename, bool hasProduct)
        {
            this.InitializeComponent();
            this.tablename = tablename;

            this.__radGridView1 = radGridView1;
            radGridView1.UserAddingRow  += radGridView1_UserAddingRow;
            
            radGridView1.UserDeletingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.radGridView1_UserDeletingRow);
            //radGridView1.RowsChanging +=radGridView1_RowsChanging;
            radGridView1.UserAddedRow +=radGridView1_UserAddedRow;
            
            radGridView1.DataError += new Telerik.WinControls.UI.GridViewDataErrorEventHandler(this.radGridView1_DataError);
            radGridView1.CellEndEdit+=radGridView1_CellEndEdit;

            ds = new DataSet();
            try
            {
                RadButton searchBtn = (RadButton)this.Controls.Find("searchBtn", true)[0];
                searchBtn.Click += searchBtn_Click;
            }
            catch { }
             try
            {
                RadButton exportBtn = (RadButton)this.Controls.Find("exportBtn", true)[0];
                exportBtn.Click += exportBtn_Click;
            }
             catch { }
            
            try
            {
                DateTimePicker dateTimePicker1 = (DateTimePicker)this.Controls.Find("dateTimePicker1", true)[0];
                dateTimePicker1.Value = DateTime.Now.AddDays(-14);
            }
            catch { }

            if (hasProduct)
            {
                RadDropDownList product_nameDdl = (RadDropDownList)this.Controls.Find("product_nameDdl", true)[0],
                   colorDdl = (RadDropDownList)this.Controls.Find("colorDdl", true)[0],
                  dimensionsDdl = (RadDropDownList)this.Controls.Find("dimensionsDdl", true)[0];
                ERP.Data.ProductDal.BindProduct(product_nameDdl, colorDdl, dimensionsDdl,true);
            }


            try
            {
                RadButton addBtn = (RadButton)this.Controls.Find("addBtn", true)[0];
                addBtn.Click += addBtn_Click;
            }
            catch { }
            BindData();
        }

        private void radGridView1_UserAddedRow(object sender, GridViewRowEventArgs e)
        {

            this.BindData();
        }
        private System.Windows.Forms.SaveFileDialog saveFileDialog1 = new SaveFileDialog ();
        private void exportBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt="xls";
            saveFileDialog1.Filter = "Microsoft Excel|*.xls";
            saveFileDialog1.FileName = this.Text;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportExcel.export(saveFileDialog1.FileName, __radGridView1);
            }
        }

        private void radGridView1_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.ItemChanged)
            {
                IEnumerable<GridViewRowInfo> drs = e.NewItems.Cast<GridViewRowInfo>();
                if (CheckRows(drs))
                {

                    Update(drs);
                }
                else {
                    e.Cancel = true;
                }
               
            }
        }

        protected virtual bool CheckRow(GridViewRowInfo dr)
        {
            foreach (GridViewCellInfo cell in dr.Cells)
            {
                if (GetNotNullColumn(cell))
                {
                    if (cell.Value == null || cell.Value == DBNull.Value)
                    {
                        dr.ErrorText = cell.ColumnInfo.HeaderText + "是必填项";
                        cell.BeginEdit();
                        return false;
                    }
                }
            }
            dr.ErrorText = null;
            return true;
        }
        protected virtual bool GetNotNullColumn(GridViewCellInfo cell) { return false; }
        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!CheckRow(e.Row))
            {
                //e.Row.Cells[e.ColumnIndex].BeginEdit();
            }
            else
            {
                bool allOk = true;
                foreach (GridViewCellInfo cell in e.Row.Cells)
                {
                    if (GetNotNullColumn(cell))
                    {
                        if (cell.Value == null || cell.Value == DBNull.Value)
                        {
                            //cell.BeginEdit();
                            allOk = false;
                            break;
                        }
                    }

                }

                if (allOk&&!e.Row.IsPinned)
                {
                    GridCellElement cellElement = this.__radGridView1.TableElement.GetCellElement(e.Row, e.Column);
                    Point cellLocation = this.__radGridView1.PointToScreen(cellElement.ControlBoundingRectangle.Location);
                    cellLocation.Y = cellLocation.Y + 10;
                    更新ToolStripMenuItem.Tag = e.Row;
                    contextMenuStrip1.Show(cellLocation);
                }
                
            }
        }
        public void getPorductSearch(List<DictionaryEntry> list, ref string whereStr,
           RadDropDownList product_nameDdl, RadDropDownList colorDdl, RadDropDownList dimensionsDdl, bool isName)
        {
            if (!string.IsNullOrWhiteSpace((string)product_nameDdl.SelectedValue)
                   && !"--全部--".Equals(product_nameDdl.SelectedValue)
                   )
            {
                list.Add(new DictionaryEntry("product_name", product_nameDdl.SelectedValue));
                whereStr += " and " + (isName ? "name" : "product_name") + "= @product_name";
            }
            if (!string.IsNullOrWhiteSpace((string)colorDdl.SelectedValue)

                && !"--全部--".Equals(colorDdl.SelectedValue)
                )
            {
                list.Add(new DictionaryEntry("color", colorDdl.SelectedValue));
                whereStr += " and color = @color";
            }
            if (!string.IsNullOrWhiteSpace((string)dimensionsDdl.SelectedValue)
                && !"--全部--".Equals(dimensionsDdl.SelectedValue)
                )
            {
                list.Add(new DictionaryEntry("dimensions", dimensionsDdl.SelectedValue));
                whereStr += " and dimensions = @dimensions";
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            this.__radGridView1.AllowAddNewRow = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        protected  virtual  void AddComplete(GridViewRowInfo[] dr) { }
        protected virtual void UpdateComplete(GridViewRowInfo dr) { }
        protected virtual void DeteteComplete(int id) { }

        protected virtual bool Adding(GridViewRowInfo[] dr) { return true; }
        protected virtual bool Updateing(GridViewRowInfo dr) { return true; }
        protected virtual bool Deteteing(int id) { return true; }

        private void radGridView1_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            if (CheckRows(e.Rows) && Adding(e.Rows))
            {
                DataUtil.Add(this.tablename, e.Rows);
                AddComplete(e.Rows);
                //this.BindData();
            }
            else
            {
                e.Cancel = true;
            }
        }
        

        private void radGridView1_DataError(object sender, Telerik.WinControls.UI.GridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }


        private void radGridView1_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            this.DeleteQuery((int)e.Rows[0].Cells["id"].Value);

        }

        protected virtual bool CheckRows(IEnumerable<GridViewRowInfo> drs)
        {
            foreach (var dr in drs) {
                if (!CheckRow(dr)) {
                    MessageBox.Show(dr.ErrorText);
                    return false;
                }
            }
            return true;
        }

        public virtual void DeleteQuery(int id)
        {
            DataUtil.Delete(tablename, id);
            DeteteComplete(id);
            BindData();
        }
        public virtual void BindDataEnd()
        {

        }
        public void BindData()
        {
            string sql = "";
            __radGridView1.DataSource = DataUtil.BindData(tablename, GetWheres(out sql), sql);
            BindDataEnd();
        }
        public virtual DictionaryEntry[] GetWheres(out string whereStr) { whereStr = string.Empty; return null; }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新ToolStripMenuItem,
            this.取消ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消ToolStripMenuItem.Text = "取消";
            this.取消ToolStripMenuItem.Click += new System.EventHandler(this.取消ToolStripMenuItem_Click);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "GridForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridViewRowInfo dr = (GridViewRowInfo)((ToolStripMenuItem)sender).Tag;
            if (Updateing(dr))
            {
                Update(dr);
                UpdateComplete(dr);
            }
        }
        public virtual void Update(GridViewRowInfo dr)
        {
            DataUtil.Update(tablename, dr);
        }

        public virtual void Update(IEnumerable<GridViewRowInfo> drs)
        {
            DataUtil.Update(tablename, drs);
        }
        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BindData();
        }


    }
}
