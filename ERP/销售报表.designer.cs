namespace ERP
{
    partial class 销售报表
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.roundRectShape2 = new Telerik.WinControls.RoundRectShape(this.components);
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.storeCbx = new System.Windows.Forms.ComboBox();
            this.userCbx = new System.Windows.Forms.ComboBox();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
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
            this.radGridView1.Location = new System.Drawing.Point(0, 77);
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
            gridViewTextBoxColumn1.FieldName = "store_name";
            gridViewTextBoxColumn1.HeaderText = "门店";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "store_name";
            gridViewTextBoxColumn1.Width = 170;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "user_name";
            gridViewTextBoxColumn2.HeaderText = "导购员";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "user_name";
            gridViewTextBoxColumn2.Width = 139;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "product_name";
            gridViewTextBoxColumn3.HeaderText = "商品名称";
            gridViewTextBoxColumn3.Name = "product_name";
            gridViewTextBoxColumn3.Width = 128;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "dimensions";
            gridViewTextBoxColumn4.HeaderText = "规格";
            gridViewTextBoxColumn4.Name = "dimensions";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "color";
            gridViewTextBoxColumn5.HeaderText = "颜色";
            gridViewTextBoxColumn5.Name = "color";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "count";
            gridViewTextBoxColumn6.HeaderText = "数量（件）";
            gridViewTextBoxColumn6.Name = "count";
            gridViewTextBoxColumn6.Width = 86;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "actually_pay";
            gridViewTextBoxColumn7.HeaderText = "实付金额";
            gridViewTextBoxColumn7.Name = "actually_pay";
            gridViewTextBoxColumn7.Width = 86;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 577);
            this.radGridView1.TabIndex = 41;
            this.radGridView1.Text = "radGridView2";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("FangSong", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(235, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(139, 26);
            this.dateTimePicker2.TabIndex = 42;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("FangSong", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 26);
            this.dateTimePicker1.TabIndex = 43;
            // 
            // radButton3
            // 
            this.radButton3.Font = new System.Drawing.Font("FangSong", 12F);
            this.radButton3.Location = new System.Drawing.Point(661, 13);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(98, 26);
            this.radButton3.TabIndex = 40;
            this.radButton3.Text = "查询";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel6.Location = new System.Drawing.Point(386, 12);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(74, 22);
            this.radLabel6.TabIndex = 37;
            this.radLabel6.Text = "导购员：";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel1.Location = new System.Drawing.Point(22, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 22);
            this.radLabel1.TabIndex = 35;
            this.radLabel1.Text = "日期：";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel3.Location = new System.Drawing.Point(22, 44);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 36;
            this.radLabel3.Text = "门店：";
            // 
            // storeCbx
            // 
            this.storeCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCbx.FormattingEnabled = true;
            this.storeCbx.Location = new System.Drawing.Point(79, 44);
            this.storeCbx.Margin = new System.Windows.Forms.Padding(4);
            this.storeCbx.Name = "storeCbx";
            this.storeCbx.Size = new System.Drawing.Size(139, 24);
            this.storeCbx.TabIndex = 49;
            // 
            // userCbx
            // 
            this.userCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCbx.FormattingEnabled = true;
            this.userCbx.Location = new System.Drawing.Point(453, 13);
            this.userCbx.Margin = new System.Windows.Forms.Padding(4);
            this.userCbx.Name = "userCbx";
            this.userCbx.Size = new System.Drawing.Size(139, 24);
            this.userCbx.TabIndex = 50;
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.exportBtn.Location = new System.Drawing.Point(661, 46);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 26);
            this.exportBtn.TabIndex = 51;
            this.exportBtn.Text = "导出";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // 销售报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 654);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.userCbx);
            this.Controls.Add(this.storeCbx);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel1);
            this.Name = "销售报表";
            this.Shape = this.roundRectShapeForm;
            this.Text = "销售报表";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.销售报表_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.RoundRectShape roundRectShape2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.ComboBox storeCbx;
        private System.Windows.Forms.ComboBox userCbx;
        private Telerik.WinControls.UI.RadButton exportBtn;
    }
}
