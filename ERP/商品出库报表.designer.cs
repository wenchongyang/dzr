namespace ERP
{
    partial class 商品出库报表
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn3 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn4 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.storeCbx = new System.Windows.Forms.ComboBox();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.colorDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.dimensionsDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.product_nameDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.searchBtn = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.BackColor = System.Drawing.Color.Transparent;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGridView1.EnableKeyMap = true;
            this.radGridView1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.radGridView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(143)))), ((int)(((byte)(160)))));
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 103);
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
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "ck_bill_id";
            gridViewTextBoxColumn11.HeaderText = "出库编号";
            gridViewTextBoxColumn11.Name = "ck_bill_id";
            gridViewTextBoxColumn11.Width = 115;
            gridViewComboBoxColumn3.DisplayMember = "name";
            gridViewComboBoxColumn3.EnableExpressionEditor = false;
            gridViewComboBoxColumn3.FieldName = "store_id";
            gridViewComboBoxColumn3.HeaderText = "门店";
            gridViewComboBoxColumn3.Name = "store_id";
            gridViewComboBoxColumn3.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewComboBoxColumn3.ValueMember = "id";
            gridViewComboBoxColumn3.Width = 56;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "product_id";
            gridViewTextBoxColumn12.HeaderText = "商品编号";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "product_id";
            gridViewTextBoxColumn12.Width = 111;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "product_name";
            gridViewTextBoxColumn13.HeaderText = "商品名称";
            gridViewTextBoxColumn13.Name = "product_name";
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "dimensions";
            gridViewTextBoxColumn14.HeaderText = "规格";
            gridViewTextBoxColumn14.Name = "dimensions";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "color";
            gridViewTextBoxColumn15.HeaderText = "颜色";
            gridViewTextBoxColumn15.Name = "color";
            gridViewTextBoxColumn15.Width = 64;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "count";
            gridViewTextBoxColumn16.HeaderText = "数量";
            gridViewTextBoxColumn16.Name = "count";
            gridViewTextBoxColumn16.Width = 38;
            gridViewDateTimeColumn2.CustomFormat = "yyyy-MM-dd";
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "complete_time";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn2.FormatString = "{0:yyyy-MM-dd}";
            gridViewDateTimeColumn2.HeaderText = "出库时间";
            gridViewDateTimeColumn2.Name = "complete_time";
            gridViewDateTimeColumn2.Width = 83;
            gridViewComboBoxColumn4.DisplayMember = "key";
            gridViewComboBoxColumn4.EnableExpressionEditor = false;
            gridViewComboBoxColumn4.FieldName = "is_store_out";
            gridViewComboBoxColumn4.HeaderText = "出库地";
            gridViewComboBoxColumn4.Name = "is_store_out";
            gridViewComboBoxColumn4.ValueMember = "val";
            gridViewComboBoxColumn4.Width = 53;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "remarks";
            gridViewTextBoxColumn17.HeaderText = "备注";
            gridViewTextBoxColumn17.Name = "remarks";
            gridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn17.Width = 132;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "bill_id";
            gridViewTextBoxColumn18.HeaderText = "订单编号";
            gridViewTextBoxColumn18.Name = "bill_id";
            gridViewTextBoxColumn18.Width = 100;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "customer_name";
            gridViewTextBoxColumn19.HeaderText = "客户姓名";
            gridViewTextBoxColumn19.Name = "customer_name";
            gridViewTextBoxColumn19.Width = 68;
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "phone";
            gridViewTextBoxColumn20.HeaderText = "联系电话";
            gridViewTextBoxColumn20.Name = "phone";
            gridViewTextBoxColumn20.Width = 96;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewComboBoxColumn3,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewDateTimeColumn2,
            gridViewComboBoxColumn4,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor2.PropertyName = "store_id";
            this.radGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 551);
            this.radGridView1.TabIndex = 21;
            this.radGridView1.Text = "radGridView2";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.storeCbx);
            this.radPanel1.Controls.Add(this.exportBtn);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.colorDdl);
            this.radPanel1.Controls.Add(this.dimensionsDdl);
            this.radPanel1.Controls.Add(this.product_nameDdl);
            this.radPanel1.Controls.Add(this.dateTimePicker2);
            this.radPanel1.Controls.Add(this.dateTimePicker1);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.searchBtn);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(995, 654);
            this.radPanel1.TabIndex = 22;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "ControlDefault";
            // 
            // storeCbx
            // 
            this.storeCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCbx.FormattingEnabled = true;
            this.storeCbx.Location = new System.Drawing.Point(99, 72);
            this.storeCbx.Margin = new System.Windows.Forms.Padding(4);
            this.storeCbx.Name = "storeCbx";
            this.storeCbx.Size = new System.Drawing.Size(272, 24);
            this.storeCbx.TabIndex = 46;
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.exportBtn.Location = new System.Drawing.Point(701, 44);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 26);
            this.exportBtn.TabIndex = 27;
            this.exportBtn.Text = "导出";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(34, 71);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 45;
            this.radLabel3.Text = "门店：";
            // 
            // colorDdl
            // 
            this.colorDdl.AutoCompleteDisplayMember = "color";
            this.colorDdl.DisplayMember = "color";
            this.colorDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorDdl.Location = new System.Drawing.Point(473, 42);
            this.colorDdl.Name = "colorDdl";
            this.colorDdl.Size = new System.Drawing.Size(155, 24);
            this.colorDdl.TabIndex = 48;
            this.colorDdl.ThemeName = "ControlDefault";
            // 
            // dimensionsDdl
            // 
            this.dimensionsDdl.AutoCompleteDisplayMember = "dimensions";
            this.dimensionsDdl.DisplayMember = "dimensions";
            this.dimensionsDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dimensionsDdl.Location = new System.Drawing.Point(99, 43);
            this.dimensionsDdl.Name = "dimensionsDdl";
            this.dimensionsDdl.Size = new System.Drawing.Size(272, 24);
            this.dimensionsDdl.TabIndex = 47;
            this.dimensionsDdl.ThemeName = "ControlDefault";
            // 
            // product_nameDdl
            // 
            this.product_nameDdl.AutoCompleteDisplayMember = "name";
            this.product_nameDdl.DisplayMember = "name";
            this.product_nameDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_nameDdl.Location = new System.Drawing.Point(473, 14);
            this.product_nameDdl.Name = "product_nameDdl";
            this.product_nameDdl.Size = new System.Drawing.Size(155, 24);
            this.product_nameDdl.TabIndex = 23;
            this.product_nameDdl.ThemeName = "ControlDefault";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(242, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 26);
            this.dateTimePicker2.TabIndex = 45;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(99, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 26);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(34, 15);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 44;
            this.radLabel2.Text = "日期：";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(701, 15);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(98, 26);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "查询";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(34, 43);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 22);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "规格：";
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = true;
            this.radLabel4.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(379, 44);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(57, 22);
            this.radLabel4.TabIndex = 1;
            this.radLabel4.Text = "颜色：";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(377, 15);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(90, 22);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "商品名称：";
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTitleBar1.Location = new System.Drawing.Point(1, 1);
            this.radTitleBar1.Name = "radTitleBar1";
            // 
            // 
            // 
            this.radTitleBar1.RootElement.ApplyShapeToControl = true;
            this.radTitleBar1.Size = new System.Drawing.Size(1006, 23);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "出库明细";
            // 
            // 商品出库报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 654);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radTitleBar1);
            this.Name = "商品出库报表";
            this.Text = "出库明细";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList product_nameDdl;
        private Telerik.WinControls.UI.RadDropDownList dimensionsDdl;
        private Telerik.WinControls.UI.RadDropDownList colorDdl;
        private Telerik.WinControls.UI.RadButton exportBtn;
        private System.Windows.Forms.ComboBox storeCbx;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
