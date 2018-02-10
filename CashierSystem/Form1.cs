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
        /// 被选择表Index
        /// </summary>
        public int SelectIndex = 0;
        public List<OrderInfo> OrdersInfo = new List<OrderInfo>();//下单表 无数据库支持


        /// <summary>
        /// 标签页选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {

        }


        private void Huang_System_Load(object sender, EventArgs e)
        {
            LoadAllDgv();
            tabMain.SelectedIndex = 0;
            SelectIndex = 0;

        }
        /// <summary>
        /// 初始化所有DataGridView样式
        /// </summary>
        public  void LoadAllDgv()
        {
            
            for (int i = 0; i < 7; i++)
            {
                SearchModel searchModel = new SearchModel();
                List<string> nameList = new List<string>();
                List<string> handerTxt = new List<string>();
                List<int> hideIndex = new List<int>();
                DataManager.GetHandTxtAndHideIndex(i, ref nameList, ref handerTxt, ref hideIndex);               
                if (i==0)
                {
                    this.dgvGoodsInfo.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvGoodsInfo = dataGridViewHelper.Init(this.dgvGoodsInfo, nameList, handerTxt, hideIndex);
                    GetDgv(0);
                }
                else  if (i == 4)
                {
                    this.dgvUnitInfo.Tag = false;
                    this.dgvUnitInfo = dataGridViewHelper.Init(this.dgvUnitInfo, nameList, handerTxt,  hideIndex);
                }else if (i == 5)
                {
                    this.dgvSortInfo.Tag = false;
                    this.dgvSortInfo = dataGridViewHelper.Init(this.dgvSortInfo, nameList, handerTxt,  hideIndex);
                }
               else if (i == 6)
                {
                    this.dgvWholeSalerInfo.Tag = false;
                    this.dgvWholeSalerInfo = dataGridViewHelper.Init(this.dgvWholeSalerInfo, nameList, handerTxt,  hideIndex);
                }else if (i == 7)
                {
                    this.dgvUnitInfo.Tag = false;
                    this.dgvUserInfo = dataGridViewHelper.Init(this.dgvUserInfo, handerTxt, nameList,  hideIndex);
                }
            }
          
        }

        /// <summary>
        /// 获取数据并展示在响应的标签页
        /// </summary>
        /// <param name="id"></param>
        public void GetDgv(int id,SearchModel searchModel=null)
        {
            DataTable dataTable = DataManager.LoadBySelectId(id);
            if (searchModel == null)
            {
                //搜索条件有默认条件
                searchModel = new SearchModel();
            }
           
            switch (id)
            {
                case 0:
                    if (!(bool)this.dgvGoodsInfo.Tag)
                    {
                        dataTable = DataManager.GoodsInfoBLL.GetDataTablebyPammer(searchModel);
                        this.dgvGoodsInfo = dataGridViewHelper.FillData(this.dgvGoodsInfo, dataTable);
                        LoadGoodsInfo(searchModel);
                        this.dgvGoodsInfo.Tag = true;
                    }
                    
                    break;
                case 1:
                    break;
                case 4:
                    this.dgvUnitInfo = dataGridViewHelper.FillData(this.dgvUnitInfo, dataTable);
                    this.tspUnitInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 5:
                    this.dgvSortInfo = dataGridViewHelper.FillData(this.dgvSortInfo, dataTable);
                    this.tspSortInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 6:
                    this.dgvWholeSalerInfo = dataGridViewHelper.FillData(this.dgvWholeSalerInfo, dataTable);
                    this.tspWholeSalerInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 7:
                    this.dgvUserInfo = dataGridViewHelper.FillData(this.dgvUserInfo, dataTable);
                    this.tspUserCount.Text = dataTable.Rows.Count.ToString();
                    break;
            }



        }
        /// <summary>
        /// 标签页选中项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndex = tabMain.SelectedIndex;//获取选中标签页的名字
            GetDgv(SelectIndex);
        }

        #region 商品单位表
        /// <summary>
        /// 单位表添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspAddUnitInfo_Click(object sender, EventArgs e)
        {

            List<string> tags = new List<string>();
            Frm_UnitInfo frm_Samll = Frm_UnitInfo.Create(tags);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();


        }
        /// <summary>
        /// 单位表编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspEditUnitInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvUnitInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvUnitInfo.SelectedRows[0];           
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            UnitInfo unitInfo = DataManager.UnitInfoBLL.GetEntityById(dataId);
            List<string> tags = new List<string>() { unitInfo.Id.ToString(), unitInfo.UnitName, unitInfo.Remark };
            Frm_UnitInfo frm_Samll = Frm_UnitInfo.Create(tags);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }
        /// <summary>
        /// 单位表删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspDeleteUnitInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvUnitInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvUnitInfo.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var result = MessageBox.Show("确认删除该商品单位?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                var isDelete = DataManager.UnitInfoBLL.Delete(dataId);
                if (!isDelete)
                {
                    MessageBox.Show("删除失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GetDgv(SelectIndex);//刷新
            }
            else
            {
                ;
            }
        }
        /// <summary>
        /// 单位表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspReLoadUnitInfo_Click(object sender, EventArgs e)
        {
            GetDgv(SelectIndex);
        }


        #endregion
        #region 商品类别表

        private void tspAddSortinfo_Click(object sender, EventArgs e)
        {

            Frm_SortInfo frm_Samll = Frm_SortInfo.Create();
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspEidtSortInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvSortInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvSortInfo.SelectedRows[0];           
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            SortInfo sortInfo = DataManager.SortInfoBLL.GetEntityById(dataId);
            List<string> tags = new List<string>() { sortInfo.Id.ToString(), sortInfo.SortName, sortInfo.Remark };
            Frm_SortInfo frm_Samll = Frm_SortInfo.Create(tags);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspDeleteSortInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvSortInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvSortInfo.SelectedRows[0];
           
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var result = MessageBox.Show("确认删除该商品类别?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                var isDelete = DataManager.SortInfoBLL.Delete(dataId);
                if (!isDelete)
                {
                    MessageBox.Show("删除失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GetDgv(SelectIndex);//刷新
            }
            else
            {
                ;
            }
        }

        private void tspReLoadSortInfo_Click(object sender, EventArgs e)
        {
            GetDgv(SelectIndex);//刷新
        }
        #endregion        
        #region 供货信息表
        private void tspAddWholeSalerInfo_Click(object sender, EventArgs e)
        {

            Frm_WholeSalerInfo frm_Samll = Frm_WholeSalerInfo.Create();
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspEditWholeSalerInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvWholeSalerInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvWholeSalerInfo.SelectedRows[0];
             var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            WholeSalerInfo wholeSalerInfo = DataManager.WholeSalerInfoBLL.GetEntityById(dataId);
            List<string> tags = new List<string>() { wholeSalerInfo.Id.ToString(), wholeSalerInfo.SupName, wholeSalerInfo.Management, wholeSalerInfo.TelePhone, wholeSalerInfo.AddressInfo, wholeSalerInfo.Remark };
            Frm_WholeSalerInfo frm_Samll = Frm_WholeSalerInfo.Create(tags);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspDeleteWholeSalerInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvWholeSalerInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvUnitInfo.SelectedRows[0];           
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var result = MessageBox.Show("确认删除该商品类别?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                var isDelete = DataManager.WholeSalerInfoBLL.Delete(dataId);
                if (!isDelete)
                {
                    MessageBox.Show("删除失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GetDgv(SelectIndex);//刷新
            }
            else
            {
                ;
            }
        }

        private void txtReLoadWholeSalerInfo_Click(object sender, EventArgs e)
        {
            GetDgv(SelectIndex);
        }
        #endregion
        #region 管理员信息表
        private void tspAddUserInfo_Click(object sender, EventArgs e)
        {
            Frm_UserInfo frm_Samll = Frm_UserInfo.Create();
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspEditUserInfo_Click(object sender, EventArgs e)
        {
            if (this.dgvUserInfo.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvUserInfo.SelectedRows[0];

            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            UserInfo userInfo = DataManager.UserInfoBLL.GetEntityById(dataId);
            List<string> tags = new List<string>() { userInfo.Id.ToString(), userInfo.UserName, userInfo.Remark };
            Frm_UserInfo frm_Samll = Frm_UserInfo.Create(tags);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
        }

        private void tspDeleteUserInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("非管理员无权限删除");

        }

        private void tspReLoadUserInfo_Click(object sender, EventArgs e)
        {
            GetDgv(SelectIndex);
        }
        #endregion



        /// <summary>
        /// 初始化GoodInfos
        /// </summary>
        /// <param name="goodsSearch"></param>
        private void LoadGoodsInfo(SearchModel goodsSearch)
        {

            cbxSortsInfo.ValueMember = "Id";
            cbxSortsInfo.DisplayMember = "SortName";
            cbxSortsInfo.DataSource = GetSortInfoList();           
            cbxUnitInfo.ValueMember = "Id";
            cbxUnitInfo.DisplayMember = "UnitName";
            cbxUnitInfo.DataSource = GetUnitInfoList();            
            string goodsName = "";
            string  sortId = "0";
             string  unitId = "0";
            txtGoodsNameSearch.Text = goodsSearch.dic.TryGetValue("GoodsName", out goodsName)? goodsName:"";
            unitId = goodsSearch.dic.TryGetValue("UnitId", out unitId) ? unitId : "0";
            sortId = goodsSearch.dic.TryGetValue("SortId", out sortId) ? sortId : "0";
            cbxUnitInfo.SelectedValue = Convert.ToInt32(unitId);
            cbxSortsInfo.SelectedValue = Convert.ToInt32(sortId);
         
           



        }

        private void SearchLoadGoodsInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "GoodsInfo";
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();
            //搜索
            if (startIndex == 0)
            {
                var sortId = (cbxSortsInfo.SelectedValue).ToString();//类型
                var unitId = (cbxUnitInfo.SelectedValue).ToString();//单位
                var goodsName = txtGoodsNameSearch.Text.Trim();
                if (sortId != "0")
                {
                    searchModel.dic.Add("SortId", sortId);
                }
                if (unitId != "0")
                {
                    searchModel.dic.Add("UnitId", unitId);
                }
                if (goodsName!="")
                {
                    searchModel.dic.Add("GoodsName", goodsName);
                }


            }
            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvGoodsInfo.Tag = false;//false 表示需要更新
            GetDgv(0, searchModel);
        }




        /// <summary>
        /// 获取单位表
        /// </summary>
        /// <returns></returns>
        private List<UnitInfo> GetUnitInfoList()
        {
         var list= DataManager.UnitInfoBLL.GetList();
            list.Insert(0, new UnitInfo()
            {
                Id = 0,
                UnitName = "全部"

            });
            return list;

        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public List<SortInfo> GetSortInfoList()
        {

          var list=  DataManager.SortInfoBLL.GetList();
            list.Insert(0, new SortInfo()
            {
                Id=0,
                SortName="全部"

            });
            return list;

        }

        /// <summary>
        /// 未选中行操作提示
        /// </summary>
        public void UnSelectedTips()
        {
            MessageBox.Show("未选中行,请单击表格某行 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

       

        private void btnGoodsSearch_Click(object sender, EventArgs e)
        {
            SearchLoadGoodsInfo();
        }

        private void dgvGoodsInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            var dataRow = this.dgvGoodsInfo.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            //将数据添加到下单表            
            AddGoodsToOrder(dataId);
            LoadOrdersInfo();
        }
        public void LoadOrdersInfo()
        {
            var count = this.dgvOrdersInfo.Rows.Count;
            var ddd = this.dgvOrdersInfo.ColumnCount;
            this.dgvOrdersInfo.Rows.Clear();//清除数据

            foreach (OrderInfo order in OrdersInfo)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dgvOrdersInfo);
                dataGridViewRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewRow.Cells[0].Value = order.GoodsId;
                dataGridViewRow.Cells[1].Value = order.GoodsName;
                dataGridViewRow.Cells[2].Value = order.Count;
                dataGridViewRow.Cells[3].Value = order.PayPice;
                dataGridViewRow.Cells[4].Value = order.DisCount;
                dataGridViewRow.Cells[5].Value = order.Remark;
                this.dgvOrdersInfo.Rows.Add(dataGridViewRow);
            }
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public  bool  AddGoodsToOrder(int goodsId,int count=1)
        {
            var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(goodsId);
            var maxCount = goodsInfo.SurplusCount;//库存量
            bool isHaveSame = false;//下单表中有相同商品
            //将数据添加到下单表            
            foreach (OrderInfo item in OrdersInfo)
            {
                if (item.GoodsId == goodsId)
                {
                    if ((item.Count + count) <= maxCount)
                    {
                        item.Count += count;//
                        item.PayPice = goodsInfo.PayPrice * item.Count;
                        isHaveSame = true;
                    }
                    else
                    {
                        return false;//库存不够
                    }
                }
            }
            //订单表中 无此商品 ,
            if (!isHaveSame)
            {
                OrderInfo orderInfo = new OrderInfo();
                orderInfo.GoodsId = goodsId;
                orderInfo.Count = count;
                orderInfo.GoodsName = goodsInfo.GoodsName;
                orderInfo.PayPice = goodsInfo.PayPrice * orderInfo.Count;
                if (count>maxCount)
                {
                    return false;
                }
                OrdersInfo.Add(orderInfo);
            }
            return true;

        }

        /// <summary>
        /// 订单表行标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrdersInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               this.dgvOrdersInfo.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                  this.dgvOrdersInfo.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                  this.dgvOrdersInfo.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 下单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (OrdersInfo.Count<1)
            {
                MessageBox.Show("订单表中无商品,请双击商品信息表中信息添加商品","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            Frm_OrderInfoDIalog frm_Samll = Frm_OrderInfoDIalog.Create();
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();

           
        }
    }
}
