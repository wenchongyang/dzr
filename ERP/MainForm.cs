using ERP;
using ERP.Data;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ERP
{
    public partial class MainForm : Telerik.WinControls.UI.ShapedForm
    {
        private const string THEME = "ControlDefault";
        Size oldSize = Size.Empty;

        private void enables(params RadElement[] args)
        {
            foreach (RadElement e in args)
            {
                e.Enabled = false;
            }
        }
        string name = "大自然管理系统v" + DataUtil.Version;
        public MainForm()
        {
            InitializeComponent();
            this.Text = name;

            this.label1.Text = UsersDal.CurUser.Name + ",欢迎您";

            if (null != UsersDal.CurUser)
                switch (UsersDal.CurUser.UserRole)
                {
                    case UsersDal.Role.财务:
                        enables(ddglMenu, sprkMenu, ddckMenu, rkmxMenu, xtglMenu, spglMenu);
                        break;
                    case UsersDal.Role.仓管:
                        enables(xtglMenu, spglMenu);
                        break;
                    case UsersDal.Role.店长:
                        enables(ddckMenu, xtglMenu, spglMenu, sprkMenu, ddckMenu, rkmxMenu, fcmxMenu, dhmxMenu);
                        break;
                    case UsersDal.Role.导购:
                        enables(ddckMenu, sprkMenu, xtglMenu, spglMenu, sprkMenu, ddckMenu, rkmxMenu, fcmxMenu, dhmxMenu);
                        break;
                    case UsersDal.Role.总经理:
                        lrhxMenu.Visibility = ElementVisibility.Visible;
                        enables(mdrkMenu, sprkMenu, spglMenu);
                        break;
                    case UsersDal.Role.超级管理员:
                        lrhxMenu.Visibility = ElementVisibility.Visible;
                        //enables(ddlrMenu);
                        break;
                }

            ThemeResolutionService.ApplyThemeToControlTree(this, THEME);
        }
        private void createForm(Type formClass)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            ShapedForm form = (ShapedForm)assembly.CreateInstance(formClass.FullName);
            form.Name = "InnerForm";

            form.TopLevel = false;
            form.Parent = this;
            form.ThemeName = THEME;
            form.Width = radPanel1.Width;
            form.Height = radPanel1.Height;
            form.Top = 0;
            form.Left = 0;
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(form);
            form.Show();
        }
        private void menuHorizontalOrientationItem_Click(object sender, EventArgs e)
        {
            this.radMenuDemo.MenuElement.MinSize = oldSize;
            this.radMenuDemo.Orientation = Orientation.Horizontal;
        }
        private void changeTitle(Object item)
        {
            if (item is RadMenuItem)
            {
                this.Text = name + "-- " + ((RadMenuItem)item).Text;
            }
        }
        private void menuVerticalOrientationItem_Click(object sender, EventArgs e)
        {
            oldSize = this.radMenuDemo.Size;
            this.radMenuDemo.MenuElement.MinSize = Size.Empty;
            this.radMenuDemo.Orientation = Orientation.Vertical;
        }

        private void itemHorizontalOrientationItem_Click(object sender, EventArgs e)
        {
            this.radMenuDemo.MenuElement.TextOrientation = Orientation.Horizontal;
            this.radMenuDemo.MenuElement.FlipText = false;
        }

        private void itemVerticalOrientationItem_Click(object sender, EventArgs e)
        {
            this.radMenuDemo.MenuElement.TextOrientation = Orientation.Vertical;
            this.radMenuDemo.MenuElement.FlipText = true;
        }

        private void radMenuItem4_1_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(商品管理));

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radMenuItem1_2_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(订单管理));

        }
        //订单录入

        private void radMenuItem1_1_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(订单录入));
        }

        private void radMenuItem1_3_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(销售明细));
        }

        private void radMenuItem1_4_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(销售报表));
        }

        private void radMenuItem2_1_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(商品入库));
        }

        private void radMenuItem2_2_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(库存报表));
        }

        private void radMenuItem3_1_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(用户管理));
        }

        private void radMenuItem3_2_Click(object sender, EventArgs e)
        {
            // createForm(typeof(角色管理));
        }

        private void radMenuItem3_3_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(门店管理));
        }

        private void radMenuItem3_4_Click(object sender, EventArgs e)
        {
            // createForm(typeof(日志管理));
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(订单出库列表));
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(商品入库报表));
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(修改密码));

        }

        private void lrhxMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(销售提成毛利));
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(SalesDal));
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void fcmxMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(返厂明细));
        }

        private void dhmxMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(订货明细));
        }

        private void kcglMenu_Click(object sender, EventArgs e)
        {
        }

        private void mdkcMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(门店库存报表));
        }

        private void mdrkMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(门店商品入库));
        }

        private void mdckmxMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(门店商品出库报表));
        }

        private void ckmxMenu_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(商品出库报表));
        }

        private void mdrkm_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            createForm(typeof(门店商品入库报表));
        }






    }
}