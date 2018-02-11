using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public  class GoodsInfoDal:BaseDal<GoodsInfo>
    {


        //string sql = @"select di.*,dti.dtitle as dTypeTitle 
        //        from dishinfo as di
        //        inner join dishtypeinfo as dti
        //        on di.dtypeid=dti.did
        //        where di.dIsDelete=0 and dti.dIsDelete=0";
        /// <summary>
        /// 获取条件查询后的商品信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable GetDataTablebyPammer(int startIndex, int count,Dictionary<string, string> dic=null )
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
            string sql2 = @"  goods.Id,goods.GoodsName,sort.SortName as SortName ,unit.UnitName as UnitName,goods.GoodsType,goods.PayPrice ,goods.SurplusCount, wsoles.SupName as WholeSalerName,goods.Remark
               from ((GoodsInfo as goods
                inner join SortInfo as sort
                on goods.SortId=sort.Id)
                inner join UnitInfo as unit
                on goods.UnitId=unit.Id)
                inner join WholeSalerInfo as wsoles
                on goods.WholeSalerId=wsoles.Id
                where goods.DelFlag= false and goods.id >" + startIndex.ToString();
            string sql3 = " order by goods.id ";
            string sql = sql1 + sql2;//排序
            //限制条件
            if (dic!=null)
            {
                
                foreach (var pair in dic)
                {
                    string goodsName = "";
                    if (dic.TryGetValue("GoodsName", out goodsName))
                    {
                        sql += @" and goods." + pair.Key + " like '%" + pair.Value+"%'";
                        continue;
                    }
                    sql += " and goods." + pair.Key + " like " + pair.Value;
                   
                }
            }
            sql += sql3;
            
            var dataTable = SqlHelper.GetDataTable(sql);
            return dataTable;
          
        }

       /// <summary>
       /// 修改商品数量
       /// </summary>
       /// <param name="id">商品ID</param>
       /// <param name="Salescount">售卖量</param>
       /// <param name="SurplusCount">库存</param>
       /// <returns></returns>
        public bool EditGoodsInfoCount(int id,double  salescount, double surplusCount)
        {
            string sql = "Update [GoodsInfo] Set [SalesCount]='" + salescount + "',[SurplusCount]='" + surplusCount
                 + "' Where [ID]= " + id + " and DelFlag=False ";
            var affect= SqlHelper.ExecuteNonQuery(sql);

            return affect > 0 ;
        }
        public List<GoodsInfo> GetGoodsInfoList(DataTable dataTable)
        {
            DataRow dr = null;
            List<GoodsInfo> Entitys = new List<GoodsInfo>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                GoodsInfo goodsInfo = new GoodsInfo();
                dr = dataTable.Rows[i];
                goodsInfo.Id = Convert.ToInt32(dr["ID"]);
                goodsInfo.UnitId = Convert.ToInt32(dr["UnitId"]);
                goodsInfo.SortId = Convert.ToInt32(dr["SortId"]);
                goodsInfo.WholeSalerId = Convert.ToInt32(dr["WholeSalerId"]);
                goodsInfo.GoodsType = Convert.ToString(dr["GoodsType"]);
                goodsInfo.PurPrice = Convert.ToDecimal(dr["PurPrice"]);
                goodsInfo.PayPrice = Convert.ToDecimal(dr["PayPrice"]);
                goodsInfo.Total = Convert.ToDouble(dr["Total"]);
                goodsInfo.SalesCount = Convert.ToDouble(dr["SalesCount"]);
                goodsInfo.SurplusCount = Convert.ToDouble(dr["SurplusCount"]);
                goodsInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                goodsInfo.LastTime = Convert.ToDateTime(dr["LastTime"]);
                goodsInfo.Remark = Convert.ToString(dr["Remark"]);
                UnitInfo unitInfo = new UnitInfoDal().GetEntityById(goodsInfo.UnitId);
                SortInfo sortInfo = new SortInfoDal().GetEntityById(goodsInfo.SortId);
                WholeSalerInfo wholeSalerInfo = new WholeSalerInfoDal().GetEntityById(goodsInfo.WholeSalerId);
                goodsInfo.UnitInfo = unitInfo;
                goodsInfo.SortInfo = sortInfo;
                goodsInfo.WholeSalerInfo = wholeSalerInfo;
                Entitys.Add(goodsInfo);
            }
            return Entitys;

        }
       

    }
}
