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
    public partial class Frm_OrderInfoDIalog : Form
    {
         Frm_OrderInfoDIalog()
        {
            InitializeComponent();
        }

        private static Frm_OrderInfoDIalog _form;
        public static Frm_OrderInfoDIalog Create(List<string> tags = null)
        {
            
            if (_form == null)
            {
                _form = new Frm_OrderInfoDIalog();
            
            }
           
            return _form;
        }
        private void btnOrderOK_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例
            //获取订单表
            var OrdersInfo = f1.OrdersInfo;
            for (int i = 0; i < OrdersInfo.Count; i++)
            {
                var order = OrdersInfo[i];
                SalesInfo salesInfo = new SalesInfo();
                salesInfo.GoodsId = order.GoodsId;
                salesInfo.Count = order.Count;
                salesInfo.Prices = order.PayPice;
                salesInfo.DisCount = order.DisCount;
                salesInfo.Remark = order.Remark;



            }
        }
    }
}
