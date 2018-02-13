using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public  class OrderInfoDal:BaseDal<OrderInfo>
    {
        public DataTable GetDataTablebyPammer(int startIndex, int count, Dictionary<string, string> dic = null)
        {
            //查询goodsinfo ,并查询出商品类型和单位
            //标准可执行
            //select  top 10
            //goods.*,sort.SortName as SortName ,unit.UnitName as unitName,wsoles.SupName
            //   from((GoodsInfo as goods
            //    inner join SortInfo as sort
            //    on goods.SortId = sort.Id)
            //    inner join UnitInfo as unit
            //    on goods.UnitId = unit.Id)
            //    inner join WholeSalerInfo as wsoles
            //    on goods.WholeSalerId = wsoles.Id
            //    where goods.DelFlag = false and goods.id > 2
            //   order by goods.id desc


            string sql1 = "select top " + count.ToString();//筛选一定量数据
            string sql2 = @" OrderInfo.Id,OrderInfo.OrderId,goods.GoodsName as GoodsName,OrderInfo.Count,OrderInfo.DisCount,
                     OrderInfo.PayPrice,OrderInfo.CreateTime,OrderInfo.Remark
                     from OrderInfo 
                     inner join GoodsInfo as goods
                    on OrderInfo.GoodsId=goods.Id
                    where OrderInfo.DelFlag= false and OrderInfo.id >" + startIndex.ToString();
            string sql3 = " order by OrderInfo.id ";
            string sql = sql1 + sql2;//排序
            //限制条件
            if (dic != null)
            {

                foreach (var pair in dic)
                {
                    string goodsName = "";
                    if (dic.TryGetValue("GoodsName", out goodsName))
                    {
                        sql += @" and goods." + pair.Key + " like '%" + pair.Value + "%'";
                        continue;
                    }
                    sql += " and OrderInfo." + pair.Key + " like " + pair.Value;

                }
            }
            sql += sql3;

            var dataTable = SqlHelper.GetDataTable(sql);
            return dataTable;

        }

        /// <summary>
        /// 获取今日销售单
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayDataTable(DateTime startTime=new DateTime(),DateTime endTime = new DateTime(), Dictionary<string, string> dic = null)
        {

            //时间>='2011-8-1 00:00:00' and 时间<='2011-8-10 23:59:59'
            DateTime DateTime = DateTime.Now.Date;
            string  TodayTimeStart=    DateTime.ToString("yyyy-MM-dd 00:00:00");
            DateTime dateTime2 = DateTime + new TimeSpan(1, 0, 0, 0);
            string TodayTimeEnd= dateTime2.ToString("yyyy-MM-dd 00:00:00");
            //操作员选择时间端
            if (!startTime.Equals(new DateTime()))
            {
                TodayTimeStart = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (!endTime.Equals(new DateTime()))
            {
                TodayTimeEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            try
                {
                    string sql = @"select top 30
                    OrderInfo.Id,OrderInfo.OrderId,goods.GoodsName as GoodsName,OrderInfo.Count,OrderInfo.DisCount,
                     OrderInfo.PayPrice,OrderInfo.CreateTime,OrderInfo.Remark
                     from OrderInfo
                     inner join GoodsInfo as goods
                    on OrderInfo.GoodsId = goods.Id Where OrderInfo.DelFlag=False And goods.DelFlag=False   And OrderInfo.CreateTime>=#" + TodayTimeStart + "# And  OrderInfo.CreateTime <=#" + TodayTimeEnd + "#" ;
                ///商品名删选 
                if (dic !=null)
                {
                    string goodsName = "";
                    if (dic.TryGetValue("TodaySearchGoodsName", out goodsName))
                    {
                        sql += @" and goods." + "GoodsName" + " like '%" + goodsName + "%'";

                    }
                    //价格筛选
                    decimal mixMoney = 0;
                    decimal maxMoney = decimal.MaxValue;
                    string mixMoneyString = mixMoney.ToString();
                    string maxMoneyString = maxMoney.ToString();
                    if (dic.TryGetValue("TodaySearchMixMoney", out mixMoneyString))
                    {
                        mixMoney = Convert.ToDecimal(mixMoneyString);
                        sql += " and  OrderInfo.PayPrice  >" + mixMoney;
                    }
                    if (dic.TryGetValue("TodaySearchMaxMoney", out maxMoneyString))
                    {
                        maxMoney = Convert.ToDecimal(maxMoneyString);
                        sql += " and  OrderInfo.PayPrice  <" + maxMoney;

                    }
                }
               
                var dataTable = SqlHelper.GetDataTable(sql);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    var e = ex.Message; ;
                    return null;
                }
            
        }
    }
}
