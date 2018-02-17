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
            LoadAllDgv();
            LoadWeatherAndAlmanac();
            tabMain.SelectedIndex = 0;
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
                    this.dgvGoodsInfo.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvGoodsInfo = dataGridViewHelper.Init(this.dgvGoodsInfo, nameList, handerTxt, hideIndex);
                    GetDgv(0);
                }
                else if (i == 1)
                {
                    this.dgvTodayOrder.Tag = false;//false 表示需要更新数据  true 表示不需要更新数据
                    this.dgvTodayOrder = dataGridViewHelper.Init(this.dgvTodayOrder, nameList, handerTxt, hideIndex);
                    GetDgv(1);
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
                    this.dgvUserInfo = dataGridViewHelper.Init(this.dgvUserInfo, handerTxt, nameList, hideIndex);
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
                        LoadGoodsInfo(searchModel);
                        this.dgvGoodsInfo.Tag = true;
                    }

                    break;
                case 1:
                    if (!(bool)this.dgvTodayOrder.Tag)
                    {
                        LoadTodayOrderInfo(searchModel);
                        dataTable = DataManager.OrderInfoBLL.GetTodayDataTable(searchModel);
                        this.dgvTodayOrder = dataGridViewHelper.FillData(this.dgvTodayOrder, dataTable);                       
                        this.dgvTodayOrder.Tag = true;
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
        #region 商品展示信息

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
            string sortId = "0";
            string unitId = "0";
            txtGoodsNameSearch.Text = goodsSearch.dic.TryGetValue("GoodsName", out goodsName) ? goodsName : "";
            unitId = goodsSearch.dic.TryGetValue("UnitId", out unitId) ? unitId : "0";
            sortId = goodsSearch.dic.TryGetValue("SortId", out sortId) ? sortId : "0";
            cbxUnitInfo.SelectedValue = Convert.ToInt32(unitId);
            cbxSortsInfo.SelectedValue = Convert.ToInt32(sortId);

        }
        /// <summary>
        /// 搜索商品信息
        /// </summary>
        /// <param name="startIndex"></param>

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
                if (goodsName != "")
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
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoodsSearch_Click(object sender, EventArgs e)
        {
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
            Frm_OrderInfoDIalog frm_Samll = Frm_OrderInfoDIalog.Create();
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
        #region 今日订单展示

        /// <summary>
        /// 初始化今日订单表
        /// </summary>
        /// <param name="todayOrderSearch"></param>
        public void LoadTodayOrderInfo(SearchModel todayOrderSearch)
        {
            string format = "HH:mm:ss";
            dateTodayOrderStartTime.Format = DateTimePickerFormat.Custom;
            dateTodayOrderEndTime.Format = DateTimePickerFormat.Custom;
            dateTodayOrderStartTime.CustomFormat = format;
            dateTodayOrderEndTime.CustomFormat = format;
            DateTime today = DateTime.Today;
            //如果搜索添加中含有 时间 则设置,否则 设置开始时间为今天0.00,终止数据为24.00 
            dateTodayOrderStartTime.Value = todayOrderSearch.StartTime.Equals(new DateTime()) ? today : todayOrderSearch.StartTime;
            DateTime todayEnd = DateTime.Today + new TimeSpan(23, 59, 59);
            dateTodayOrderEndTime.Value = todayOrderSearch.EndTime.Equals(new DateTime()) ? todayEnd : todayOrderSearch.EndTime;
            string todaySearchMixMoney = "";
            string todaySearchMaxMoney = "";
            string todaySearchGoodsName = "";
            txtTodaySearchMixMoney.Text = todayOrderSearch.dic.TryGetValue("TodaySearchMixMoney", out todaySearchMixMoney) ? todaySearchMixMoney : "";
            txtTodaySearchMaxMoney.Text = todayOrderSearch.dic.TryGetValue("TodaySearchMaxMoney", out todaySearchMaxMoney) ? todaySearchMaxMoney : "";
            if (todaySearchMixMoney == "0")
            {
                txtTodaySearchMixMoney.Text = "";
            }
            if (todaySearchMaxMoney == decimal.MaxValue.ToString())
            {
                txtTodaySearchMaxMoney.Text = "";
            }

            txtTodayOrder_SearchName.Text = todayOrderSearch.dic.TryGetValue("TodaySearchGoodsName", out todaySearchGoodsName) ? todaySearchGoodsName : "";



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
            searchModel.count = 30;
            searchModel.startIndex = startIndex;//开始行
            searchModel.dic = new Dictionary<string, string>();

            //搜索
            if (startIndex == 0)
            {
                var StartTime = dateTodayOrderStartTime.Value;
                var EndTime = dateTodayOrderEndTime.Value;
                decimal mixMoney = 0;
                decimal maxMoney = decimal.MaxValue;
                var mixMoneyString = txtTodaySearchMixMoney.Text.Trim();
                var maxMoneyString = txtTodaySearchMaxMoney.Text.Trim();
                var isTrue = Common.CommonHelper.GetTrueSearchMoney(mixMoneyString, maxMoneyString, out mixMoney, out maxMoney);//用户输入价钱是区间是否合格               
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

            }
            //下一页或者上一页
            //利用Tag属性 ,标记是否需要再次更新数据
            this.dgvTodayOrder.Tag = false;//false 表示需要更新
            GetDgv(1, searchModel);
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
            cbxIsReceiveMoney.SelectedValue = noReceiveMoneySearch.dic.TryGetValue("NoReceiveMoney_SelectValue", out selectVlaue) ? selectVlaue : "0";
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
           
        }



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
