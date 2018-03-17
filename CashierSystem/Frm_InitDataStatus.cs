using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_InitDataProgressBar : Form
    {
        public static  bool IsWatting = true;
    
       
        public Frm_InitDataProgressBar()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//取消线程间的安全检查
           
        }

        private void Frm_InitDataProgressBar_Load(object sender, EventArgs e)
        {



        }
       
     
    }
}
