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
    public partial class Frm_SortInfo : Form
    {

        public string _ModelName = "SortInfo";
        public int entityId = int.MaxValue;
        public static List<string> _Tags;
         Frm_SortInfo()
        {
            InitializeComponent();
        }

        private static Frm_SortInfo _form;
        public static Frm_SortInfo Create(List<string> tags = null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_SortInfo();
                _Tags = tags;
            }
            else
            {
                Frm_SortInfo._Tags = tags;
            }
            return _form;
        }
        private void Frm_SortInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }

        public void InIt()
        {
            this.Tag = false;
            entityId = int.MaxValue;
            txtFirst.Text = "";
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
                    this.Text = "修改";
                    entityId = Convert.ToInt32(_Tags[0]);
                    txtFirst.Text = _Tags[1];
                    txtRmark.Text = _Tags[2];
                }
                else
                {
                    MessageBox.Show("发生意外情况,请稍后重试!");
                }
                txtFirst.Focus();//光标定位
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f

            if (txtFirst.Text == "")
            {
                lbltips.Text = "请检查数据,数据不能为空";
                lbltips.ForeColor = Color.Red;
                return;
            }
            //添加时候 默认 id 为maxValue
            if (entityId == int.MaxValue)
            {
                //添加
                SortInfo sortInfo = new SortInfo();
                sortInfo.SortName = txtFirst.Text;
                sortInfo.Remark = txtRmark.Text;
                var isSuccess = DataManager.SortInfoBLL.Add(sortInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("操作失败!");
                }
                this.Tag = true;

                this.Close();


            }
            else
            {
                SortInfo sortInfo = new SortInfo();
                sortInfo.SortName = txtFirst.Text;
                sortInfo.Remark = txtRmark.Text;
                sortInfo.Id = entityId;
                var isSuccess = DataManager.SortInfoBLL.Edit(sortInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("操作失败!");
                }
                this.Tag = true;
                this.Close();


            }
            //属性界面
            f1.GetDgv(f1.SelectIndex);
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
