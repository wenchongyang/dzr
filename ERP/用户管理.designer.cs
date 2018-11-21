using System;
using System.Windows.Forms;
namespace ERP
{
    partial class 用户管理
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn3 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.storeCbx = new System.Windows.Forms.ComboBox();
            this.addBtn = new Telerik.WinControls.UI.RadButton();
            this.searchBtn = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.nameTbx = new Telerik.WinControls.UI.RadTextBox();
            this.userNameTbx = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.storeCbx);
            this.radPanel1.Controls.Add(this.addBtn);
            this.radPanel1.Controls.Add(this.searchBtn);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.nameTbx);
            this.radPanel1.Controls.Add(this.userNameTbx);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1036, 70);
            this.radPanel1.TabIndex = 22;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // storeCbx
            // 
            this.storeCbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCbx.FormattingEnabled = true;
            this.storeCbx.Location = new System.Drawing.Point(592, 15);
            this.storeCbx.Margin = new System.Windows.Forms.Padding(4);
            this.storeCbx.Name = "storeCbx";
            this.storeCbx.Size = new System.Drawing.Size(162, 24);
            this.storeCbx.TabIndex = 48;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(880, 16);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(98, 26);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "新增";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(776, 16);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(98, 26);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "查询";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = true;
            this.radLabel3.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(517, 16);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 22);
            this.radLabel3.TabIndex = 47;
            this.radLabel3.Text = "门店：";
            // 
            // nameTbx
            // 
            this.nameTbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTbx.Location = new System.Drawing.Point(353, 15);
            this.nameTbx.Name = "nameTbx";
            this.nameTbx.Size = new System.Drawing.Size(162, 24);
            this.nameTbx.TabIndex = 2;
            this.nameTbx.TabStop = false;
            // 
            // userNameTbx
            // 
            this.userNameTbx.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTbx.Location = new System.Drawing.Point(114, 15);
            this.userNameTbx.Name = "userNameTbx";
            this.userNameTbx.Size = new System.Drawing.Size(162, 24);
            this.userNameTbx.TabIndex = 1;
            this.userNameTbx.TabStop = false;
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = true;
            this.radLabel6.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(278, 16);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 22);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "姓名：";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Font = new System.Drawing.Font("FangSong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(22, 16);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(74, 22);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "用户名：";
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
            this.radGridView1.Location = new System.Drawing.Point(0, 70);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.Caption = "用户管理";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "id";
            gridViewTextBoxColumn1.HeaderText = "用户编号";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.Width = 86;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "username";
            gridViewTextBoxColumn2.HeaderText = "用户名";
            gridViewTextBoxColumn2.Name = "username";
            gridViewTextBoxColumn2.Width = 74;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "name";
            gridViewTextBoxColumn3.HeaderText = "姓名";
            gridViewTextBoxColumn3.Name = "name";
            gridViewTextBoxColumn3.Width = 59;
            gridViewComboBoxColumn1.DisplayMember = "key";
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "sex";
            gridViewComboBoxColumn1.HeaderText = "性别";
            gridViewComboBoxColumn1.Name = "sex";
            gridViewComboBoxColumn1.ValueMember = "val";
            gridViewComboBoxColumn2.DisplayMember = "name";
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.FieldName = "role_id";
            gridViewComboBoxColumn2.HeaderText = "角色名称";
            gridViewComboBoxColumn2.Name = "role_id";
            gridViewComboBoxColumn2.ValueMember = "id";
            gridViewComboBoxColumn2.Width = 80;
            gridViewDateTimeColumn1.CustomFormat = "yyyy-MM-dd";
            gridViewDateTimeColumn1.DataSourceNullValue = new System.DateTime(2015, 3, 16, 21, 1, 39, 0);
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "join_date";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:yyyy-MM-dd}";
            gridViewDateTimeColumn1.HeaderText = "入职日期";
            gridViewDateTimeColumn1.Name = "join_date";
            gridViewDateTimeColumn1.Width = 100;
            gridViewComboBoxColumn3.DisplayMember = "name";
            gridViewComboBoxColumn3.EnableExpressionEditor = false;
            gridViewComboBoxColumn3.FieldName = "store_id";
            gridViewComboBoxColumn3.HeaderText = "所属门店";
            gridViewComboBoxColumn3.Name = "store_id";
            gridViewComboBoxColumn3.ValueMember = "id";
            gridViewComboBoxColumn3.Width = 97;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "phone";
            gridViewTextBoxColumn4.HeaderText = "联系方式";
            gridViewTextBoxColumn4.Name = "phone";
            gridViewTextBoxColumn4.Width = 69;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "address";
            gridViewTextBoxColumn5.HeaderText = "地址";
            gridViewTextBoxColumn5.Name = "address";
            gridViewTextBoxColumn5.Width = 86;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "id_card";
            gridViewTextBoxColumn6.HeaderText = "身份证号码";
            gridViewTextBoxColumn6.Name = "id_card";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 82;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "remarks";
            gridViewTextBoxColumn7.HeaderText = "备注";
            gridViewTextBoxColumn7.Name = "remarks";
            gridViewTextBoxColumn7.Width = 55;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "salary";
            gridViewDecimalColumn1.HeaderText = "薪资";
            gridViewDecimalColumn1.Name = "salary";
            gridViewDecimalColumn1.Step = new decimal(new int[] {
            100,
            0,
            0,
            0});
            gridViewDecimalColumn1.Width = 68;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "修改";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "id";
            gridViewCommandColumn1.HeaderText = "修改";
            gridViewCommandColumn1.Name = "edit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "删除";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "id";
            gridViewCommandColumn2.HeaderText = "删除";
            gridViewCommandColumn2.Name = "delete";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.AllowSort = false;
            gridViewCommandColumn3.DefaultText = "重置密码";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.FieldName = "id";
            gridViewCommandColumn3.HeaderText = "重置密码";
            gridViewCommandColumn3.Name = "resetPwd";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 80;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewComboBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn1,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(1036, 603);
            this.radGridView1.TabIndex = 21;
            this.radGridView1.Text = "radGridView2";
            this.radGridView1.ThemeName = "ControlDefault";
            this.radGridView1.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellEndEdit);
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridView1_CommandCellClick);
            // 
            // 用户管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(1036, 673);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radGridView1);
            this.Name = "用户管理";
            this.Text = "用户管理";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton addBtn;
        private Telerik.WinControls.UI.RadButton searchBtn;
        private Telerik.WinControls.UI.RadTextBox userNameTbx;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadTextBox nameTbx;
        private ComboBox storeCbx;
        private Telerik.WinControls.UI.RadLabel radLabel3;

       


    }
}
