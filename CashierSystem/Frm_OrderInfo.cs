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
    public partial class Frm_OrderInfo : Form
    {
        Frm_OrderInfo()
        {
            InitializeComponent();
        }

        public int entityId = int.MaxValue;
        public  static  OrderInfo  theOrderInfo;
        public OrderInfo _orderInfo;
        private double OldCount;
        private decimal OldDisCount;
        private decimal OldPrice;
        private string OldRemark;
        private decimal OldProfit;
     

        private static Frm_OrderInfo _form;
        public static Frm_OrderInfo Create(  OrderInfo orderInfo)
        {
            theOrderInfo = null;
            if (_form == null)
            {
                _form = new Frm_OrderInfo();
                theOrderInfo = orderInfo;
                
            }
            else
            {
                theOrderInfo = orderInfo;
               
            }
            return _form;
        }
        
         public void  InIt()
        {
            _orderInfo = theOrderInfo;
            try
            {
                txtOrder_GoodsName.Text = _orderInfo.GoodsName;
                txtOrder_Count.Text = _orderInfo.Count.ToString();
                txtOrder_DisCount.Text = _orderInfo.DisCount.ToString();

                double  dfd = (double)_orderInfo.PayPrice;
                txtOrder_Price.Text= _orderInfo.PayPrice.ToString();
                txtOrder_Remark.Text = _orderInfo.Remark;
                Copy();
            }
            catch 
            {

                ;
            }
        }
        private void btnOrderEnter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public   void Copy()
        {
            OldCount = _orderInfo.Count;
            OldDisCount = _orderInfo.DisCount;
            OldPrice = _orderInfo.PayPrice;
            OldProfit = _orderInfo.Profit;
            OldRemark = _orderInfo.Remark;

        }
        private void Frm_OrderInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }

        private void txtOrder_Count_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var editCount = Convert.ToDouble(this.txtOrder_Count.Text);
                var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(_orderInfo.GoodsId);
                var surplusCount = goodsInfo.SurplusCount;
                if (editCount>=surplusCount)
                {
                    MessageBox.Show("库存不够!!,剩余数量为"+surplusCount, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var disCount = Convert.ToDecimal(this.txtOrder_DisCount.Text);
                _orderInfo.Count = editCount;
                _orderInfo.DisCount = disCount;                
                _orderInfo.PayPrice = (goodsInfo.PurPrice * (decimal)editCount) - disCount;
                _orderInfo.Profit = _orderInfo.PayPrice - (goodsInfo.PurPrice * (decimal)editCount);
                this.txtOrder_Price.Text = _orderInfo.PayPrice.ToString();
            }
            catch 
            {
                MessageBox.Show("修改失败,请检查数据是否合格", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

        private void txtOrder_DisCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(_orderInfo.GoodsId);
                var editCount = Convert.ToDouble(this.txtOrder_Count.Text);
                var disCount = Convert.ToDecimal(this.txtOrder_DisCount.Text);              
                _orderInfo.DisCount = disCount;
                _orderInfo.PayPrice = (goodsInfo.PurPrice * (decimal)editCount) - disCount;
                _orderInfo.Profit = _orderInfo.PayPrice - (goodsInfo.PurPrice * (decimal)editCount);
                this.txtOrder_Price.Text = _orderInfo.PayPrice.ToString();
            }
            catch
            {
                MessageBox.Show("修改失败,请检查数据是否合格", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            _orderInfo.Count = OldCount;
            _orderInfo.DisCount = OldDisCount;
            _orderInfo.PayPrice = OldPrice;
            _orderInfo.Profit = OldProfit;
            _orderInfo.Remark = OldRemark;
            InIt();
        }

        private void txtOrder_Remark_TextChanged(object sender, EventArgs e)
        {
            _orderInfo.Remark = this.txtOrder_Remark.Text;
        }
    }
}
