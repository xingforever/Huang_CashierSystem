using Common_Winform;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataGridViewHelper dataGridViewHelper = new DataGridViewHelper();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataManager dataManager = new DataManager();
            SearchModel searchModel = new SearchModel();
            List<string> nameList = new List<string>();
            List<string> handerTxt = new List<string>();
            List<int> hideIndex = new List<int>();
            DataManager.GetHandTxtAndHideIndex(0, ref nameList, ref handerTxt, ref hideIndex);
            this.dataGridView1 = dataGridViewHelper.Init(this.dataGridView1, nameList, handerTxt, hideIndex);
          var   dataTable = DataManager.GoodsInfoBLL.GetDataTablebyPammer(searchModel);

            this.dataGridView1 = dataGridViewHelper.FillData(dataGridView1, dataTable);
        }
            
    }
}
