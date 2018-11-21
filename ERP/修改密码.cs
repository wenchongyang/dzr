using ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class 修改密码 : Telerik.WinControls.UI.ShapedForm
    {
        public 修改密码()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBox1.Text != radTextBox2.Text)
            {
                MessageBox.Show("确认密码不一致！");
                return;
            }
            else {

                if (!UsersDal.ChangePwd(nameTbx.Text, radTextBox2.Text)) {
                    MessageBox.Show("旧密码错误");
                    return;
                }
                MessageBox.Show("修改密码成功！");
                radTextBox1.Text = radTextBox2.Text = nameTbx.Text = "";
            }
        }
    }
}
