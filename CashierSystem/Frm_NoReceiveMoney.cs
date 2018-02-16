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
    public partial class Frm_NoReceiveMoney : Form
    {

        public string _ModelName = "SortInfo";
        public int entityId = int.MaxValue;
        public static List<string> _Tags;
        public Frm_NoReceiveMoney()
        {
            InitializeComponent();
        }
        private static Frm_NoReceiveMoney _form;
        public static Frm_NoReceiveMoney Create(List<string> tags = null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_NoReceiveMoney();
                _Tags = tags;
            }
            else
            {
                Frm_NoReceiveMoney._Tags = tags;
            }
            return _form;
        }
        private void btnNoMEnter_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            }
            Huang_System f1 = (Huang_System)this.Owner;
            //修改数据
            if (entityId != int.MaxValue)
            {
                NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(entityId);
                if (noReceiveMoney!=null)
                {
                    noReceiveMoney.CustomerName = this.txtNoM_CustomerName.Text;
                    noReceiveMoney.Phone = this.txtNoM_Phone.Text;
                    noReceiveMoney.Remark = this.txtNoM_Remark.Text;
                    noReceiveMoney.ProfitsInfo = DataManager.ProfitsInfoBLL.GetProfitsInfoByOrderId(entityId);

                }


            }
            
        }

        private void Frm_NoReceiveMoney_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {

            if (_Tags.Count==6)
            {
                entityId = Convert.ToInt32(_Tags[0]);
                txtNoM_OrderId.Text = _Tags[1];
                txtNoM_CustomerName.Text = _Tags[2];
                txtNoM_Phone.Text = _Tags[3];
                txtNoM_Money.Text = _Tags[4];
                txtNoM_Remark.Text = _Tags[5];
            }
            else
            {
                MessageBox.Show("发生意外情况,请联系开发人员");

            }

        }

        public  bool CheckData()
        {
            this.lblNoM_Tips.Visible = false;
            if (txtNoM_CustomerName.Text==""||txtNoM_Phone.Text=="")
            {
                this.lblNoM_Tips.Text = "客户姓名或电话不能为空";
                this.lblNoM_Tips.Visible = true;
                return false;
            }
            return true;

        }

        private void txtNoM_Money_MouseUp(object sender, MouseEventArgs e)
        {
            this.lblNoM_Tips.Visible = false;
            var editMoney = txtNoM_Money.Text;
            decimal money;
           var isTrue= decimal.TryParse(editMoney, out money);
            if (!isTrue)
            {
                this.lblNoM_Tips.Text = "请输入数字";
                this.lblNoM_Tips.Visible = true;
            }
        }
    }
}
