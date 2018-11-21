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
    public partial class 返厂 : BaseForm
    {
        public int ProductId
        {
            get;
            set;
        }
        public 返厂()
            : base("productsentback")
        {
            InitializeComponent();
            Data.DataUtil.BindEnum2(statusCbx, typeof(Data.DataUtil.BackStatus2), false);
        }
        public override void LoadInfo()
        {
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
                 this.radDateTimePicker1.Value = DateTime.Now;

             }

             this.statusCbx.Visible = this.remarksTbx.Visible = this.radLabel4.Visible 
                 = this.radLabel7 .Visible = this.radDateTimePicker1.Visible = false;
         }
         else {
             this.countTbx.Enabled = false;
             this.reasonsTbx.Enabled = false;
         }
        }
        public override void BindEnd()
        {
            this.statusCbx.SelectedIndex = 1;
        }
        public override void Update(List<DictionaryEntry> list)
        {
            Data.DataUtil.ExecuteNonQuery("update productsentback set plant_time = @plant_time ,remarks=@remarks,status=@status where id=@id", list.ToArray());
        }
        public override void Create(List<DictionaryEntry> list)
        {
            list.Add(new DictionaryEntry("status", 0));
            list.Add(new DictionaryEntry("product_id", ProductId));
            list.Add(new DictionaryEntry("create_time", DateTime.Now));
            list.Add(new DictionaryEntry("create_user", UsersDal.CurUser.UserId));
            ProductDal.Back(list, Convert.ToInt32(this.countTbx.Value), ProductId);
        }
    }
}

