using Common;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_UserInfo : Form
    {
         Frm_UserInfo()
        {
            InitializeComponent();
        }
        public string _ModelName = "UserInfo";
        public int entityId = int.MaxValue;
        public static List<string> _Tags;
        //表名, lab1 ,lab2 ,lab3
        private static Frm_UserInfo _form;
        public static Frm_UserInfo Create(List<string> tags = null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_UserInfo();
                _Tags = tags;
            }
            else
            {
                Frm_UserInfo._Tags = tags;
            }
            return _form;
        }


        public void InIt()
        {
            entityId = int.MaxValue;
            txtUserName.Text = "";
            txtPwd.Text = "";
            txtRmark.Text = "";

            if (_Tags != null)
            {
                //添加数据
                if (_Tags.Count == 0)
                {

                    this.Text = "添加";
                }
                //修改 3 为id
                else if (_Tags.Count == 3)
                {
                    this.Text = "修改,非超级管理员仅能修改登录用户信息";
                    entityId = Convert.ToInt32(_Tags[0]);
                    txtUserName.Text = _Tags[1];
                    txtPwd.Text = "123456789";
                    txtRmark.Text = _Tags[2];
                }
                else
                {
                    MessageBox.Show("发生意外情况,请稍后重试!");
                }
                txtUserName.Focus();//光标定位
            }

        }

        private void Frm_UserInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }

        public bool CheckInput()
        {
            if (txtUserName.Text.Trim() == "" || txtPwd.Text.Trim() == "")
            {
                lbltips.Visible = true;
                lbltips.Text = "请检查数据,(*)数据不能为空";
                lbltips.ForeColor = Color.Red;
                return false;
            }
            else if (txtPwd.Text.Trim().Length < 6 || txtPwd.Text.Trim().Length > 20)
            {
                lbltips.Visible = true;
                lbltips.Text = "请检查数据,密码为6-20位";
                lbltips.ForeColor = Color.Red;
                return false;
            }
            else
            {
                ;
            }
            return true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f

            if (!CheckInput())
            {

                return;
            }
            //添加时候 默认 id 为maxValue
            if (entityId == int.MaxValue)
            {
                //添加              
                var name = txtUserName.Text.Trim();
                if (!IsContainsSpital(name))
                {
                    lbltips.Visible = true;
                    lbltips.ForeColor = Color.Red;
                    lbltips.Text = "用户名不能使用特殊字符";
                    return;
                }
               var isExist = DataManager.UserInfoBLL.IsExistName(name);
                if (!isExist)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.UserName = txtUserName.Text.Trim();
                    userInfo.PassWord = Md5Helper.EncryptString(txtPwd.Text.Trim());
                    userInfo.Remark = txtRmark.Text.Trim();
                    var isSuccess = DataManager.UserInfoBLL.Add(userInfo);
                    if (!isSuccess)
                    {
                        MessageBox.Show("操作失败!");
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    lbltips.Visible = true;
                    lbltips.ForeColor = Color.Red;
                    lbltips.Text = "存在相同用户名,请更换用户名";
                }
            }
            else
            {
                UserInfo userInfo = new UserInfo();
                var name = txtUserName.Text.Trim();
                //检查名称是否含有特殊字符
                if (!IsContainsSpital(name))
                {
                    lbltips.Visible = true;
                    lbltips.ForeColor = Color.Red;
                    lbltips.Text = "用户名不能使用特殊字符,修改失败";
                    return;
                }
                //检查修改后名称是否符合要求
                var isExist = DataManager.UserInfoBLL.IsExistName(name);
                if (isExist)
                {
                    lbltips.Visible = true;
                    lbltips.ForeColor = Color.Red;
                    lbltips.Text = "存在相同用户名,请更换用户名";
                    return;
                }
                userInfo.UserName = name;
                if (txtPwd.Text.Trim() != "123456789")
                {
                    userInfo.PassWord = Md5Helper.EncryptString(txtPwd.Text.Trim());
                }
                userInfo.Remark = txtRmark.Text.Trim();
                userInfo.Id = entityId;
                var isSuccess = DataManager.UserInfoBLL.Edit(userInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("操作失败!");
                    return;
                }
                this.Close();
            }
            //属性界面
            f1.GetDgv(f1.SelectIndex);

        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 是否包含特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsContainsSpital(string str)
        {

            char[] charKey = { '|', '#', '$', '^', '*', '(', ')', '+', '{', '}', '?', '[', ']', '.', '\\' ,' '};
            foreach (var item in charKey)
            {
                if (str.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
