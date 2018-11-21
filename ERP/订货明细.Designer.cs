namespace ERP
{
    partial class 订货明细
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
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
            this.radGridView1.Location = new System.Drawing.Point(0, 80);
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
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "product_id";
            gridViewTextBoxColumn1.HeaderText = "商品编号";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "product_id";
            gridViewTextBoxColumn1.Width = 68;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "product_name";
            gridViewTextBoxColumn2.HeaderText = "商品名称";
            gridViewTextBoxColumn2.Name = "product_name";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "dimensions";
            gridViewTextBoxColumn3.HeaderText = "规格";
            gridViewTextBoxColumn3.Name = "dimensions";
            gridViewTextBoxColumn3.Width = 89;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "color";
            gridViewTextBoxColumn4.HeaderText = "颜色";
            gridViewTextBoxColumn4.Name = "color";
            gridViewTextBoxColumn4.Width = 80;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "count";
            gridViewTextBoxColumn5.HeaderText = "数量";
            gridViewTextBoxColumn5.Name = "count";
            gridViewTextBoxColumn5.Width = 43;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "price";
            gridViewDecimalColumn1.HeaderText = "价格";
            gridViewDecimalColumn1.Name = "price";
            gridViewDecimalColumn1.Width = 66;
            gridViewDateTimeColumn1.CustomFormat = "yyyy-MM-dd";
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "create_time";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:yyyy-MM-dd}";
            gridViewDateTimeColumn1.HeaderText = "创建时间";
            gridViewDateTimeColumn1.Name = "create_time";
            gridViewDateTimeColumn1.Width = 83;
            gridViewComboBoxColumn1.DisplayMember = "key";
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "status";
            gridViewComboBoxColumn1.HeaderText = "状态";
            gridViewComboBoxColumn1.Name = "status";
            gridViewComboBoxColumn1.ValueMember = "val";
            gridViewComboBoxColumn1.Width = 81;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "remarks";
            gridViewTextBoxColumn6.HeaderText = "备注";
            gridViewTextBoxColumn6.Name = "remarks";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 100;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "order_time";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "订货时间";
            gridViewDateTimeColumn2.Name = "order_time";
            gridViewDateTimeColumn2.Width = 86;
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "complete_time";
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn3.HeaderText = "入库时间";
            gridViewDateTimeColumn3.Name = "complete_time";
            gridViewDateTimeColumn3.Width = 76;
            gridViewCommandColumn1.DefaultText = "修改";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "id";
            gridViewCommandColumn1.HeaderText = "修改";
            gridViewCommandColumn1.Name = "operate";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.DefaultText = "入库";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "id";
            gridViewCommandColumn2.HeaderText = "入库";
            gridViewCommandColumn2.Name = "complete";
            gridViewCommandColumn2.UseDefaultText = true;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn1,
            gridViewDateTimeColumn1,
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn6,
            gridViewDateTimeColumn2,
            gridViewDateTimeColumn3,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 574);
            this.radGridView1.TabIndex = 24;
            this.radGridView1.Text = "radGridView2";
            this.radGridView1.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridView1_CommandCellClick);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.statusCbx);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.exportBtn);
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
            this.radPanel1.TabIndex = 25;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "ControlDefault";
            // 
            // statusCbx
            // 
            this.statusCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Location = new System.Drawing.Point(698, 17);
            this.statusCbx.Margin = new System.Windows.Forms.Padding(4);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(160, 24);
            this.statusCbx.TabIndex = 49;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(634, 16);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "状态：";
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.exportBtn.Location = new System.Drawing.Point(872, 44);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 26);
            this.exportBtn.TabIndex = 27;
            this.exportBtn.Text = "导出";
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
            this.dimensionsDdl.Location = new System.Drawing.Point(97, 43);
            this.dimensionsDdl.Name = "dimensionsDdl";
            this.dimensionsDdl.Size = new System.Drawing.Size(137, 24);
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
            this.radLabel2.Location = new System.Drawing.Point(18, 15);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(90, 22);
            this.radLabel2.TabIndex = 44;
            this.radLabel2.Text = "订货日期：";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(872, 15);
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
            this.radTitleBar1.Location = new System.Drawing.Point(-26, 1);
            this.radTitleBar1.Name = "radTitleBar1";
            // 
            // 
            // 
            this.radTitleBar1.RootElement.ApplyShapeToControl = true;
            this.radTitleBar1.Size = new System.Drawing.Size(1047, 23);
            this.radTitleBar1.TabIndex = 23;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "订货明细";
            // 
            // 订货明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 654);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radTitleBar1);
            this.Name = "订货明细";
            this.Shape = this.roundRectShapeForm;
            this.Text = "订货明细";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
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

        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton exportBtn;
        private Telerik.WinControls.UI.RadDropDownList colorDdl;
        private Telerik.WinControls.UI.RadDropDownList dimensionsDdl;
        private Telerik.WinControls.UI.RadDropDownList product_nameDdl;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.ComboBox statusCbx;
    }
}
