using Common;
using Common_API;
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
        /// 登录操作员ID
        /// </summary>
        public int loginId = int.MaxValue;
        /// <summary>
        /// 是否联网
        /// </summary>
        public bool isPingSuccess = false;
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
        /// <summary>
        /// 临时下单号
        /// </summary>
        public string OrderId = "";
        /// <summary>
        /// 临时下单表
        /// </summary>
        public List<OrderInfo> OrdersInfo = new List<OrderInfo>();
        /// <summary>
        /// 操作员修改应收款数造成的折扣
        /// 并未对某项商品进行折扣
        /// </summary>
        public decimal OrderDisCount = (decimal)0.0;


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
            isPingSuccess = IsConnectionNET.IsConnect();
            LoadAllDgv();//加载所有dgv
            LoadWeatherAndAlmanac();//加载天气和黄历
            tabMain.SelectedIndex = 0;//默认第一页被选中
            SelectIndex = 0;

        }
        /// <summary>
        /// 初始化所有DataGridView样式
        /// </summary>
        public void LoadAllDgv()
        {

            for (int i = 0; i <=9; i++)
            {
                SearchModel searchModel = new SearchModel();
                List<string> nameList = new List<string>();
                List<string> handerTxt = new List<string>();
                List<int> hideIndex = new List<int>();
                DataManager.GetHandTxtAndHideIndex(i, ref nameList, ref handerTxt, ref hideIndex);
                if (i == 0)
                {
                    LoadGoodsInfo();//加载条件框
                    this.dgvGoodsInfo.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvGoodsInfo = dataGridViewHelper.Init(this.dgvGoodsInfo, nameList, handerTxt, hideIndex);
                    GetDgv(0);
                }
                else if (i == 1)
                {
                    LoadTodayOrderInfo();
                    this.dgvTodayOrder.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvTodayOrder = dataGridViewHelper.Init(this.dgvTodayOrder, nameList, handerTxt, hideIndex);
                    GetDgv(1);
                }
                else if (i == 2)
                {
                    LoadGoodsInfoManager();
                    this.dgvGoodSInfoManager.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvGoodSInfoManager = dataGridViewHelper.Init(this.dgvGoodSInfoManager, nameList, handerTxt, hideIndex);
                    GetDgv(2);
                }
                else if (i == 3)
                {
                    this.dgvAllOrder.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvAllOrder = dataGridViewHelper.Init(this.dgvAllOrder, nameList, handerTxt, hideIndex);
                    GetDgv(3);
                }
                else if (i == 4)
                {
                    this.dgvProfitsInfo.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvProfitsInfo = dataGridViewHelper.Init(this.dgvProfitsInfo, nameList, handerTxt, hideIndex);
                    GetDgv(4);
                }
                else if (i == 5)
                {
                    this.dgvNoReceiveMoney.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvNoReceiveMoney = dataGridViewHelper.Init(this.dgvNoReceiveMoney, nameList, handerTxt, hideIndex);
                    GetDgv(4);
                }

                else if (i == 6)
                {
                    this.dgvUnitInfo.Tag = false;
                    this.dgvUnitInfo = dataGridViewHelper.Init(this.dgvUnitInfo, nameList, handerTxt, hideIndex);
                } else if (i == 7)
                {
                    this.dgvSortInfo.Tag = false;
                    this.dgvSortInfo = dataGridViewHelper.Init(this.dgvSortInfo, nameList, handerTxt, hideIndex);
                }
                else if (i == 8)
                {
                    this.dgvWholeSalerInfo.Tag = false;
                    this.dgvWholeSalerInfo = dataGridViewHelper.Init(this.dgvWholeSalerInfo, nameList, handerTxt, hideIndex);
                } else if (i == 9)
                {
                    this.dgvUnitInfo.Tag = false;
                    this.dgvUserInfo = dataGridViewHelper.Init(this.dgvUserInfo, nameList, handerTxt, hideIndex);
                }
            }

        }
        /// <summary>
        /// 初始化,加载黄历与天气
        /// </summary>
        public void LoadWeatherAndAlmanac()
        {
            //如果联网成功
            if (isPingSuccess)
            {
                #region 黄历显示
                var myAlmanac = AlmanacApiHelper.GetAlmanac();
                if (myAlmanac.IsGetSuccess)
                {
                    lblAlmamcDate.Text = myAlmanac.date;
                    lblAlmamcNongli.Text = myAlmanac.nongli;
                    lblAlmamcJi.Text = myAlmanac.ji;
                    lblAlmamcYi.Text = myAlmanac.yi;
                    lblAlmamcNongli = LabelHelper.GetAutoSizeLabel(lblAlmamcNongli, myAlmanac.nongli);
                    lblAlmamcDate = LabelHelper.GetAutoSizeLabel(lblAlmamcDate, myAlmanac.date);
                    lblAlmamcJi = LabelHelper.GetAutoSizeLabel(lblAlmamcJi, myAlmanac.ji);
                    lblAlmamcYi = LabelHelper.GetAutoSizeLabel(lblAlmamcYi, myAlmanac.yi);

                }
                else
                {
                    lblAlmamcDate.Text = "网络连接失败,黄历无法正常显示";
                    lblAlmamcNongli.Text = "";
                    lblAlmamcJi.Text = "";
                    lblAlmamcYi.Text = "";
                }
                #endregion

                var weather = WeatherHelper.GetSupportProvince();



            }
        }

        /// <summary>
        /// 获取数据并展示在响应的标签页
        /// </summary>
        /// <param name="id"></param>
        public void GetDgv(int id, SearchModel searchModel = null)
        {
            DataTable dataTable = new DataTable();
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
                        LoadGoodsInfoStatus(searchModel);//加载状态栏
                        this.dgvGoodsInfo.Tag = true;
                    }

                    break;
                case 1:
                    if (!(bool)this.dgvTodayOrder.Tag)
                    {
                       
                        dataTable = DataManager.OrderInfoBLL.GetTodayDataTable(searchModel);
                        this.dgvTodayOrder = dataGridViewHelper.FillData(this.dgvTodayOrder, dataTable);                       
                        this.dgvTodayOrder.Tag = true;
                    }
                    break;
                case 2:
                    if (!(bool)this.dgvGoodSInfoManager.Tag)
                    {
                     
                        dataTable = DataManager.GoodsInfoBLL.GetDataTablebyPammer(searchModel);
                        this.dgvGoodSInfoManager = dataGridViewHelper.FillData(this.dgvGoodSInfoManager, dataTable);
                        this.dgvGoodSInfoManager.Tag = true;
                    }
                    break;
                case 3:
                    if (!(bool)this.dgvAllOrder.Tag)
                    {
                        dataTable = DataManager.OrderInfoBLL.GetDataTablebyPammer(searchModel);
                        this.dgvAllOrder = dataGridViewHelper.FillData(this.dgvAllOrder, dataTable);
                        LoadAllOrderInfo(searchModel);
                        this.dgvAllOrder.Tag = true;
                    }
                    break;
                case 4:
                    if (!(bool)this.dgvProfitsInfo.Tag)
                    {
                        dataTable = DataManager.ProfitsInfoBLL.GetDataTablebyPammer(searchModel);
                        this.dgvProfitsInfo = dataGridViewHelper.FillData(this.dgvProfitsInfo, dataTable);
                        LoadProfitsInfo(searchModel);
                        this.dgvProfitsInfo.Tag = true;
                    }
                    break;
                case 5:
                    if (!(bool)this.dgvNoReceiveMoney.Tag)
                    {
                        dataTable = DataManager.NoReceiveMoneyBLL.GetDataTablebyPammer(searchModel);
                        this.dgvNoReceiveMoney  = dataGridViewHelper.FillData(this.dgvNoReceiveMoney, dataTable);
                        LoadNoReceiveMoneyInfo(searchModel);
                        this.dgvNoReceiveMoney.Tag = true;
                    }
                    break;
                case 6:
                    dataTable = DataManager.UnitInfoBLL.GetDataTable();
                    this.dgvUnitInfo = dataGridViewHelper.FillData(this.dgvUnitInfo, dataTable);
                    this.tspUnitInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 7:
                    dataTable = DataManager.SortInfoBLL.GetDataTable();
                    this.dgvSortInfo = dataGridViewHelper.FillData(this.dgvSortInfo, dataTable);
                    this.tspSortInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 8:
                    dataTable = DataManager.WholeSalerInfoBLL.GetDataTable();
                    this.dgvWholeSalerInfo = dataGridViewHelper.FillData(this.dgvWholeSalerInfo, dataTable);
                    this.tspWholeSalerInfoCount.Text = dataTable.Rows.Count.ToString();
                    break;
                case 9:
                    dataTable = DataManager.UserInfoBLL.GetDataTable();
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

        #region 商品展示信息

        /// <summary>
        /// 初始化GoodInfos
        /// </summary>
        /// <param name="goodsSearch"></param>
        private void LoadGoodsInfo()
        {

            cbxSortsInfo.ValueMember = "Id";
            cbxSortsInfo.DisplayMember = "SortName";
            cbxSortsInfo.DataSource = GetSortInfoList();
            cbxUnitInfo.ValueMember = "Id";
            cbxUnitInfo.DisplayMember = "UnitName";
            cbxUnitInfo.DataSource = GetUnitInfoList();
            cbxUnitInfo.SelectedValue = 0;
            cbxSortsInfo.SelectedValue = 0;

        }
        /// <summary>
        /// 状态条初始化
        /// </summary>
        /// <param name="searchModel">搜索条件</param>
        public void LoadGoodsInfoStatus(SearchModel searchModel)
        {
            int lastIndex = searchModel.lastIndex;
            int nextIndex = searchModel.nextIndex;
            double pageSize = Seeting.GoodsInfoPageCount;

            if (tspGoodsPageCount.Tag.ToString() != "-1")
            {
                //重新更换搜索条件后
                // 采用获取top 所有数据
                //此处破坏了每页数量和下一页起始页ID
                int count = DataManager.GoodsInfoBLL.GetDataTableCountByPammer(searchModel);
                int pageSum = Convert.ToInt32(Math.Ceiling(count / pageSize));//总页数
                tspGoodsPageCount.Text = pageSum.ToString();
                lastIndex = -1;
                if (pageSum <= 1)
                {
                    nextIndex = -1;
                }
                tspGoodsPageCount.Tag = "-1";
            }

            tspGoodsLastPage.Tag = lastIndex;
            tspGoodsNextPage.Tag = nextIndex;
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspGoodsLastPage_Click(object sender, EventArgs e)
        {
            int pageSum = Convert.ToInt32(tspGoodsPageCount.Text);
            int pageNow = Convert.ToInt32(tspGoodsPage.Text);
            int lastId = Convert.ToInt32(tspGoodsLastPage.Tag);
            bool isTrue = CommonHelper.GetTruePage(pageSum, pageNow, lastId, false);
            if (isTrue)
            {
                SearchLoadGoodsInfo(lastId);
                tspGoodsPage.Text = (pageNow - 1).ToString();
            }

        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspGoodsNextPage_Click(object sender, EventArgs e)
        {
            int pageSum = Convert.ToInt32(tspGoodsPageCount.Text);
            int pageNow = Convert.ToInt32(tspGoodsPage.Text);
            int nextId = Convert.ToInt32(tspGoodsNextPage.Tag);
            bool isTrue = CommonHelper.GetTruePage(pageSum, pageNow, nextId, true);
            if (isTrue)
            {
                SearchLoadGoodsInfo(nextId);
                tspGoodsPage.Text = (pageNow + 1).ToString();
            }

        }
        /// <summary>
        /// 搜索商品信息
        /// </summary>
        /// <param name="startIndex"></param>
        private void SearchLoadGoodsInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "GoodsInfo";
            searchModel.count = Seeting.GoodsInfoPageCount;
            searchModel.lastIndex = searchModel.startIndex;//上一页开始行
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();
            //搜索           
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
            if (goodsName != "")
            {
                searchModel.dic.Add("GoodsName", goodsName);
            }
            this.dgvGoodsInfo.Tag = false;//false 表示需要更新
            GetDgv(0, searchModel);//获取数据同时将下一页开始行设置
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoodsSearch_Click(object sender, EventArgs e)
        {
            tspGoodsPageCount.Tag = "1";//需要对状态栏进行修改
            SearchLoadGoodsInfo();

        }
        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGoodsInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dataRow = this.dgvGoodsInfo.SelectedRows[0];
                var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
                                                                     //将数据添加到下单表            
                var isAddSucess = AddGoodsToOrder(dataId);
                LoadOrdersInfo();
            }
            catch (Exception)
            {

                return;
            }

        }
        #endregion
        #region 今日订单展示

        /// <summary>
        /// 初始化今日订单表
        /// </summary>
        /// <param name="todayOrderSearch"></param>
        public void LoadTodayOrderInfo()
        {
            string format = "HH:mm:ss";
            dateTodayOrderStartTime.Format = DateTimePickerFormat.Custom;
            dateTodayOrderEndTime.Format = DateTimePickerFormat.Custom;
            dateTodayOrderStartTime.CustomFormat = format;
            dateTodayOrderEndTime.CustomFormat = format;
            DateTime today = DateTime.Today;
            //如果搜索添加中含有 时间 则设置,否则 设置开始时间为今天0.00,终止数据为24.00 
            dateTodayOrderStartTime.Value = today;
            DateTime todayEnd = DateTime.Today + new TimeSpan(23, 59, 59);
            dateTodayOrderEndTime.Value = todayEnd;           
            txtTodaySearchMixMoney.Text = "";
            txtTodaySearchMaxMoney.Text = "";         


        }
        /// <summary>
        /// 今日订单搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTodayOrder_Click(object sender, EventArgs e)
        {
            SearchTodayOrderInfo();
        }
        /// <summary>
        /// 订单搜索
        /// </summary>
        /// <param name="startIndex"></param>
        public void SearchTodayOrderInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "OrderInfo";
            searchModel.count = Seeting.ToadyOrderPageCount;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();
            var StartTime = dateTodayOrderStartTime.Value;
            var EndTime = dateTodayOrderEndTime.Value;
            decimal mixMoney = 0;
            decimal maxMoney = decimal.MaxValue;
            var mixMoneyString = txtTodaySearchMixMoney.Text.Trim();
            var maxMoneyString = txtTodaySearchMaxMoney.Text.Trim();
            //输入价钱是区间是否合格               
            var isTrue = Common.CommonHelper.GetTrueSearchMoney(mixMoneyString, maxMoneyString, out mixMoney, out maxMoney);
            if (!isTrue)
            {
                InputWarngs("输入价格区间有误!!");
                return;
            }
            if (StartTime > EndTime)
            {
                InputWarngs("输入时间有误!!!");
                return;
            }
            var goodsName = txtGoodsNameSearch.Text.Trim();
            if (goodsName != "")
            {
                searchModel.dic.Add("TodaySearchGoodsName", goodsName);
            }
            searchModel.StartTime = StartTime;
            searchModel.EndTime = EndTime;
            searchModel.dic.Add("TodaySearchMaxMoney", maxMoney.ToString());
            searchModel.dic.Add("TodaySearchMixMoney", mixMoney.ToString());

            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvTodayOrder.Tag = false;//false 表示需要更新
            GetDgv(1, searchModel);
        }
        #endregion


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
      
        #region 小订单表操作

        /// <summary>
        /// 小订单表加载
        /// </summary>
        public void LoadOrdersInfo()
        {
            var count = this.dgvOrdersInfo.Rows.Count;
            var ddd = this.dgvOrdersInfo.ColumnCount;
            this.dgvOrdersInfo.Rows.Clear();//清除数据
            decimal AllMoney = (decimal)0.0;
            foreach (OrderInfo order in OrdersInfo)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dgvOrdersInfo);
                dataGridViewRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewRow.Cells[0].Value = order.GoodsId;
                dataGridViewRow.Cells[1].Value = order.GoodsName;
                dataGridViewRow.Cells[2].Value = order.Count;
                dataGridViewRow.Cells[3].Value = order.PayPrice;
                dataGridViewRow.Cells[4].Value = order.DisCount;
                dataGridViewRow.Cells[5].Value = order.Remark;
                AllMoney += order.PayPrice;
                this.dgvOrdersInfo.Rows.Add(dataGridViewRow);
            }

            this.lblOrderMoney.Text = AllMoney.ToString();
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public bool AddGoodsToOrder(int goodsId, int count = 1)
        {
            var goodsInfo = DataManager.GoodsInfoBLL.GetEntityById(goodsId);
            var maxCount = goodsInfo.SurplusCount;//库存量
            bool isHaveSame = false;//下单表中有相同商品
                                    //20180211154701
            if (OrdersInfo.Count == 0)
            {
                OrderId = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            //创建一个订单号  一个列表仅有一个

            //将数据添加到下单表            
            foreach (OrderInfo item in OrdersInfo)
            {
                if (item.GoodsId == goodsId)
                {
                    if ((item.Count + count) <= maxCount)
                    {
                        item.Count += count;//
                        item.PayPrice = (goodsInfo.PayPrice * (decimal)item.Count) - item.DisCount;
                        //利润
                        item.Profit = item.PayPrice - ((goodsInfo.PurPrice) * (decimal)item.Count);
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
                orderInfo.GoodsInfo = goodsInfo;
                orderInfo.GoodsId = goodsId;
                orderInfo.OrderId = OrderId;
                orderInfo.CreateTime = DateTime.Now;
                orderInfo.Count = count;
                orderInfo.GoodsName = goodsInfo.GoodsName;
                orderInfo.PayPrice = (goodsInfo.PayPrice * (decimal)orderInfo.Count) - orderInfo.DisCount;//收款
                orderInfo.Profit = orderInfo.PayPrice - ((goodsInfo.PurPrice) * (decimal)orderInfo.Count);//利润
                if (count > maxCount)
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
            if (OrdersInfo.Count < 1)
            {
                MessageBox.Show("订单表中无商品,请双击商品信息表中信息添加商品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Frm_OrderInfoDIalog frm_Samll = Frm_OrderInfoDIalog.Create(this.lblOrderMoney.Text);
            frm_Samll.ShowDialog(this);
            frm_Samll.Focus();
            //下单成功
            if (OrdersInfo.Count == 0)
            {
                this.dgvOrdersInfo.Rows.Clear();//清除数据
                this.lblOrderMoney.Text = "0.000";//待收款清0
                OrderDisCount = (decimal)0.0;//折扣 
                SearchLoadGoodsInfo();//商品信息页重新加载(保留操作员上次操作)
                this.dgvTodayOrder.Tag = false;//信息需要重新加载
            }

        }
        /// <summary>
        /// 双击 订单表数量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrdersInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dataRow = this.dgvOrdersInfo.SelectedRows[0];
                var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取商品Id
                OrderInfo orderInfo = null;
                int index=int.MaxValue;
                for (int i = 0; i < OrdersInfo.Count; i++)
                {
                    var orderinfo = OrdersInfo[i];
                    if (orderinfo.GoodsId == dataId)
                    {
                        index = i;//传值,用于确定 小定单的位置
                        orderInfo = orderinfo;
                        break;
                    }
                }
                if (orderInfo == null)
                {
                    MessageBox.Show("发生错误,联系开发人员");
                    return;
                }
                Frm_OrderInfo frm_Samll = Frm_OrderInfo.Create(index);
                frm_Samll.ShowDialog(this);
                frm_Samll.Focus();
                LoadOrdersInfo();

            }
            catch (Exception)
            {

                ;
            }

        }
        /// <summary>
        /// 订单应收款修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderEdit_Click(object sender, EventArgs e)
        {
            if (this.txtOrderMoney.Visible)
            {
                this.txtOrderMoney.Focus();
                EditOrderMonry();
            }
            else
            {
                this.lblOrderMoney.Visible = false;
                this.txtOrderMoney.Visible = true;
                this.txtOrderMoney.Text = this.lblOrderMoney.Text;
                this.txtOrderMoney.Focus();
            }

        }
       
        /// <summary>
        /// 订单修改完毕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditOrderMonry();
            }
        }
        /// <summary>
        /// 订单修改完毕
        /// </summary>
        public void EditOrderMonry()
        {
            this.txtOrderMoney.Visible = false;
            var OldMoney = Convert.ToDecimal(this.lblOrderMoney.Text);
            try
            {
                var newMoney = Convert.ToDecimal(this.txtOrderMoney.Text);
                this.lblOrderMoney.Visible = true;
                OrderDisCount = OldMoney - newMoney;//操作用修改应收款的折扣
                this.lblOrderMoney.Text = this.txtOrderMoney.Text;
                //
                for (int i = 0; i < OrdersInfo.Count; i++)
                {
                    OrdersInfo[i].DisCount = Math.Round((OrderDisCount / OrdersInfo.Count));
                    OrdersInfo[i].Remark = "该订单共已折扣" + Math.Round((OrderDisCount / OrdersInfo.Count), 4) + "元";
                    OrdersInfo[i].PayPrice = OrdersInfo[i].PayPrice - Math.Round((OrderDisCount / OrdersInfo.Count), 4);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("操作失误,总价格为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
       
        #region 所有订单展示

        /// <summary>
        /// 加载所有订单表
        /// </summary>
        public void LoadAllOrderInfo(SearchModel allOrderSearch)
        {
            DateTime today = DateTime.Today;
            DateTime weekAgo = today - new TimeSpan(7, 0, 0, 0);
            today = DateTime.Now;//从一周前0.00 开始到现在的时间
            dateAllOrderStartTime.Value = allOrderSearch.StartTime.Equals(new DateTime()) ? weekAgo : allOrderSearch.StartTime;
            dateAllOrderEndTime.Value = allOrderSearch.EndTime.Equals(new DateTime()) ? today : allOrderSearch.EndTime;
            string allOrderSearchGoodsName = "";
            txtAllOrder_SearchName.Text = allOrderSearch.dic.TryGetValue("AllOrderSearchGoodsName", out allOrderSearchGoodsName) ? allOrderSearchGoodsName : "";

        }
        private void btnAllOrderInfo_Click(object sender, EventArgs e)
        {
            SearchAllOrderInfo();
        }
        /// <summary>
        /// 所有订单搜索
        /// </summary>
        /// <param name="startIndex"></param>
        public void SearchAllOrderInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "OrderInfo";
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();

            //搜索
            if (startIndex == 0)
            {
                var StartTime = dateAllOrderStartTime.Value;
                var EndTime = dateAllOrderEndTime.Value;

                if (StartTime > EndTime)
                {
                    InputWarngs("输入时间有误!!!");
                    return;
                }
                var goodsName = txtAllOrder_SearchName.Text.Trim();
                if (goodsName != "")
                {
                    searchModel.dic.Add("AllOrderSearchGoodsName", goodsName);
                }
                searchModel.StartTime = StartTime;
                searchModel.EndTime = EndTime;

            }
            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvAllOrder.Tag = false;//false 表示需要更新
            GetDgv(3, searchModel);
        }
        #endregion
        #region 利润表展示
        /// <summary>
        /// 利润信息表
        /// </summary>
        /// <param name="profitsInfoSearch"></param>
        public void LoadProfitsInfo(SearchModel profitsInfoSearch)
        {
            DateTime today = DateTime.Today;
            DateTime weekAgo = today - new TimeSpan(7, 0, 0, 0);
            today = DateTime.Now;//从一周前0.00 开始到现在的时间
            dateProfitStartTime.Value = profitsInfoSearch.StartTime.Equals(new DateTime()) ? weekAgo : profitsInfoSearch.StartTime;
            dateProfitEndTime.Value = profitsInfoSearch.EndTime.Equals(new DateTime()) ? today : profitsInfoSearch.EndTime;
            string profitsOrderId = "";
            txtProfits_SearchOrderId.Text = profitsInfoSearch.dic.TryGetValue("Profits_OrderId", out profitsOrderId) ? profitsOrderId : "";

        }
        private void btnProfitSearch_Click(object sender, EventArgs e)
        {
            SearchProfitsInfo();
        }
        /// <summary>
        /// 利润信息表搜索
        /// </summary>
        /// <param name="startIndex"></param>
        public void SearchProfitsInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "ProfitsInfo";
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();

            //搜索
            if (startIndex == 0)
            {
                var startTime = dateProfitStartTime.Value;
                var endTime = dateProfitEndTime.Value;

                if (startTime > endTime)
                {
                    InputWarngs("输入时间有误!!!");
                    return;
                }
                var orderId = txtProfits_SearchOrderId.Text.Trim();
                if (orderId != "")
                {
                    searchModel.dic.Add("Profits_OrderId", orderId);
                }
                searchModel.StartTime = startTime;
                searchModel.EndTime = endTime;

            }
            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvProfitsInfo.Tag = false;//false 表示需要更新
            GetDgv(4, searchModel);

        }
        #endregion
        #region 待收账表信息

        /// <summary>
        /// 待收账加载
        /// </summary>
        /// <param name="noReceiveMoneySearch"></param>
        public void LoadNoReceiveMoneyInfo(SearchModel noReceiveMoneySearch)
        {
            string selectVlaue = "0";
            cbxIsReceiveMoney.ValueMember = "Value";
            cbxIsReceiveMoney.DisplayMember = "Name";
            cbxIsReceiveMoney.DataSource = NoReceiveMoney.GetCBXNoRecevicePart();
            noReceiveMoneySearch.dic.TryGetValue("NoReceiveMoney_SelectValue", out selectVlaue);
            if (selectVlaue!="0")
            {
                cbxIsReceiveMoney.SelectedIndex = 1;
            }
            cbxIsReceiveMoney.SelectedIndex = 0;
                DateTime today = DateTime.Today;
            DateTime weekAgo = today - new TimeSpan(7, 0, 0, 0);

            today = DateTime.Now;//从一周前0.00 开始到现在的时间
            dateNoReceiveStartTime.Value = noReceiveMoneySearch.StartTime.Equals(new DateTime()) ? weekAgo : noReceiveMoneySearch.StartTime;
            dateProfitEndTime.Value = noReceiveMoneySearch.EndTime.Equals(new DateTime()) ? today : noReceiveMoneySearch.EndTime;
            string profitsOrderId = "";
            txtProfits_SearchOrderId.Text = noReceiveMoneySearch.dic.TryGetValue("NoReceiveMoney_Name", out profitsOrderId) ? profitsOrderId : "";

        }
        private void btnNoReceiveMoneySearch_Click(object sender, EventArgs e)
        {
            SearchNoReceiveMoneyInfo();
        }
        /// <summary>
        /// 待收账表搜索
        /// </summary>
        /// <param name="startIndex"></param>
        public void SearchNoReceiveMoneyInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "NoReceiveMoney";
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();

            //搜索
            if (startIndex == 0)
            {
                var startTime = dateNoReceiveStartTime.Value;
                var endTime = dateNoReceiveEndTime.Value;
                if (startTime > endTime)
                {
                    InputWarngs("输入时间有误!!!");
                    return;
                }
                var customerName = txtNoReceiveMoney_SearchName.Text.Trim();
                if (customerName != "")
                {
                    searchModel.dic.Add("NoReceiveMoney_Name", customerName);
                }

                searchModel.StartTime = startTime;
                searchModel.EndTime = endTime;

                var selectValue = cbxIsReceiveMoney.SelectedValue.ToString();
                searchModel.dic.Add("NoReceiveMoney_SelectValue", selectValue);

            }
            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvNoReceiveMoney.Tag = false;//false 表示需要更新
            GetDgv(5, searchModel);

        }
        private void tspNoReceiveMoneyInfoEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvNoReceiveMoney.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvNoReceiveMoney.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(dataId);
            List<string> tags = new List<string>();
            Frm_NoReceiveMoney frm_NoReceiveMoney = Frm_NoReceiveMoney.Create(dataId);
            frm_NoReceiveMoney.ShowDialog(this);
            frm_NoReceiveMoney.Focus();



        }

        private void tspNoM_Receive_Click(object sender, EventArgs e)
        {
            if (this.dgvNoReceiveMoney.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvNoReceiveMoney.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var result = MessageBox.Show("改账单已经结清?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                NoReceiveMoney noReceiveMoney = DataManager.NoReceiveMoneyBLL.GetEntityById(dataId);
                var profists = DataManager.ProfitsInfoBLL.GetProfitsInfoByOrderId(noReceiveMoney.OrderId);
                profists.IsPay = true;
                var isFail = !(DataManager.ProfitsInfoBLL.Edit(profists));
                var isFail2 = !(DataManager.NoReceiveMoneyBLL.Delete(dataId));
                if (isFail || isFail2)
                {
                    MessageBox.Show("未知错误!!");
                }
            }

        }
        private void tspNoReceiveMoneyInfoReload_Click(object sender, EventArgs e)
        {
            this.dgvNoReceiveMoney.Tag = false;
            GetDgv(5);
        }
        #endregion

        #region 商品管理表

        public void LoadGoodsInfoManager()
        {
            cbxGIManager_Sort.ValueMember = "Id";
            cbxGIManager_Sort.DisplayMember = "SortName";
            cbxGIManager_Sort.DataSource = GetSortInfoList();
            cbxGIManager_Unit.ValueMember = "Id";
            cbxGIManager_Unit.DisplayMember = "UnitName";
            cbxGIManager_Unit.DataSource = GetUnitInfoList();
            cbxGIManager_WSaler.ValueMember = "Id";
            cbxGIManager_WSaler.DisplayMember = "SupName";
            cbxGIManager_WSaler.DataSource = GetWholeSalerList();        
            cbxGIManager_Unit.SelectedValue = 0;
            cbxGIManager_Sort.SelectedValue = 0;
            cbxGIManager_WSaler.SelectedValue = 0;
        }

        private void tspGoosInfo_Add_Click(object sender, EventArgs e)
        {
            Frm_GoodsInfo frm_GoodsInfo = Frm_GoodsInfo.Create();
            frm_GoodsInfo.ShowDialog();
            frm_GoodsInfo.Focus();
            //刷新商品管理页信息
            this.dgvGoodSInfoManager.Tag = false;
            LoadGoodsInfoManager();
            GetDgv(SelectIndex);//刷新
        }

        private void tspGoodsInfo_Edit_Click(object sender, EventArgs e)
        {
            if (this.dgvGoodSInfoManager.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvGoodSInfoManager.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            // GoodsInfo goodInfo = DataManager.GoodsInfoBLL.GetEntityById(dataId);         ;
            Frm_GoodsInfo frm_GoodsInfo = Frm_GoodsInfo.Create(dataId);
            frm_GoodsInfo.ShowDialog();
            frm_GoodsInfo.Focus();
            this.dgvGoodSInfoManager.Tag = false;
            GetDgv(SelectIndex);//刷新
        }

        private void tspGoodsInfo_Remove_Click(object sender, EventArgs e)
        {
            if (this.dgvGoodSInfoManager.SelectedRows.Count < 0)
            {
                UnSelectedTips();
                return;
            }
            var dataRow = this.dgvGoodSInfoManager.SelectedRows[0];
            var dataId = Convert.ToInt32(dataRow.Cells[0].Value);//获取Id
            var isSuccess = DataManager.GoodsInfoBLL.Delete(dataId);
            if (isSuccess)
            {
                MessageBox.Show("删除成功!", "删除", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.dgvGoodSInfoManager.Tag = false;
                GetDgv(SelectIndex);//刷新
            }
            else
            {
                MessageBox.Show("删除不成功!", "删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tspGoodsInfo_ReLoad_Click(object sender, EventArgs e)
        {
            this.dgvGoodSInfoManager.Tag = false;
            GetDgv(SelectIndex);//刷新
        }
        public void SearchGoodsInfo(int startIndex = 0)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "GoodsInfo";
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();
            //搜索

            var sortId = (cbxGIManager_Sort.SelectedValue).ToString();//类型
            var unitId = (cbxGIManager_Unit.SelectedValue).ToString();//单位
            var wholeSalerId = (cbxGIManager_WSaler.SelectedValue).ToString();//供货商
            var goodsName = txtGIGoosName_Search.Text.Trim();
            if (sortId != "0")
            {
                searchModel.dic.Add("SortId", sortId);
            }
            if (unitId != "0")
            {
                searchModel.dic.Add("UnitId", unitId);
            }
            if (wholeSalerId != "0")
            {
                searchModel.dic.Add("WholeSalerId", wholeSalerId);
            }
            if (goodsName != "")
            {
                searchModel.dic.Add("GoodsName", goodsName);
            }

            decimal mixMoney = 0;
            decimal maxMoney = decimal.MaxValue;
            var mixMoneyString = txtGIManager_MinPrice.Text.Trim();
            var maxMoneyString = txtGIManager_MaxPrice.Text.Trim();
            var isTrue = Common.CommonHelper.GetTrueSearchMoney(mixMoneyString, maxMoneyString, out mixMoney, out maxMoney);//用户输入价钱是区间是否合格               
            if (isTrue)
            {
                searchModel.dic.Add("GIM_MaxMoney", maxMoney.ToString());
                searchModel.dic.Add("GIM_MixMoney", mixMoney.ToString());
            }
            else
            {
                InputWarngs("输入价格区间有误!!");
                return;
            }

            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvGoodSInfoManager.Tag = false;//false 表示需要更新
            GetDgv(2, searchModel);
        }
        private void btnGIManagerSearch_Click(object sender, EventArgs e)
        {
            SearchGoodsInfo();
        }

        private void tspLblLastPage_Click(object sender, EventArgs e)
        {

        }

        private void tspLblNextPage_Click(object sender, EventArgs e)
        {

        }

        #endregion
        /// <summary>
        /// 获取单位表
        /// </summary>
        /// <returns></returns>
        private List<UnitInfo> GetUnitInfoList()
        {
            var list = DataManager.UnitInfoBLL.GetList();
            list.Insert(0, new UnitInfo()
            {
                Id = 0,
                UnitName = "全部"

            });
            return list;

        }

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <returns></returns>
        public List<SortInfo> GetSortInfoList()
        {

            var list = DataManager.SortInfoBLL.GetList();
            list.Insert(0, new SortInfo()
            {
                Id = 0,
                SortName = "全部"

            });
            return list;

        }

        public List<WholeSalerInfo> GetWholeSalerList()
        {
            var list = DataManager.WholeSalerInfoBLL.GetList();
            list.Insert(0, new WholeSalerInfo()
            {
                Id = 0,
                SupName = "全部"

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
        /// <summary>
        /// 输入信息不符合要求警告
        /// </summary>
        /// <param name="messAge"></param>
        public void InputWarngs(string messAge = "输入有误!")
        {
            MessageBox.Show(messAge, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

      
    }
}
