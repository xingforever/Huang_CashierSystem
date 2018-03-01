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
    public partial class Frm_WholeSalerInfo : Form
    {
         Frm_WholeSalerInfo()
        {
            InitializeComponent();
        }

        public string _ModelName = "WholeSalerInfo";
        public int entityId = int.MaxValue;
        public static List<string> _Tags;
        private static Frm_WholeSalerInfo _form;
        public static Frm_WholeSalerInfo Create(List<string> tags = null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_WholeSalerInfo();
                _Tags = tags;
            }
            else
            {
                Frm_WholeSalerInfo._Tags = tags;
            }
            return _form;
        }


        private void Frm_WholeSalerInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }


        public void InIt()
        {

            entityId = int.MaxValue;
            if (_Tags != null)
            {
                //添加数据
                if (_Tags.Count == 0)
                {

                    this.Text = "添加";
                }
                //修改 0 为id
                else if (_Tags.Count == 6)
                {
                    this.Text = "修改";
                    entityId = Convert.ToInt32(_Tags[0]);
                    txtSupName.Text = _Tags[1];
                    txtManagement.Text = _Tags[2];
                    txtPhone.Text = _Tags[3];
                    txtAddress.Text = _Tags[4];
                    txtRemark.Text = _Tags[5];
                }
                else
                {
                    MessageBox.Show("发生意外情况,请稍后重试!");
                }
                txtSupName.Focus();//光标定位
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f

            if (!CheckInput())
            {
                lbltips.Text = "请检查数据,(*)数据不能为空";
                lbltips.ForeColor = Color.Red;
                return;
            }
            //添加时候 默认 id 为maxValue
            if (entityId == int.MaxValue)
            {
                
                
                WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
                wholeSalerInfo.SupName = txtSupName.Text.Trim();
                wholeSalerInfo.Management = txtManagement.Text.Trim();
                wholeSalerInfo.TelePhone = txtPhone.Text.Trim();
                wholeSalerInfo.AddressInfo = txtAddress.Text.Trim();
                wholeSalerInfo.Remark = txtRemark.Text.Trim();
                var isSuccess = DataManager.WholeSalerInfoBLL.Add(wholeSalerInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("操作失败!");
                }
                this.Close();
                
            }
            else
            {

                WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
                wholeSalerInfo.SupName = txtSupName.Text.Trim();
                wholeSalerInfo.Management = txtManagement.Text.Trim();
                wholeSalerInfo.TelePhone = txtPhone.Text.Trim();
                wholeSalerInfo.AddressInfo = txtAddress.Text.Trim();
                wholeSalerInfo.Remark = txtRemark.Text.Trim();
                wholeSalerInfo.Id = entityId;
                var isSuccess = DataManager.WholeSalerInfoBLL.Edit(wholeSalerInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("操作失败!");
                }
                this.Close();


            }
            //属性界面
            f1.GetDgv(f1.SelectIndex);
        }


        public  bool CheckInput()
        {
            if (txtSupName.Text==""||
                txtManagement.Text==""||
                txtPhone.Text==""||
                txtAddress.Text=="" )
            {
                return false;
            }
            return true;
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
