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
    public partial class 订货 : BaseForm
    {
        public int ProductId
        {
            get;
            set;
        }
        public 订货()
            : base("productorder")
        {
            InitializeComponent();
            Data.DataUtil.BindEnum2(statusCbx, typeof(Data.DataUtil.OrderStatus2), false);
            this.radDateTimePicker1.Value = DateTime.Now;
           

        }

        public override List<DictionaryEntry> Add(List<DictionaryEntry> list)
        {
            list.Add(new DictionaryEntry("status", 0));
            list.Add(new DictionaryEntry("product_id", ProductId));
            list.Add(new DictionaryEntry("create_time", DateTime.Now));
            list.Add(new DictionaryEntry("create_user", UsersDal.CurUser.UserId));
            return list;
        }

        public override void LoadInfo()
        {

            if (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员)
            {
                this.priceLab.Visible = this.priceTbx.Visible = false;
            }
            else
            {
                this.priceLab.Visible = this.priceTbx.Visible = true;
            }
            if (Id == 0)
            {
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
                this.priceLab.Visible = this.priceTbx.Visible = false;
                this.statusCbx.SelectedIndex = 0;
                this.radLabel4.Visible = this.radDateTimePicker1.Visible = this.statusCbx.Visible = false;
            }
        }
        public override void BindEnd()
        {
            if (UsersDal.CurUser.UserRole != UsersDal.Role.超级管理员)
            {
                this.statusCbx.Enabled = false;
            }
            else
            {
                this.statusCbx.SelectedIndex = 1;
            }
        }
        OrderDal orderDal = new OrderDal();
        public override void Update(List<DictionaryEntry> list)
        {
            if (this.ProductId == 0) {
                int id = 0;
                int.TryParse(this.productIdTbx.Text, out id);
                this.ProductId = id;
            }
            orderDal.update(list, (int)this.countTbx.Value, this.ProductId,this.Id,this.statusCbx.SelectedIndex);
        }
        public override void Create(List<DictionaryEntry> list)
        {
            list.Add(new DictionaryEntry("create_time",DateTime.Now));
            list.Add(new DictionaryEntry("create_user", UsersDal.CurUser.UserId));
            orderDal.create(list, (int)this.countTbx.Value, this.ProductId);
        }
    }
}
