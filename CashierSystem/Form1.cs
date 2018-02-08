using Common_Winform;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Huang_System : Form
    {
        public Huang_System()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 管理类
        /// </summary>
        DataManager dataManager = new DataManager();
        /// <summary>
        /// DataGridView类
        /// </summary>
        DataGridViewHelper dataGridViewHelper = new DataGridViewHelper();

        /// <summary>
        /// 标签页选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {
            var id = tabMain.SelectedIndex;//获取选中标签页的名字
            GetDgv(id);
        }
       

        private void Huang_System_Load(object sender, EventArgs e)
        {
             GetDgv(4);//默认商品信息页展示
            tabMain.SelectedIndex = 4;
            // this.dgvGoodsInfo.DataSource = DataManager.GoodsInfoBLL.GetDataTable();
        }

        public void GetDgv( int id )
        {
            DataTable dataTable = DataManager.LoadBySelectId(tabMain.SelectedIndex);
            List<string> handerTxt = new List<string>();
            List<int> hideIndex = new List<int>();
            DataManager.GetHandTxtAndHideIndex(id,  ref handerTxt, ref  hideIndex);
            switch (id)
            {
                case 0:
                    this.dgvGoodsInfo = dataGridViewHelper.Init(this.dgvGoodsInfo, handerTxt, dataTable, hideIndex);
                    break;
                case 1:
                    break;
                case 4:
                    this.dgvUnitInfo = dataGridViewHelper.Init(this.dgvUnitInfo, handerTxt, dataTable, hideIndex);
                    break;
            }
          


        }
        public  void GetHandTxtAndHideIndex( List<string>handText,List<int>hideIndex)
        {

        }
        /// <summary>
        /// 商品单位表添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tspAddUnitInfo_Click(object sender, EventArgs e)
        {

            List<string> tags = new List<string>() { "UnitInfo", "单位", "备注" };

            Frm_Samll frm_Add_Samll = Frm_Samll.Create(tags);
            frm_Add_Samll.ShowDialog();
            frm_Add_Samll.Focus();


        }
        /// <summary>
        /// 单位表编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspEditUnitInfo_Click(object sender, EventArgs e)
        {
            var dataRow = this.dgvUnitInfo.SelectedRows[0];
            var dataId =  Convert.ToInt32( dataRow.Cells[0].Value);//获取Id
            UnitInfo unitInfo = DataManager.UnitInfoBLL.GetEntityById(dataId);
            List<string> tags = new List<string>() { "UnitInfo", "单位", "备注",unitInfo.Id.ToString(),unitInfo.UnitName,unitInfo.Remark };

            Frm_Samll frm_Samll = Frm_Samll.Create(tags);
            frm_Samll.ShowDialog();
            frm_Samll.Focus();
        }
        /// <summary>
        /// 单位表删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspDeleteUnitInfo_Click(object sender, EventArgs e)
        {

            var dataRow = this.dgvUnitInfo.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var result= MessageBox.Show("确认删除该商品单位?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes )
            {

                var isDelete = DataManager.UnitInfoBLL.Delete(dataId);
                if (!isDelete)
                {
                    MessageBox.Show("删除失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                ;  
            }
        }
    }
}
