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
                     OrderInfo.Prices,OrderInfo.CreateTime,OrderInfo.Remark
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
    }
}
