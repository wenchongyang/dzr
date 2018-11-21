namespace ERP
{
    partial class 订单出库列表
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.bill_idTbx = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.storeCbx = new System.Windows.Forms.ComboBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.customTbx = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rqlxCbx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bill_idTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.BackColor = System.Drawing.Color.Transparent;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.EnableHotTracking = false;
            this.radGridView1.EnableKeyMap = true;
            this.radGridView1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.radGridView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(143)))), ((int)(((byte)(160)))));
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 85);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(4);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.Caption = "Products";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "store_name";
            gridViewTextBoxColumn1.HeaderText = "门店";
            gridViewTextBoxColumn1.Name = "store_name";
            gridViewTextBoxColumn1.Width = 119;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "bill_id";
            gridViewTextBoxColumn2.HeaderText = "订单编号";
            gridViewTextBoxColumn2.Name = "bill_id";
            gridViewTextBoxColumn2.Width = 64;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "delivery_date";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "交货日期";
            gridViewDateTimeColumn1.Name = "delivery_date";
            gridViewDateTimeColumn1.Width = 76;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "delivery_pay";
            gridViewDecimalColumn1.HeaderText = "运费";
            gridViewDecimalColumn1.Name = "delivery_pay";
            gridViewDecimalColumn1.Width = 77;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "re_pay";
            gridViewDecimalColumn2.HeaderText = "余款";
            gridViewDecimalColumn2.Name = "re_pay";
            gridViewDecimalColumn2.Width = 90;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "customer_name";
            gridViewTextBoxColumn3.HeaderText = "顾客姓名";
            gridViewTextBoxColumn3.Name = "customer_name";
            gridViewTextBoxColumn3.Width = 55;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "phone";
            gridViewTextBoxColumn4.HeaderText = "联系方式";
            gridViewTextBoxColumn4.Name = "phone";
            gridViewTextBoxColumn4.Width = 92;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "address";
            gridViewTextBoxColumn5.HeaderText = "地址";
            gridViewTextBoxColumn5.Name = "address";
            gridViewTextBoxColumn5.Width = 114;
            gridViewTextBoxColumn6.DisableHTMLRendering = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "sales_detail";
            gridViewTextBoxColumn6.HeaderText = "商品清单";
            gridViewTextBoxColumn6.Name = "sales_detail";
            gridViewTextBoxColumn6.Width = 117;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewComboBoxColumn1.DisplayMember = "key";
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "status";
            gridViewComboBoxColumn1.HeaderText = "状态";
            gridViewComboBoxColumn1.Name = "status";
            gridViewComboBoxColumn1.ValueMember = "val";
            gridViewComboBoxColumn1.Width = 47;
            gridViewCommandColumn1.DefaultText = "出库";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "id";
            gridViewCommandColumn1.HeaderText = "出库";
            gridViewCommandColumn1.Name = "out_stock";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 47;
            gridViewCommandColumn2.DefaultText = "修改";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "id";
            gridViewCommandColumn2.HeaderText = "编辑";
            gridViewCommandColumn2.Name = "edit";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 47;
            gridViewCommandColumn3.DefaultText = "打印";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.FieldName = "id";
            gridViewCommandColumn3.HeaderText = "打印";
            gridViewCommandColumn3.Name = "print";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 41;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewComboBoxColumn1,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 565);
            this.radGridView1.TabIndex = 33;
            this.radGridView1.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridView1_CommandCellClick);
            // 
            // radButton3
            // 
            this.radButton3.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton3.Location = new System.Drawing.Point(866, 8);
            this.radButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(103, 32);
            this.radButton3.TabIndex = 32;
            this.radButton3.Text = "查询";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // bill_idTbx
            // 
            this.bill_idTbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bill_idTbx.Location = new System.Drawing.Point(528, 11);
            this.bill_idTbx.Margin = new System.Windows.Forms.Padding(4);
            this.bill_idTbx.Name = "bill_idTbx";
            this.bill_idTbx.Size = new System.Drawing.Size(200, 24);
            this.bill_idTbx.TabIndex = 30;
            this.bill_idTbx.TabStop = false;
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(444, 13);
            this.radLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(90, 22);
            this.radLabel6.TabIndex = 29;
            this.radLabel6.Text = "订单编号：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "{yyyy-MM-DD}";
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 9);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 26);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "{yyyy-MM-DD}";
            this.dateTimePicker2.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(278, 10);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(160, 26);
            this.dateTimePicker2.TabIndex = 34;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(698, 52);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 29;
            this.radLabel2.Text = "状态：";
            // 
            // statusCbx
            // 
            this.statusCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Location = new System.Drawing.Point(754, 51);
            this.statusCbx.Margin = new System.Windows.Forms.Padding(4);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(116, 24);
            this.statusCbx.TabIndex = 35;
            // 
            // storeCbx
            // 
            this.storeCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.storeCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCbx.FormattingEnabled = true;
            this.storeCbx.Location = new System.Drawing.Point(70, 52);
            this.storeCbx.Margin = new System.Windows.Forms.Padding(4);
            this.storeCbx.Name = "storeCbx";
            this.storeCbx.Size = new System.Drawing.Size(162, 24);
            this.storeCbx.TabIndex = 46;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(13, 53);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 45;
            this.radLabel3.Text = "门店：";
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = true;
            this.radLabel4.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(407, 52);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(82, 22);
            this.radLabel4.TabIndex = 45;
            this.radLabel4.Text = "顾客姓名:";
            // 
            // customTbx
            // 
            this.customTbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTbx.Location = new System.Drawing.Point(490, 49);
            this.customTbx.Margin = new System.Windows.Forms.Padding(4);
            this.customTbx.Name = "customTbx";
            this.customTbx.Size = new System.Drawing.Size(200, 24);
            this.customTbx.TabIndex = 30;
            this.customTbx.TabStop = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rqlxCbx);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.statusCbx);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(995, 85);
            this.radPanel1.TabIndex = 47;
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
            this.rqlxCbx.Location = new System.Drawing.Point(3, 11);
            this.rqlxCbx.Name = "rqlxCbx";
            this.rqlxCbx.Size = new System.Drawing.Size(90, 24);
            this.rqlxCbx.TabIndex = 62;
            // 
            // 订单出库列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 650);
            this.Controls.Add(this.storeCbx);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.customTbx);
            this.Controls.Add(this.bill_idTbx);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "订单出库列表";
            this.Shape = this.roundRectShapeForm;
            this.Text = "订单出库";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bill_idTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadMaskedEditBox bill_idTbx;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ComboBox statusCbx;
        private System.Windows.Forms.ComboBox storeCbx;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadMaskedEditBox customTbx;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        public System.Windows.Forms.ComboBox rqlxCbx;
    }
}
