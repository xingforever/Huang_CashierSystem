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
        public bool _isPay = false;
        public  static string _payPrice = null;
         Frm_OrderInfoDIalog()
        {
            InitializeComponent();
        }

        private static Frm_OrderInfoDIalog _form;
        public static Frm_OrderInfoDIalog Create(string _tags = null)
        {
            _payPrice = _tags;
            if (_form == null)
            {
                _form = new Frm_OrderInfoDIalog();
               
            
            }
           
            return _form;
        }
        private void btnOrderOK_Click(object sender, EventArgs e)
        {
            ///操作步骤: 1获取订单表数据 ,将订单表数据添加数据库
            ///2计算 利润 ,将得出利润数据 利润表添加数据
            ///3 客户是否付款登记,如未登记 则进行 客户待回收账登记
            ///4 商品库存管理
            ///关闭窗口.
            
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例
            //获取订单表
            var OrdersInfo = f1.OrdersInfo;
           
            decimal allProfit = (decimal)0;
            decimal allDisCount = (decimal)0;
            string orderId = OrdersInfo[0].OrderId;//个数保证大于0;
            for (int i = 0; i < OrdersInfo.Count; i++)
            {
                //下订单
                var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(OrdersInfo[i].GoodsId);
                var salesCount = goodsInfo.SalesCount + OrdersInfo[i].Count;//卖出数量
                var surplusCount= goodsInfo.SurplusCount- OrdersInfo[i].Count; //剩余数量
                var isSucess= DataManager.OrderInfoBLL.Add(OrdersInfo[i]);
                if (!isSucess)
                {
                    MessageBox.Show("下订单失败,请重试,如多次失败请联系管理员");
                    return;
                }
                //改库存
                var editSucess = DataManager.GoodsInfoBLL.EditGoodsInfoCount(goodsInfo.Id, salesCount, surplusCount);
                if (!editSucess)
                {
                    MessageBox.Show("修改失败,请重试,如多次失败请联系管理员");
                    return;
                }

                allProfit += OrdersInfo[i].Profit;//利润
                allDisCount += OrdersInfo[i].DisCount;//折扣
            }
            //利润信息表
            ProfitsInfo profitsInfo = new ProfitsInfo();
            profitsInfo.OrderId = orderId;
            profitsInfo.CreateTime = DateTime.Now;
            profitsInfo.Profit = allProfit;
            profitsInfo.DisCount = allDisCount;
            profitsInfo.PayPrices = decimal.Parse( _payPrice);
            profitsInfo.IsPay = false;//默认为未收款
            f1.TempProfit = profitsInfo;//下单完成则利润表完成
            f1.OrdersInfo = new List<OrderInfo>();//清空订单表
            this.Close();

            


        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
