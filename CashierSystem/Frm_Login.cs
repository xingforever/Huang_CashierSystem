using Common;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            DataManager dataManager = new DataManager();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtName.Text.Trim();
            var userpwd = txtPwd.Text.Trim();
            var isTure= DataManager.UserInfoBLL.IsTrueNameAndPwd(userName, userpwd,out int id);
            if (isTure)
            {
                Huang_System huang_System = new Huang_System(id);
                huang_System.Show();
                huang_System.Focus();
                this.Hide();//隐藏当前
            }
            else
            {
                lblTips.Visible = true;
            }
            
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            var isHaveAccess = SoftHelper.CheckAccess();
            if (!isHaveAccess)
            {
             var  result=   MessageBox.Show("本软件需要配合Office Access数据库使用,请下载安装Office Access,或者下载Office2010正式版以后版本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result==DialogResult.OK)
                {
                    this.Close();
                }
            }
            var isHaveExcel = SoftHelper.CheckExcel();
            if (!isHaveExcel)
            {
                var result = MessageBox.Show("本软件需要配合Office Excel;,请下载安装Office Excel,或者下载Office2010正式版以后版本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            try
            {
                Setting TheSetting = Setting.GetSeeting();//获取默认设置
                txtTitle.Text = Setting.ProgramName;
               
            }
            catch 
            {
                ;
                
            }
           

        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            Frm_About frm_About = new Frm_About();
            frm_About.ShowDialog();
            frm_About.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //当前应用程序退出,不仅仅关闭当前窗体
            Application.Exit();
        }
    }
}
