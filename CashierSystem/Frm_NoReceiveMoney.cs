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
        public static int _entityId = int.MaxValue;
        public static  string _orderId = null;
        public static string _waitPayPrice = null;
        public Frm_NoReceiveMoney()
        {
            InitializeComponent();
        }
        private static Frm_NoReceiveMoney _form;
        public static Frm_NoReceiveMoney Create(int entityId=int.MaxValue)
        {
            //修改
            if (entityId != int.MaxValue)
            {
                _entityId = entityId;
                NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(entityId);
                _orderId = noReceiveMoney.OrderId;
            }
           
            if (_form == null)
            {
                _form = new Frm_NoReceiveMoney();
                
            }
          
            return _form;
        }
        public static Frm_NoReceiveMoney Create(string  orderId=null ,string payPrice=null )
        {
            _orderId = orderId;
            _waitPayPrice = payPrice;               

            if (_form == null)
            {
                _form = new Frm_NoReceiveMoney();

            }
            
            return _form;
        }


        private void btnNoMEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData())
                {
                    return;
                }

                //修改数据
                if (_entityId != int.MaxValue)
                {
                    NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(_entityId);
                    if (noReceiveMoney != null)
                    {

                        noReceiveMoney.CustomerName = this.txtNoM_CustomerName.Text;
                        noReceiveMoney.Phone = this.txtNoM_Phone.Text;
                        noReceiveMoney.Remark = this.txtNoM_Remark.Text;
                        var isSuccess = DataManager.NoReceiveMoneyBLL.Edit(noReceiveMoney);
                        if (isSuccess)
                        {
                            ClearData();
                            this.Tag = "true";//通知父窗口 ,可以关闭
                            this.Close();
                        }


                    }
                }
                //添加数据
                else if (_orderId != null)
                {
                    NoReceiveMoney noReceiveMoney = new NoReceiveMoney();
                    noReceiveMoney.OrderId = _orderId;
                    noReceiveMoney.CustomerName = this.txtNoM_CustomerName.Text.Trim();
                    noReceiveMoney.Phone = this.txtNoM_Phone.Text.Trim();
                    noReceiveMoney.WaitPayPrice = Convert.ToDecimal(this.txtNoM_Money.Text.Trim());
                    noReceiveMoney.CreateTime = DateTime.Now;
                    noReceiveMoney.Remark = this.txtNoM_Remark.Text;
                    var isSuccess = DataManager.NoReceiveMoneyBLL.Add(noReceiveMoney);
                    if (isSuccess)
                    {
                        ClearData();
                        this.Tag = "true";//通知父窗口 ,可以关闭
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("操作失败");
                    this.Tag = "false";//通知父窗口 ,不可以关闭
                }
            }
            catch (Exception)
            {

                MessageBox.Show("操作失败,请检查信息是否正确!!");
                return;
            }
           

        }

        private void Frm_NoReceiveMoney_Load(object sender, EventArgs e)
        {
            Init();
            this.Tag = "false";//通知父窗口 ,不可以关闭
        }

        public void Init()
        {

            if (_entityId!=int.MaxValue)
            {
                NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(_entityId);
                if (noReceiveMoney != null)
                {
                    this.txtNoM_OrderId.Text = noReceiveMoney.OrderId;
                    this.txtNoM_CustomerName.Text = noReceiveMoney.CustomerName;
                    this.txtNoM_Phone.Text = noReceiveMoney.Phone;
                    this.txtNoM_Remark.Text = noReceiveMoney.Remark;
                    this.txtNoM_Money.Text = noReceiveMoney.WaitPayPrice.ToString();

                }
            }
            else if (_orderId!=null)
            {
                this.txtNoM_OrderId.Text = _orderId;
                this.txtNoM_Money.Text = _waitPayPrice;
            }
            else
            {
                MessageBox.Show("发生意外情况,请联系开发人员");
            }
            

        }

        public  void ClearData()
        {
            this.txtNoM_CustomerName.Text = "";
            this.txtNoM_Money.Text = "";
            this.txtNoM_OrderId.Text = "";
            this.txtNoM_Phone.Text = "";
            this.txtNoM_Remark.Text = "";
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

        private void btnNoMCancel_Click(object sender, EventArgs e)
        {
            this.Tag = "false";//通知父窗口 ,不可以关闭
            this.Close();
        }
    }
}
