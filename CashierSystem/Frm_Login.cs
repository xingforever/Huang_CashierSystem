using Common;
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

            }
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            var isHaveAccess = SoftHelper.CheckAccess();
            if (!isHaveAccess)
            {
                MessageBox.Show("本软件需要配合Office Access数据库使用,请下载安装Office Access", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
