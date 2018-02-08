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
    public partial class Frm_Samll : Form
    {
        public Frm_Samll()
        {
            InitializeComponent();
        }
        public string _ModelName;
        public int entityId=int.MaxValue;
        public static List<string> _Tags;
        //表名, lab1 ,lab2 ,lab3
        private static Frm_Samll _form;
        public static Frm_Samll Create(List<string> tags=null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_Samll();
                _Tags = tags;
            }
            else
            {
                Frm_Samll._Tags = tags;
            }
            return _form;
        }


        public  void   InIt()
        {
            
            _ModelName = "";
            lblFirst.Text = "";           
            lblThrid.Text ="";
            entityId =int.MaxValue;
            txtFirst.Text = "";         
            txtThrid.Text = "";

            if (_Tags!=null)
            {
                //添加数据
                if (_Tags.Count==3)
                {
                    _ModelName = _Tags[0];
                    lblFirst.Text = _Tags[1];
                    lblThrid.Text = _Tags[2];                  
                    this.Text = "添加";
                }
               
                //修改 3 为id
                else if (_Tags.Count == 6)
                {
                    this.Text = "修改";  
                    _ModelName = _Tags[0];
                    lblFirst.Text = _Tags[1];
                    lblThrid.Text = _Tags[2];                  
                    entityId = Convert.ToInt32(_Tags[3]);
                    txtFirst.Text = _Tags[4];
                    txtThrid.Text = _Tags[5];
                }               
                else
                {
                    MessageBox.Show("发生意外情况,请稍后重试!");
                }
                txtFirst.Focus();//光标定位
            }

        }

        private void Frm_Add_Samll_Load(object sender, EventArgs e)
        {
            InIt();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //添加时候 默认 id 为maxValue
            if (entityId==int.MaxValue)
            {
                //添加

            }

        }
    }
}
