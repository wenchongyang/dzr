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
    public partial class 商品管理 : GridForm
    {
        public 商品管理()
        {
            InitializeComponent();
            InitGrid(this.radGridView1, "product",true);
            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                addBtn.Visible = false;
                this.radGridView1.Columns["delete"].IsVisible = this.radGridView1.Columns["edit"].IsVisible = false;
            }
            
        }
        public override void BindDataEnd()
        {
            Data.DataUtil.LoadProduct();
        }
        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = " ";
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            getPorductSearch(list, ref whereStr, product_nameDdl, colorDdl, dimensionsDdl,true);
            return list.ToArray();

        }
        public override void Update(GridViewRowInfo dr)
        {
            ProductDal.Update(dr);
            DataUtil.LoadProduct();
            //DataUtil.Update(tablename, dr);
        }

        protected override bool CheckRows(IEnumerable<GridViewRowInfo> drs)
        {

            return base.CheckRows(drs);
        }

        protected override bool GetNotNullColumn(GridViewCellInfo cell)
        {
            return cell.ColumnInfo.IsVisible && !cell.ColumnInfo.ReadOnly && cell.ColumnInfo.Name != "remarks";
        }

       

        private void MasterTemplate_CommandCellClick(object sender, EventArgs e)
        {
            GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
            if (el.Data.Name == "edit")
            {
                el.RowInfo.Cells[1].BeginEdit();
            }
            else if (el.Data.Name == "delete")
            {
                if (MessageBox.Show("是否需要删除", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProductDal.DelProduct((int)el.RowInfo.Cells["id"].Value);
                    this.BindData();
                }
            }
        }
        protected override bool Adding(GridViewRowInfo[] dr)
        {
            return CheckSameProd(dr);
        }


        private bool CheckSameProd(GridViewRowInfo[] newRow)
        {
            Hashtable k = new Hashtable();
            bool same = false;
            foreach (var dr in this.radGridView1.Rows)
            {
                string key = "" + dr.Cells["name"].Value.ToString().Trim() + dr.Cells["dimensions"].Value.ToString().Trim() + dr.Cells["color"].Value.ToString().Trim();
                if (!k.ContainsKey(key))
                {
                    k.Add(key, null);
                }
                else
                {
                    same = true;
                }

            }
            if (null != newRow)
                foreach (var dr in newRow)
                {

                    string key = "" + dr.Cells["name"].Value.ToString().Trim() + dr.Cells["dimensions"].Value.ToString().Trim() + dr.Cells["color"].Value.ToString().Trim();
                    if (!k.ContainsKey(key))
                    {
                        k.Add(key, null);
                    }
                    else
                    {
                        same = true;
                    }

                }
            if (same)
            {
                MessageBox.Show("有重复商品！核对");
            }
            return !same;
        }
        protected override bool Updateing(GridViewRowInfo dr)
        {
            return CheckSameProd(null);
        }
        protected override void AddComplete(GridViewRowInfo[] drs)
        {
            StockDal stockDal = new StockDal();
            foreach (GridViewRowInfo dr in drs) {
                stockDal.InitStock();
            }
            DataUtil.LoadProduct();
            base.AddComplete(drs);
        }

        
    }
}
