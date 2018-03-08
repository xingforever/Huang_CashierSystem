using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
  public   class GoodHelperDal
    {
        SortInfoDal sortInfoDal = new SortInfoDal();
        UnitInfoDal unitInfoDal = new UnitInfoDal();
        WholeSalerInfoDal wholeSalerInfoDal = new WholeSalerInfoDal();
        /// <summary>
        /// GoodsInfoHelper 转换为 GoodsInfo
        /// </summary>
        /// <param name="goodsInfoHelper"></param>
        /// <returns></returns>
        public GoodsInfo GetGoodsInfo(GoodsInfoHelper goodsInfoHelper)
        {
            GoodsInfo goodsInfo = new GoodsInfo();
            var sort = goodsInfoHelper.SortName;
            var unit = goodsInfoHelper.UnitName;
            var wholeSalerName = goodsInfoHelper.WholeSalerName;
            //将Sort 转换为SortID  
            //在sort表中查询是否有该数据,有则返回ID  无则添加该类型 后返回ID
            int sortId = sortInfoDal.GetSortIdByName(sort);
            if (sortId==int.MaxValue)
            {
                //添加该类型
                SortInfo sortInfo = new SortInfo();
                sortInfo.SortName = sort;
                sortInfo.DelFlag = false;
               sortId= sortInfoDal.GetIdByAdd(sortInfo);
            }
            int unitId = unitInfoDal.GetUnitIdByName(unit);
            if (unitId == int.MaxValue)
            {
                //添加该类型
                UnitInfo unitInfo = new UnitInfo();
                unitInfo.UnitName = unit;
                unitInfo.DelFlag = false;
                sortId = unitInfoDal.GetIdByAdd(unitInfo);
            }
            int wholesalerId = wholeSalerInfoDal.GetWholeSaleIdByName(wholeSalerName);
            if (wholesalerId==int.MaxValue)
            {
                WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
                wholeSalerInfo.SupName = wholeSalerName;
                wholeSalerInfo.Management = "未知";
                wholeSalerInfo.AddressInfo = "未知";
                wholeSalerInfo.TelePhone = "未知";
                wholeSalerInfo.AddressInfo = "未知";
                wholeSalerInfo.DelFlag = false;
                wholesalerId = wholeSalerInfoDal.GetIdByAdd(wholeSalerInfo);
            }
            goodsInfo.GoodsName = goodsInfoHelper.GoodsName;
            goodsInfo.GoodsType = goodsInfoHelper.GoodsType;
            goodsInfo.CreateTime = DateTime.Now;
            goodsInfo.LastTime = goodsInfoHelper.LastTime;
            goodsInfo.PayPrice = goodsInfoHelper.PayPrice;
            goodsInfo.PurPrice = goodsInfoHelper.PurPrice;
            goodsInfo.Remark = goodsInfoHelper.Remark;
            goodsInfo.SalesCount = goodsInfoHelper.SalesCount;          
            goodsInfo.SurplusCount = goodsInfoHelper.SurplusCount;
            goodsInfo.Total = goodsInfoHelper.Total;
            goodsInfo.UnitId = unitId;
            goodsInfo.SortId = sortId;
            goodsInfo.WholeSalerId = wholesalerId;
            return goodsInfo;
            
        }
        /// <summary>
        /// GoodsInfoHelper列表 转换为GoodsInfo列表
        /// </summary>
        /// <param name="goodInfoHelpers"></param>
        /// <returns></returns>
        public List<GoodsInfo> GetGoodsInfoList(List<GoodsInfoHelper>goodInfoHelpers)
        {
            List<GoodsInfo> GoodInfoList = new List<GoodsInfo>();
            for (int i = 0; i < goodInfoHelpers.Count; i++)
            {
                GoodsInfo goodsInfo = GetGoodsInfo(goodInfoHelpers[i]);
                GoodInfoList.Add(goodsInfo);
            }
            return GoodInfoList;
        }
        /// <summary>
        /// dataTable 转换为GoodInfoHelper
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<GoodsInfoHelper> GetGoodsInfoHelperByTable(DataTable dataTable ,out List<string> errorMessage)
        {
             errorMessage = new List<string>();
            if (dataTable.Rows.Count <= 1 || dataTable.Columns.Count != 12)
            {
                errorMessage.Add("读取失败,请检查文件(文件格式必须为标准表格式)");
                return null;
            }
            List<GoodsInfoHelper> GoodInfoHelperList = new List<GoodsInfoHelper>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[i];
                GoodsInfoHelper goodsInfoHelper;
                try
                {
                    goodsInfoHelper = GetGoodsInfoHelperByDataRow(dr);
                    if (goodsInfoHelper == null)
                    {
                        string error = "在表中第 " + i + "信息添加失败";
                        //错误信息添加
                        errorMessage.Add(error);
                    }
                    else
                    {
                        GoodInfoHelperList.Add(goodsInfoHelper);
                    }
                }
                catch
                {
                    continue;
                }
            }
            if (GoodInfoHelperList.Count == 0)
            {
                return null;
            }
            else
            {
                return GoodInfoHelperList;
            }
        }
        /// <summary>
        /// 将dataTable的一行转换为GoodsInfoHelper
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public GoodsInfoHelper GetGoodsInfoHelperByDataRow(DataRow dataRow)
        {
            GoodsInfoHelper goodsInfoHelper = new GoodsInfoHelper();
            try
            {
                goodsInfoHelper.GoodsName =dataRow[0].ToString();
                goodsInfoHelper.SortName = dataRow[1].ToString();
                goodsInfoHelper.UnitName = dataRow[2].ToString();
                goodsInfoHelper.GoodsType = dataRow[3].ToString();
                goodsInfoHelper.Total = Convert.ToDouble(dataRow[4].ToString());
                goodsInfoHelper.SalesCount = Convert.ToDouble(dataRow[5].ToString());
                goodsInfoHelper.SurplusCount = Convert.ToDouble(dataRow[6].ToString());
                goodsInfoHelper.PurPrice=Convert.ToDecimal(dataRow[7].ToString());
                goodsInfoHelper.PayPrice = Convert.ToDecimal(dataRow[8].ToString());
                goodsInfoHelper.CreateTime = DateTime.Now;
                if (dataRow[9].ToString()=="")
                {
                    goodsInfoHelper.WholeSalerName = "未知";
                }
                else
                {
                    goodsInfoHelper.WholeSalerName = dataRow[9].ToString();
                }               
                if (dataRow[10].ToString()!="")
                {
                    goodsInfoHelper.LastTime = Convert.ToDateTime(dataRow[10].ToString());
                }
                
            
                goodsInfoHelper.Remark = dataRow[11].ToString();
                return goodsInfoHelper;
              }
            catch 
            {
                //该行有数据出错
                return null;
            }


        }

        /// <summary>
        /// 将商品信息转换为符合数据表的DataTable
        /// </summary>
        /// <param name="goodInfosList"></param>
        /// <returns></returns>
        public DataTable GetDataTableByGoodsInfoList(List<GoodsInfo> goodInfosList)
        {
            DataTable dataTable = new DataTable();
           
            {
                dataTable.Columns.Add("GoodsName");
                dataTable.Columns.Add("SortId");
                dataTable.Columns.Add("UnitId");
                dataTable.Columns.Add("GoodsType");
                dataTable.Columns.Add("PurPrice");
                dataTable.Columns.Add("PayPrice");
                dataTable.Columns.Add("Total");
                dataTable.Columns.Add("SalesCount");
                dataTable.Columns.Add("SurplusCount");
                dataTable.Columns.Add("WholeSalerId");
                dataTable.Columns.Add("CreateTime");
                dataTable.Columns.Add("LastTime");
                dataTable.Columns.Add("Remark");
                dataTable.Columns.Add("DelFlag");
             
            }
            
            for (int i = 0; i < goodInfosList.Count; i++)
            {
                var goodinfo = goodInfosList[i];
                dataTable.Rows.Add();
                dataTable.Rows[i][0] = goodinfo.GoodsName;
                dataTable.Rows[i][1] = goodinfo.SortId;
                dataTable.Rows[i][2] = goodinfo.UnitId;
                dataTable.Rows[i][3] = goodinfo.GoodsType;
                dataTable.Rows[i][4] = goodinfo.PurPrice;
                dataTable.Rows[i][5] = goodinfo.PayPrice;
                dataTable.Rows[i][6] = goodinfo.Total;
                dataTable.Rows[i][7] = goodinfo.SalesCount;
                dataTable.Rows[i][8] = goodinfo.SurplusCount;
                dataTable.Rows[i][9] = goodinfo.WholeSalerId;
                dataTable.Rows[i][10] = goodinfo.CreateTime;
                dataTable.Rows[i][11] = goodinfo.LastTime;
                dataTable.Rows[i][12] = goodinfo.Remark;
                dataTable.Rows[i][13] = goodinfo.DelFlag;
                var dd = dataTable.Rows[i];
                var dfdf = dataTable.Rows[i][0];
            }
            return dataTable;
        }
        /// <summary>
        /// 快速插入商品信息表
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public bool  InsertData(DataTable dataTable ,out string error)
        {
            string tableName = "GoodsInfo";
             error = "";
            return  SqlHelper.ExcuteTableSql(tableName, dataTable, out error);
            
        }
        public bool InsertData2(List<GoodsInfo >goodInfoList, out List<string> error)
        {
            string tableName = "GoodsInfo";
            error = new List<string>();
            return SqlHelper.ExcuteTableSql2(tableName, goodInfoList, out error);



        }


    }
}
