using ERP.Data;
using Glass;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace ERP
{
    public class Login : Form
    {
        private GlassButton glassButton1;
        private GlassButton glassButton2;
        private TextBox usernameTbx;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadMaskedEditBox radMaskedEditBox4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMaskedEditBox radMaskedEditBox1;
        private TextBox pwdTbx;

        public Login()
        {
            this.InitializeComponent();
        }


        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (!UsersDal.CheckVersion()) {
                MessageBox.Show("系统已升级到v" + DataUtil.Version + "版本,请获取最新程序.");
            }
            if (!string.IsNullOrWhiteSpace(usernameTbx.Text) && !string.IsNullOrWhiteSpace(pwdTbx.Text)
                && UsersDal.Login(usernameTbx.Text, pwdTbx.Text))
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void InitializeComponent()
        {
            this.glassButton1 = new Glass.GlassButton();
            this.glassButton2 = new Glass.GlassButton();
            this.pwdTbx = new System.Windows.Forms.TextBox();
            this.usernameTbx = new System.Windows.Forms.TextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radMaskedEditBox4 = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radMaskedEditBox1 = new Telerik.WinControls.UI.RadMaskedEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.radLabel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.radLabel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // glassButton1
            // 
            this.glassButton1.BackColor = System.Drawing.Color.Chartreuse;
            this.glassButton1.FadeOnFocus = true;
            this.glassButton1.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.glassButton1.ForeColor = System.Drawing.Color.Black;
            this.glassButton1.GlowColor = System.Drawing.Color.Transparent;
            this.glassButton1.InnerBorderColor = System.Drawing.Color.Transparent;
            this.glassButton1.Location = new System.Drawing.Point(77, 171);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.ShineColor = System.Drawing.Color.Transparent;
            this.glassButton1.Size = new System.Drawing.Size(96, 53);
            this.glassButton1.TabIndex = 1;
            this.glassButton1.Text = "确定";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // glassButton2
            // 
            this.glassButton2.BackColor = System.Drawing.Color.Chartreuse;
            this.glassButton2.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.glassButton2.ForeColor = System.Drawing.Color.Black;
            this.glassButton2.GlowColor = System.Drawing.Color.Transparent;
            this.glassButton2.InnerBorderColor = System.Drawing.Color.Transparent;
            this.glassButton2.Location = new System.Drawing.Point(243, 171);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.ShineColor = System.Drawing.Color.Transparent;
            this.glassButton2.Size = new System.Drawing.Size(96, 53);
            this.glassButton2.TabIndex = 2;
            this.glassButton2.Text = "退出";
            this.glassButton2.Click += new System.EventHandler(this.glassButton2_Click);
            // 
            // pwdTbx
            // 
            this.pwdTbx.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwdTbx.Location = new System.Drawing.Point(148, 102);
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.Size = new System.Drawing.Size(192, 44);
            this.pwdTbx.TabIndex = 0;
            this.pwdTbx.UseSystemPasswordChar = true;
            this.pwdTbx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // usernameTbx
            // 
            this.usernameTbx.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameTbx.Location = new System.Drawing.Point(148, 41);
            this.usernameTbx.Name = "usernameTbx";
            this.usernameTbx.Size = new System.Drawing.Size(192, 44);
            this.usernameTbx.TabIndex = 0;
            this.usernameTbx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.Controls.Add(this.radMaskedEditBox4);
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(76, 42);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(68, 30);
            this.radLabel1.TabIndex = 56;
            this.radLabel1.Text = "姓名：";
            // 
            // radMaskedEditBox4
            // 
            this.radMaskedEditBox4.Location = new System.Drawing.Point(69, 3);
            this.radMaskedEditBox4.Name = "radMaskedEditBox4";
            this.radMaskedEditBox4.Size = new System.Drawing.Size(150, 20);
            this.radMaskedEditBox4.TabIndex = 61;
            this.radMaskedEditBox4.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.Controls.Add(this.radMaskedEditBox1);
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(77, 106);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(68, 30);
            this.radLabel2.TabIndex = 56;
            this.radLabel2.Text = "密码：";
            // 
            // radMaskedEditBox1
            // 
            this.radMaskedEditBox1.Location = new System.Drawing.Point(69, 3);
            this.radMaskedEditBox1.Name = "radMaskedEditBox1";
            this.radMaskedEditBox1.Size = new System.Drawing.Size(150, 20);
            this.radMaskedEditBox1.TabIndex = 61;
            this.radMaskedEditBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 266);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.usernameTbx);
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.glassButton2);
            this.Controls.Add(this.glassButton1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大自然进销存系统登陆";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radLabel1.ResumeLayout(false);
            this.radLabel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.radLabel2.ResumeLayout(false);
            this.radLabel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.glassButton1_Click(null, null);
            }
        }
    }
}
