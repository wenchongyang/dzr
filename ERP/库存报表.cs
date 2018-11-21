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
    public partial class 库存报表 : GridForm
    {
        public 库存报表()
        {
            InitializeComponent();
            if (Data.UsersDal.CurUser.UserRole == Data.UsersDal.Role.店长 || Data.UsersDal.CurUser.UserRole == Data.UsersDal.Role.导购) {
                this.radGridView1.Columns["count"].IsVisible = false;
                this.radGridView1.Columns["in"].IsVisible = false;
                this.radGridView1.Columns["out"].IsVisible = false;
            }

            if (UsersDal.CurUser.UserRole == UsersDal.Role.总经理)
            {
                this.radGridView1.Columns["out"].IsVisible = this.radGridView1.Columns["in"].IsVisible = false;
            }
            InitGrid(this.radGridView1, "stock",true);
        }

        public override System.Collections.DictionaryEntry[] GetWheres(out string whereStr)
        {

            whereStr = "";
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            getPorductSearch(list, ref whereStr, product_nameDdl, colorDdl, dimensionsDdl,false);
            return list.ToArray();

        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
             GridDataCellElement el = ((Telerik.WinControls.UI.GridDataCellElement)sender);
             if (el.Data.Name == "in")
             {
                 订货 f = new 订货();
                 f.ProductId = (int)el.Value;
                 f.ShowDialog();
             }
             if (el.Data.Name == "out")
             {
                 返厂 f = new 返厂();
                 f.ProductId = (int)el.Value;
                 f.ShowDialog();
             }
             if (el.Data.Name == "dsxq")
             {
                 待送详情 f = new 待送详情();
                 f.ProductId = (int)el.Value;
                 f.ShowDialog();
             }
             if (el.Data.Name == "ckxq")
             {
                 出入库详情 f = new 出入库详情();
                 f.ProductId = (int)el.Value;
                 f.FormType = 出入库详情.Type.出库详情;
                 f.ShowDialog();
             }
             if (el.Data.Name == "rkxq")
             {
                 出入库详情 f = new 出入库详情();
                 f.ProductId = (int)el.Value;
                 f.FormType = 出入库详情.Type.入库详情;
                 f.ShowDialog();
             }
        }

    }
}
