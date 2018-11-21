namespace ERP
{
    partial class 销售明细
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn43 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn44 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn7 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn8 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn4 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn45 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn46 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn47 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn48 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn49 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn50 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn51 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn52 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn53 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn54 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn55 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn56 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor4 = new Telerik.WinControls.Data.SortDescriptor();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.userCbx = new System.Windows.Forms.ComboBox();
            this.storeCbx = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
            this.rqlxCbx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.BackColor = System.Drawing.Color.Transparent;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.EnableKeyMap = true;
            this.radGridView1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.radGridView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(143)))), ((int)(((byte)(160)))));
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 81);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.Caption = "Products";
            gridViewTextBoxColumn43.EnableExpressionEditor = false;
            gridViewTextBoxColumn43.FieldName = "store_name";
            gridViewTextBoxColumn43.HeaderText = "门店";
            gridViewTextBoxColumn43.Name = "store_name";
            gridViewTextBoxColumn43.ReadOnly = true;
            gridViewTextBoxColumn43.Width = 80;
            gridViewTextBoxColumn44.EnableExpressionEditor = false;
            gridViewTextBoxColumn44.FieldName = "bill_id";
            gridViewTextBoxColumn44.HeaderText = "订单编号";
            gridViewTextBoxColumn44.Name = "bill_id";
            gridViewTextBoxColumn44.ReadOnly = true;
            gridViewTextBoxColumn44.Width = 68;
            gridViewDateTimeColumn7.EnableExpressionEditor = false;
            gridViewDateTimeColumn7.FieldName = "create_time";
            gridViewDateTimeColumn7.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn7.FormatString = "{0:yyyy-MM-dd}";
            gridViewDateTimeColumn7.HeaderText = "订单日期";
            gridViewDateTimeColumn7.Name = "create_time";
            gridViewDateTimeColumn7.Width = 72;
            gridViewDateTimeColumn8.EnableExpressionEditor = false;
            gridViewDateTimeColumn8.FieldName = "delivery_date";
            gridViewDateTimeColumn8.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn8.FormatString = "{0:MM-dd}";
            gridViewDateTimeColumn8.HeaderText = "预送";
            gridViewDateTimeColumn8.Name = "delivery_date";
            gridViewComboBoxColumn4.DisplayMember = "key";
            gridViewComboBoxColumn4.EnableExpressionEditor = false;
            gridViewComboBoxColumn4.FieldName = "status";
            gridViewComboBoxColumn4.HeaderText = "状态";
            gridViewComboBoxColumn4.Name = "status";
            gridViewComboBoxColumn4.ValueMember = "val";
            gridViewComboBoxColumn4.Width = 46;
            gridViewTextBoxColumn45.EnableExpressionEditor = false;
            gridViewTextBoxColumn45.FieldName = "product_name";
            gridViewTextBoxColumn45.HeaderText = "商品名称";
            gridViewTextBoxColumn45.Name = "product_name";
            gridViewTextBoxColumn45.ReadOnly = true;
            gridViewTextBoxColumn45.Width = 67;
            gridViewTextBoxColumn46.EnableExpressionEditor = false;
            gridViewTextBoxColumn46.FieldName = "dimensions";
            gridViewTextBoxColumn46.HeaderText = "规格";
            gridViewTextBoxColumn46.Name = "dimensions";
            gridViewTextBoxColumn46.ReadOnly = true;
            gridViewTextBoxColumn47.EnableExpressionEditor = false;
            gridViewTextBoxColumn47.FieldName = "color";
            gridViewTextBoxColumn47.HeaderText = "颜色";
            gridViewTextBoxColumn47.Name = "color";
            gridViewTextBoxColumn47.ReadOnly = true;
            gridViewTextBoxColumn47.Width = 38;
            gridViewTextBoxColumn48.EnableExpressionEditor = false;
            gridViewTextBoxColumn48.FieldName = "count";
            gridViewTextBoxColumn48.HeaderText = "数量（件）";
            gridViewTextBoxColumn48.Name = "count";
            gridViewTextBoxColumn48.ReadOnly = true;
            gridViewTextBoxColumn48.Width = 20;
            gridViewTextBoxColumn49.EnableExpressionEditor = false;
            gridViewTextBoxColumn49.FieldName = "guide_price";
            gridViewTextBoxColumn49.HeaderText = "单价";
            gridViewTextBoxColumn49.IsVisible = false;
            gridViewTextBoxColumn49.Name = "guide_price";
            gridViewTextBoxColumn49.Width = 38;
            gridViewTextBoxColumn50.EnableExpressionEditor = false;
            gridViewTextBoxColumn50.FieldName = "discount";
            gridViewTextBoxColumn50.HeaderText = "折扣";
            gridViewTextBoxColumn50.Name = "discount";
            gridViewTextBoxColumn50.ReadOnly = true;
            gridViewTextBoxColumn50.Width = 43;
            gridViewTextBoxColumn51.EnableExpressionEditor = false;
            gridViewTextBoxColumn51.FieldName = "need_pay";
            gridViewTextBoxColumn51.HeaderText = "应付金额";
            gridViewTextBoxColumn51.Name = "need_pay";
            gridViewTextBoxColumn51.ReadOnly = true;
            gridViewTextBoxColumn51.Width = 71;
            gridViewTextBoxColumn52.EnableExpressionEditor = false;
            gridViewTextBoxColumn52.FieldName = "actually_pay";
            gridViewTextBoxColumn52.HeaderText = "实付金额";
            gridViewTextBoxColumn52.Name = "actually_pay";
            gridViewTextBoxColumn52.ReadOnly = true;
            gridViewTextBoxColumn52.Width = 69;
            gridViewTextBoxColumn53.EnableExpressionEditor = false;
            gridViewTextBoxColumn53.FieldName = "paymet_method1";
            gridViewTextBoxColumn53.HeaderText = "付款方式";
            gridViewTextBoxColumn53.Name = "paymet_method1";
            gridViewTextBoxColumn53.ReadOnly = true;
            gridViewTextBoxColumn53.Width = 68;
            gridViewTextBoxColumn54.EnableExpressionEditor = false;
            gridViewTextBoxColumn54.FieldName = "customer_name";
            gridViewTextBoxColumn54.HeaderText = "顾客";
            gridViewTextBoxColumn54.Name = "customer_name";
            gridViewTextBoxColumn54.ReadOnly = true;
            gridViewTextBoxColumn54.Width = 43;
            gridViewTextBoxColumn55.EnableExpressionEditor = false;
            gridViewTextBoxColumn55.FieldName = "user_name";
            gridViewTextBoxColumn55.HeaderText = "导购员";
            gridViewTextBoxColumn55.Name = "user_name";
            gridViewTextBoxColumn55.ReadOnly = true;
            gridViewTextBoxColumn55.Width = 55;
            gridViewDecimalColumn7.EnableExpressionEditor = false;
            gridViewDecimalColumn7.FieldName = "commission";
            gridViewDecimalColumn7.HeaderText = "提成";
            gridViewDecimalColumn7.Name = "commission";
            gridViewDecimalColumn7.Width = 67;
            gridViewTextBoxColumn56.EnableExpressionEditor = false;
            gridViewTextBoxColumn56.FieldName = "cal_way";
            gridViewTextBoxColumn56.HeaderText = "提成算法";
            gridViewTextBoxColumn56.Name = "cal_way";
            gridViewTextBoxColumn56.Width = 100;
            gridViewDecimalColumn8.EnableExpressionEditor = false;
            gridViewDecimalColumn8.FieldName = "margins";
            gridViewDecimalColumn8.HeaderText = "毛利";
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "margins";
            gridViewDecimalColumn8.Width = 70;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn43,
            gridViewTextBoxColumn44,
            gridViewDateTimeColumn7,
            gridViewDateTimeColumn8,
            gridViewComboBoxColumn4,
            gridViewTextBoxColumn45,
            gridViewTextBoxColumn46,
            gridViewTextBoxColumn47,
            gridViewTextBoxColumn48,
            gridViewTextBoxColumn49,
            gridViewTextBoxColumn50,
            gridViewTextBoxColumn51,
            gridViewTextBoxColumn52,
            gridViewTextBoxColumn53,
            gridViewTextBoxColumn54,
            gridViewTextBoxColumn55,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn56,
            gridViewDecimalColumn8});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor4.PropertyName = "column4";
            this.radGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor4});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(993, 563);
            this.radGridView1.TabIndex = 52;
            this.radGridView1.Text = "radGridView2";
            // 
            // userCbx
            // 
            this.userCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.userCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCbx.ForeColor = System.Drawing.Color.Black;
            this.userCbx.FormattingEnabled = true;
            this.userCbx.Location = new System.Drawing.Point(465, 13);
            this.userCbx.Margin = new System.Windows.Forms.Padding(4);
            this.userCbx.Name = "userCbx";
            this.userCbx.Size = new System.Drawing.Size(160, 24);
            this.userCbx.TabIndex = 57;
            // 
            // storeCbx
            // 
            this.storeCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.storeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCbx.ForeColor = System.Drawing.Color.Black;
            this.storeCbx.FormattingEnabled = true;
            this.storeCbx.Location = new System.Drawing.Point(108, 44);
            this.storeCbx.Margin = new System.Windows.Forms.Padding(4);
            this.storeCbx.Name = "storeCbx";
            this.storeCbx.Size = new System.Drawing.Size(139, 24);
            this.storeCbx.TabIndex = 56;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("FangSong", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(264, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(139, 26);
            this.dateTimePicker2.TabIndex = 54;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("FangSong", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 26);
            this.dateTimePicker1.TabIndex = 55;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel3.Location = new System.Drawing.Point(34, 44);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 52;
            this.radLabel3.Text = "门店：";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel6.Location = new System.Drawing.Point(398, 12);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(74, 22);
            this.radLabel6.TabIndex = 53;
            this.radLabel6.Text = "导购员：";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("FangSong", 12F);
            this.radButton1.Location = new System.Drawing.Point(648, 13);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(98, 26);
            this.radButton1.TabIndex = 51;
            this.radButton1.Text = "查询";
            this.radButton1.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // statusCbx
            // 
            this.statusCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.statusCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCbx.ForeColor = System.Drawing.Color.Black;
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Location = new System.Drawing.Point(465, 46);
            this.statusCbx.Margin = new System.Windows.Forms.Padding(4);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(160, 24);
            this.statusCbx.TabIndex = 59;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(398, 47);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 58;
            this.radLabel2.Text = "状态：";
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.exportBtn.Location = new System.Drawing.Point(648, 44);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 26);
            this.exportBtn.TabIndex = 60;
            this.exportBtn.Text = "导出";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // rqlxCbx
            // 
            this.rqlxCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.rqlxCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rqlxCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rqlxCbx.ForeColor = System.Drawing.Color.Black;
            this.rqlxCbx.FormattingEnabled = true;
            this.rqlxCbx.Items.AddRange(new object[] {
            "订单日期",
            "预送货日"});
            this.rqlxCbx.Location = new System.Drawing.Point(12, 16);
            this.rqlxCbx.Name = "rqlxCbx";
            this.rqlxCbx.Size = new System.Drawing.Size(90, 24);
            this.rqlxCbx.TabIndex = 61;
            // 
            // 销售明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 648);
            this.Controls.Add(this.rqlxCbx);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.statusCbx);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.userCbx);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.storeCbx);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel3);
            this.Name = "销售明细";
            this.Text = "销售明细";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.销售明细_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton exportBtn;
        public System.Windows.Forms.ComboBox rqlxCbx;
        public System.Windows.Forms.ComboBox userCbx;
        public System.Windows.Forms.ComboBox storeCbx;
        public System.Windows.Forms.ComboBox statusCbx;
    }
}
