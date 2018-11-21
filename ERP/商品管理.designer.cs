namespace ERP
{
    partial class 商品管理
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.colorDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.addBtn = new Telerik.WinControls.UI.RadButton();
            this.product_nameDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.searchBtn = new Telerik.WinControls.UI.RadButton();
            this.dimensionsDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
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
            this.radGridView1.Location = new System.Drawing.Point(0, 67);
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
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "商品编号";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 68;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "商品名称";
            gridViewTextBoxColumn2.Name = "name";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "dimensions";
            gridViewTextBoxColumn3.HeaderText = "规格";
            gridViewTextBoxColumn3.Name = "dimensions";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "color";
            gridViewTextBoxColumn4.HeaderText = "颜色";
            gridViewTextBoxColumn4.Name = "color";
            gridViewTextBoxColumn4.Width = 60;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "cost_price";
            gridViewDecimalColumn1.FormatInfo = new System.Globalization.CultureInfo("zh-CN");
            gridViewDecimalColumn1.FormatString = "{0:C}";
            gridViewDecimalColumn1.HeaderText = "成本价";
            gridViewDecimalColumn1.Name = "cost_price";
            gridViewDecimalColumn1.Width = 120;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "guide_price";
            gridViewDecimalColumn2.FormatInfo = new System.Globalization.CultureInfo("zh-CN");
            gridViewDecimalColumn2.FormatString = "{0:C}";
            gridViewDecimalColumn2.HeaderText = "指导价";
            gridViewDecimalColumn2.Name = "guide_price";
            gridViewDecimalColumn2.Width = 120;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "price";
            gridViewDecimalColumn3.FormatInfo = new System.Globalization.CultureInfo("zh-CN");
            gridViewDecimalColumn3.FormatString = "{0:C}";
            gridViewDecimalColumn3.HeaderText = "价格";
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "price";
            gridViewDecimalColumn3.Width = 80;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "market_price";
            gridViewDecimalColumn4.FormatInfo = new System.Globalization.CultureInfo("zh-CN");
            gridViewDecimalColumn4.FormatString = "{0:C}";
            gridViewDecimalColumn4.HeaderText = "市场价";
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "market_price";
            gridViewDecimalColumn4.Width = 80;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "remarks";
            gridViewTextBoxColumn5.HeaderText = "备注";
            gridViewTextBoxColumn5.Name = "remarks";
            gridViewTextBoxColumn5.Width = 231;
            gridViewCommandColumn1.DefaultText = "修改";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "修改";
            gridViewCommandColumn1.Name = "edit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.DefaultText = "删除";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.HeaderText = "删除";
            gridViewCommandColumn2.Name = "delete";
            gridViewCommandColumn2.UseDefaultText = true;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(995, 581);
            this.radGridView1.TabIndex = 19;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.colorDdl);
            this.radPanel1.Controls.Add(this.addBtn);
            this.radPanel1.Controls.Add(this.product_nameDdl);
            this.radPanel1.Controls.Add(this.searchBtn);
            this.radPanel1.Controls.Add(this.dimensionsDdl);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(995, 648);
            this.radPanel1.TabIndex = 18;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "ControlDefault";
            // 
            // colorDdl
            // 
            this.colorDdl.AutoCompleteDisplayMember = "color";
            this.colorDdl.DisplayMember = "color";
            this.colorDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorDdl.Location = new System.Drawing.Point(574, 22);
            this.colorDdl.Name = "colorDdl";
            this.colorDdl.Size = new System.Drawing.Size(163, 24);
            this.colorDdl.TabIndex = 24;
            this.colorDdl.ThemeName = "ControlDefault";
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.addBtn.Location = new System.Drawing.Point(874, 20);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(98, 26);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "新增";
            // 
            // product_nameDdl
            // 
            this.product_nameDdl.AutoCompleteDisplayMember = "name";
            this.product_nameDdl.DisplayMember = "name";
            this.product_nameDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_nameDdl.Location = new System.Drawing.Point(119, 21);
            this.product_nameDdl.Name = "product_nameDdl";
            this.product_nameDdl.Size = new System.Drawing.Size(163, 24);
            this.product_nameDdl.TabIndex = 25;
            this.product_nameDdl.ThemeName = "ControlDefault";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.searchBtn.Location = new System.Drawing.Point(750, 20);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(98, 26);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "查询";
            // 
            // dimensionsDdl
            // 
            this.dimensionsDdl.AutoCompleteDisplayMember = "dimensions";
            this.dimensionsDdl.DisplayMember = "dimensions";
            this.dimensionsDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dimensionsDdl.Location = new System.Drawing.Point(339, 22);
            this.dimensionsDdl.Name = "dimensionsDdl";
            this.dimensionsDdl.Size = new System.Drawing.Size(163, 24);
            this.dimensionsDdl.TabIndex = 26;
            this.dimensionsDdl.ThemeName = "ControlDefault";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel1.Location = new System.Drawing.Point(36, 24);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(90, 22);
            this.radLabel1.TabIndex = 28;
            this.radLabel1.Text = "商品名称：";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel2.Location = new System.Drawing.Point(288, 24);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 27;
            this.radLabel2.Text = "规格：";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel6.Location = new System.Drawing.Point(508, 24);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 22);
            this.radLabel6.TabIndex = 29;
            this.radLabel6.Text = "颜色：";
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
            this.radTitleBar1.RootElement.Shape = this.roundRectShapeTitle;
            this.radTitleBar1.Size = new System.Drawing.Size(1006, 23);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "商品管理";
            // 
            // roundRectShapeTitle
            // 
            this.roundRectShapeTitle.BottomLeftRounded = false;
            this.roundRectShapeTitle.BottomRightRounded = false;
            // 
            // 商品管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 648);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radTitleBar1);
            this.Name = "商品管理";
            this.Text = "商品管理";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton addBtn;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadDropDownList colorDdl;
        private Telerik.WinControls.UI.RadDropDownList product_nameDdl;
        private Telerik.WinControls.UI.RadDropDownList dimensionsDdl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel6;
    }
}
