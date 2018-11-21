namespace ERP
{
    partial class 库存报表
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn6 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn7 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn8 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn9 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn10 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.colorDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.product_nameDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.dimensionsDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.searchBtn = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDdl
            // 
            this.colorDdl.AutoCompleteDisplayMember = "color";
            this.colorDdl.DisplayMember = "color";
            this.colorDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorDdl.Location = new System.Drawing.Point(564, 15);
            this.colorDdl.Name = "colorDdl";
            this.colorDdl.Size = new System.Drawing.Size(163, 24);
            this.colorDdl.TabIndex = 10;
            this.colorDdl.ThemeName = "ControlDefault";
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
            this.radGridView1.Location = new System.Drawing.Point(0, 60);
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
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "ID";
            gridViewTextBoxColumn6.HeaderText = "商品编号";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "ID";
            gridViewTextBoxColumn6.Width = 119;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "product_name";
            gridViewTextBoxColumn7.HeaderText = "商品名称";
            gridViewTextBoxColumn7.Name = "product_name";
            gridViewTextBoxColumn7.Width = 120;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "dimensions";
            gridViewTextBoxColumn8.HeaderText = "规格";
            gridViewTextBoxColumn8.Name = "dimensions";
            gridViewTextBoxColumn8.Width = 158;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "color";
            gridViewTextBoxColumn9.HeaderText = "颜色";
            gridViewTextBoxColumn9.Name = "color";
            gridViewTextBoxColumn9.Width = 71;
            gridViewDecimalColumn4.DecimalPlaces = 0;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "count";
            gridViewDecimalColumn4.HeaderText = "库存数量";
            gridViewDecimalColumn4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn4.Name = "count";
            gridViewDecimalColumn4.Width = 120;
            gridViewDecimalColumn5.DecimalPlaces = 0;
            gridViewDecimalColumn5.EnableExpressionEditor = false;
            gridViewDecimalColumn5.FieldName = "saleable_count";
            gridViewDecimalColumn5.HeaderText = "可销数量";
            gridViewDecimalColumn5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn5.Name = "saleable_count";
            gridViewDecimalColumn5.Width = 120;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "product_id";
            gridViewTextBoxColumn10.HeaderText = "column1";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "product_id";
            gridViewDecimalColumn6.EnableExpressionEditor = false;
            gridViewDecimalColumn6.FieldName = "order_count";
            gridViewDecimalColumn6.HeaderText = "订货数量";
            gridViewDecimalColumn6.Name = "order_count";
            gridViewDecimalColumn6.Width = 83;
            gridViewCommandColumn6.DefaultText = "返厂";
            gridViewCommandColumn6.EnableExpressionEditor = false;
            gridViewCommandColumn6.FieldName = "product_id";
            gridViewCommandColumn6.HeaderText = "返厂";
            gridViewCommandColumn6.Name = "out";
            gridViewCommandColumn6.UseDefaultText = true;
            gridViewCommandColumn6.Width = 40;
            gridViewCommandColumn7.DefaultText = "订货";
            gridViewCommandColumn7.EnableExpressionEditor = false;
            gridViewCommandColumn7.FieldName = "product_id";
            gridViewCommandColumn7.HeaderText = "订货";
            gridViewCommandColumn7.Name = "in";
            gridViewCommandColumn7.UseDefaultText = true;
            gridViewCommandColumn7.Width = 39;
            gridViewCommandColumn8.DefaultText = "待送详情";
            gridViewCommandColumn8.EnableExpressionEditor = false;
            gridViewCommandColumn8.FieldName = "product_id";
            gridViewCommandColumn8.HeaderText = "待送详情";
            gridViewCommandColumn8.Name = "dsxq";
            gridViewCommandColumn8.UseDefaultText = true;
            gridViewCommandColumn8.Width = 69;
            gridViewCommandColumn9.DefaultText = "出库详情";
            gridViewCommandColumn9.EnableExpressionEditor = false;
            gridViewCommandColumn9.FieldName = "product_id";
            gridViewCommandColumn9.HeaderText = "出库详情";
            gridViewCommandColumn9.Name = "ckxq";
            gridViewCommandColumn9.UseDefaultText = true;
            gridViewCommandColumn9.Width = 71;
            gridViewCommandColumn10.DefaultText = "入库详情";
            gridViewCommandColumn10.EnableExpressionEditor = false;
            gridViewCommandColumn10.FieldName = "product_id";
            gridViewCommandColumn10.HeaderText = "入库详情";
            gridViewCommandColumn10.Name = "rkxq";
            gridViewCommandColumn10.UseDefaultText = true;
            gridViewCommandColumn10.Width = 80;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn10,
            gridViewDecimalColumn6,
            gridViewCommandColumn6,
            gridViewCommandColumn7,
            gridViewCommandColumn8,
            gridViewCommandColumn9,
            gridViewCommandColumn10});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 588);
            this.radGridView1.TabIndex = 27;
            this.radGridView1.Text = "radGridView2";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridView1_CommandCellClick);
            // 
            // product_nameDdl
            // 
            this.product_nameDdl.AutoCompleteDisplayMember = "name";
            this.product_nameDdl.DisplayMember = "name";
            this.product_nameDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_nameDdl.Location = new System.Drawing.Point(95, 16);
            this.product_nameDdl.Name = "product_nameDdl";
            this.product_nameDdl.Size = new System.Drawing.Size(163, 24);
            this.product_nameDdl.TabIndex = 11;
            this.product_nameDdl.ThemeName = "ControlDefault";
            // 
            // dimensionsDdl
            // 
            this.dimensionsDdl.AutoCompleteDisplayMember = "dimensions";
            this.dimensionsDdl.DisplayMember = "dimensions";
            this.dimensionsDdl.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dimensionsDdl.Location = new System.Drawing.Point(315, 15);
            this.dimensionsDdl.Name = "dimensionsDdl";
            this.dimensionsDdl.Size = new System.Drawing.Size(163, 24);
            this.dimensionsDdl.TabIndex = 12;
            this.dimensionsDdl.ThemeName = "ControlDefault";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.searchBtn.Location = new System.Drawing.Point(747, 13);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(98, 26);
            this.searchBtn.TabIndex = 26;
            this.searchBtn.Text = "查询";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel2.Location = new System.Drawing.Point(264, 17);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "规格：";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel1.Location = new System.Drawing.Point(12, 20);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(90, 22);
            this.radLabel1.TabIndex = 23;
            this.radLabel1.Text = "商品名称：";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel6.Location = new System.Drawing.Point(498, 17);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 22);
            this.radLabel6.TabIndex = 23;
            this.radLabel6.Text = "颜色：";
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.exportBtn.Location = new System.Drawing.Point(851, 13);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 26);
            this.exportBtn.TabIndex = 26;
            this.exportBtn.Text = "导出";
            // 
            // 库存报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 648);
            this.Controls.Add(this.colorDdl);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.product_nameDdl);
            this.Controls.Add(this.dimensionsDdl);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel6);
            this.Name = "库存报表";
            this.Text = "库存报表";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.colorDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_nameDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionsDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList colorDdl;
        private Telerik.WinControls.UI.RadDropDownList product_nameDdl;
        private Telerik.WinControls.UI.RadDropDownList dimensionsDdl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton exportBtn;
    }
}
