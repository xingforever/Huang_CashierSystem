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
    public partial class Frm_Payment : Form
    {
        private Frm_Payment()
        {
            InitializeComponent();
        }

        public static Frm_Payment _form;
        public static ProfitsInfo _profitsInfo;

        public static Frm_Payment Create(ProfitsInfo profitsInfo)
        {
            if (_form == null)
            {
                _form = new Frm_Payment();              
            }
            _profitsInfo = profitsInfo;
            return _form;
        }

        private void Frm_Payment_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            //图片加载 
            //钱加载
            if (_profitsInfo!=null)
            {
                this.lblMoney.Text = _profitsInfo.PayPrices.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_profitsInfo!=null)
            {
                _profitsInfo.IsPay = true;
                var isSuccess = DataManager.ProfitsInfoBLL.Add(_profitsInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("利润表数据添加失败,如多次失败请联系管理员");                   
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("发生意外事件!!!,请关闭重试");
            }
        }

        private void btnUnPay_Click(object sender, EventArgs e)
        {
            if (_profitsInfo != null)
            {
                _profitsInfo.IsPay = false;
                var isSuccess = DataManager.ProfitsInfoBLL.Add(_profitsInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("利润表数据添加失败,如多次失败请联系管理员");
                    return;
                }
              Frm_NoReceiveMoney frm_NoReceiveMoney = Frm_NoReceiveMoney.Create(_profitsInfo.OrderId, _profitsInfo.PayPrices.ToString());
              frm_NoReceiveMoney.ShowDialog(this);
              frm_NoReceiveMoney.Focus();
                //如果登记成功 ,返回true ,可以
                var isSucess = Boolean.Parse(frm_NoReceiveMoney.Tag.ToString());
                if (isSuccess)
                {
                    this.Tag = "true";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("发生意外事件!!!,请关闭重试");
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            CommonHelper.StartCalc();
        }
    }
}
