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
    public partial class Frm_About : Form
    {
        public Frm_About()
        {
            InitializeComponent();
        }

        private void Frm_About_Shown(object sender, EventArgs e)
        {
            this.lblTitle.Focus();
        }
    }
}
