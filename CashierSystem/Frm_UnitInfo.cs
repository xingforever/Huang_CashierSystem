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
    public partial class Frm_UnitInfo : Form
    {
         Frm_UnitInfo()
        {
            InitializeComponent();
        }
        public string _ModelName= "UnitInfo";
        public int entityId=int.MaxValue;
        public static List<string> _Tags;
        //表名, lab1 ,lab2 ,lab3
        private static Frm_UnitInfo _form;
        public static Frm_UnitInfo Create(List<string> tags=null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_UnitInfo();
                _Tags = tags;
            }
            else
            {
                Frm_UnitInfo._Tags = tags;
            }
            return _form;
        }


        public  void   InIt()
        {
            this.Tag = false;
            entityId =int.MaxValue;
            txtFirst.Text = "";         
            txtRmark.Text = "";

            if (_Tags!=null)
            {
                //添加数据
                if (_Tags.Count==0)
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

        private void Frm_UnitInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f

            if (txtFirst.Text=="")
            {
                lbltips.Text = "请检查数据,数据不能为空";
                lbltips.ForeColor = Color.Red;
                return;
            }            
            //添加时候 默认 id 为maxValue
            if (entityId==int.MaxValue)
            {
                //添加
               
                    UnitInfo unitInfo = new UnitInfo();
                    unitInfo.UnitName = txtFirst.Text.Trim();
                    unitInfo.Remark = txtRmark.Text.Trim().Replace(';','.');//替换';'
                //后期 英文";"有作用
                   var isSuccess=  DataManager.UnitInfoBLL.Add(unitInfo);
                    if (!isSuccess)
                    {
                        MessageBox.Show("操作失败!");
                    }
                    this.Tag = true;
                this.lbltips.Visible = false;
                this.lbltips.Text = "";
                this.Close();
                

            }
            else
            {
               
                    UnitInfo unitInfo = new UnitInfo();
                    unitInfo.UnitName = txtFirst.Text.Trim();
                    unitInfo.Remark = txtRmark.Text.Trim();
                    unitInfo.Id = entityId;
                    var isSuccess = DataManager.UnitInfoBLL.Edit(unitInfo);
                    if (!isSuccess)
                    {
                        MessageBox.Show("操作失败!");
                    }
                    this.Close();
                

            }
            //属性界面
            f1.GetDgv(f1.SelectIndex);

        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.lbltips.Visible = false;
            this.lbltips.Text = "";
            this.Close();

        }

        private void Frm_UnitInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Tags = new List<string>();
        }
    }
}
