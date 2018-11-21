namespace ERP
{
    partial class 门店管理
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.addBtn = new Telerik.WinControls.UI.RadButton();
            this.searchBtn = new Telerik.WinControls.UI.RadButton();
            this.leadTbx = new Telerik.WinControls.UI.RadTextBox();
            this.addressTbx = new Telerik.WinControls.UI.RadTextBox();
            this.storeTbx = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(357, 66);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(98, 24);
            this.radButton1.TabIndex = 7;
            this.radButton1.Text = "查询";
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
            this.radGridView1.Location = new System.Drawing.Point(0, 65);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.Caption = "Products";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "id";
            gridViewTextBoxColumn1.HeaderText = "门店编号";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 68;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "店名";
            gridViewTextBoxColumn2.Name = "name";
            gridViewTextBoxColumn2.Width = 130;
            gridViewComboBoxColumn1.DisplayMember = "name";
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "lead";
            gridViewComboBoxColumn1.HeaderText = "店长";
            gridViewComboBoxColumn1.Name = "lead";
            gridViewComboBoxColumn1.ValueMember = "id";
            gridViewComboBoxColumn1.Width = 102;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "phone";
            gridViewTextBoxColumn3.HeaderText = "联系方式";
            gridViewTextBoxColumn3.Name = "phone";
            gridViewTextBoxColumn3.Width = 159;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "address";
            gridViewTextBoxColumn4.HeaderText = "地址";
            gridViewTextBoxColumn4.Name = "address";
            gridViewTextBoxColumn4.Width = 245;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "remarks";
            gridViewTextBoxColumn5.FormatInfo = new System.Globalization.CultureInfo("en-US");
            gridViewTextBoxColumn5.FormatString = "{0:C}";
            gridViewTextBoxColumn5.HeaderText = "备注";
            gridViewTextBoxColumn5.Name = "remarks";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 161;
            gridViewCommandColumn1.DefaultText = "修改";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "id";
            gridViewCommandColumn1.HeaderText = "修改";
            gridViewCommandColumn1.Name = "edit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.DefaultText = "删除";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "id";
            gridViewCommandColumn2.HeaderText = "删除";
            gridViewCommandColumn2.Name = "delete";
            gridViewCommandColumn2.UseDefaultText = true;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(995, 589);
            this.radGridView1.TabIndex = 18;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "ControlDefault";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.addBtn);
            this.radPanel1.Controls.Add(this.searchBtn);
            this.radPanel1.Controls.Add(this.leadTbx);
            this.radPanel1.Controls.Add(this.addressTbx);
            this.radPanel1.Controls.Add(this.storeTbx);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(995, 654);
            this.radPanel1.TabIndex = 19;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "ControlDefault";
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.addBtn.Location = new System.Drawing.Point(877, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(98, 26);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "新增";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F);
            this.searchBtn.Location = new System.Drawing.Point(773, 19);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(98, 26);
            this.searchBtn.TabIndex = 4;
            this.searchBtn.Text = "查询";
            // 
            // leadTbx
            // 
            this.leadTbx.Font = new System.Drawing.Font("FangSong", 12F);
            this.leadTbx.Location = new System.Drawing.Point(599, 18);
            this.leadTbx.Name = "leadTbx";
            this.leadTbx.Size = new System.Drawing.Size(150, 24);
            this.leadTbx.TabIndex = 3;
            this.leadTbx.TabStop = false;
            // 
            // addressTbx
            // 
            this.addressTbx.Font = new System.Drawing.Font("FangSong", 12F);
            this.addressTbx.Location = new System.Drawing.Point(346, 18);
            this.addressTbx.Name = "addressTbx";
            this.addressTbx.Size = new System.Drawing.Size(150, 24);
            this.addressTbx.TabIndex = 2;
            this.addressTbx.TabStop = false;
            // 
            // storeTbx
            // 
            this.storeTbx.Font = new System.Drawing.Font("FangSong", 12F);
            this.storeTbx.Location = new System.Drawing.Point(106, 19);
            this.storeTbx.Name = "storeTbx";
            this.storeTbx.Size = new System.Drawing.Size(150, 24);
            this.storeTbx.TabIndex = 1;
            this.storeTbx.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel2.Location = new System.Drawing.Point(515, 19);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 22);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "店长：";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel6.Location = new System.Drawing.Point(262, 19);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 22);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "地址：";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F);
            this.radLabel1.Location = new System.Drawing.Point(22, 20);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 22);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "店名：";
            // 
            // 门店管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(995, 654);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radPanel1);
            this.Name = "门店管理";
            this.Text = "门店管理";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.门店管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);

        }
 

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton addBtn;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadTextBox storeTbx;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox addressTbx;
        private Telerik.WinControls.UI.RadTextBox leadTbx;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
