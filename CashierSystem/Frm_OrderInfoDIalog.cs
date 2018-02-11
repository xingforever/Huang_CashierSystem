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
        public bool IsPay = false;
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
            ///操作步骤: 1获取订单表数据 ,将订单表数据添加数据库
            ///2计算 利润 ,将得出利润数据 利润表添加数据
            ///3 客户是否付款登记,如未登记 则进行 客户待回收账登记
            ///4 商品库存管理
            ///关闭窗口.




            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例
            //获取订单表
            var OrdersInfo = f1.OrdersInfo;
           
            decimal allProfit = (decimal)0;
            string orderId = OrdersInfo[0].OrderId;//个数保证大于0;
            for (int i = 0; i < OrdersInfo.Count; i++)
            {
                //下订单
                var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(OrdersInfo[i].GoodsId);
                var salesCount = goodsInfo.SalesCount + OrdersInfo[i].Count;
                var surplusCount= goodsInfo.SurplusCount- OrdersInfo[i].Count; 
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
            }
            ProfitsInfo salesInfo = new ProfitsInfo();
            salesInfo.OrderId = orderId;
            salesInfo.CreateTime = DateTime.Now;
            var result=  MessageBox.Show("下单完成,是否已经收款?", "通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                //下单完成
                salesInfo.IsPay = true;
            }
            else
            {
                //未付款
                salesInfo.IsPay = false;
                //弹出窗口 ,进行未付账人信息登记
            }
          
            var isSuccess = DataManager.SalesInfoBLL.Add(salesInfo);
            if (!isSuccess)
            {
                MessageBox.Show("利润表数据添加失败,如多次失败请联系管理员");
                return;
            }



            f1.OrdersInfo = new List<OrderInfo>();//清空订单表
            this.Close();
        }
    }
}
