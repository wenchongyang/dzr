using ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ERP
{
    public partial class 新增商品 : BaseForm
    {
         
        public 新增商品()
            : base("product")
        {
            InitializeComponent();
            this.product_nameDdl.DataSource = Data.DataUtil.ProductTableWithOutAll.DefaultView.ToTable(true, "name");
        }
        public override void Create(List<System.Collections.DictionaryEntry> list)
        {

            long count = (long)Data.DataUtil.ExecuteScalar("select count(1) from product where name = '" + this.product_nameDdl.Text + "' and dimensions='" + this.dimensionsTbx.Text + "' and color = '" + this.colorTbx.Text + "' ");
            
            if (count > 0) {
                MessageBox.Show("已存在该商品，请不要重复添加");
                return;
            }
            base.Create(list);
            ERP.Data.DataUtil.LoadProduct();
            StockDal dal = new StockDal();
            dal.InitStock();
        }

    }
}
