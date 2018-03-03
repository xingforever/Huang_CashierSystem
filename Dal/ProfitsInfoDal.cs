using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public class ProfitsInfoDal : BaseDal<ProfitsInfo>
    {

        /// <summary>
        /// /筛选符合条件的数据
        /// </summary>
        /// <param name="startIndex">筛选ID起点</param>
        /// <param name="count">数据量</param>
        /// <param name="idAsc">是否顺序排列</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="dic">条件字典</param>
        /// <returns></returns>
        public DataTable GetDataTablebyPammer(SearchModel searchModel)
        {
            var dataTable = new DataTable();
           var  startTime = searchModel.StartTime;
            var endTime = searchModel.EndTime;
            var startIndex = searchModel.StartIndex;
            var dic = searchModel.dic;
            DateTime dateTime = DateTime.Now;
            string timeStart = (dateTime - new TimeSpan(7, 0, 0, 0, 0)).ToString("yyyy-MM-dd 00:00:00");
            string timeEnd = (dateTime+ new TimeSpan(1, 0, 0, 0, 0)).ToString("yyyy-MM-dd 00:00:00");
            //操作员选择时间端
            if (!startTime.Equals(new DateTime()))
            {
                timeStart = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (!endTime.Equals(new DateTime()))
            {
                timeEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            try
            {

                string sql = @"Select  top " + searchModel.PageCount.ToString()+
                   "    *  " +
                   "from [ProfitsInfo] Where [DelFlag]=False And [CreateTime]>=#" + timeStart + "# And [CreateTime] <=#" + timeEnd + "#"
                     + " And  [ID] >="  + startIndex;

                string orderId = "";
                if (dic.TryGetValue("Profits_OrderId", out orderId))
                {
                    sql += @" and ProfitsInfo." + "[OrderId]" + " like '%" + orderId + "%'";

                }
                sql += "  Order by [id] ";
                dataTable = SqlHelper.GetDataTable(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    DataRow dr_first = dataTable.AsEnumerable().First<DataRow>();//获取最后一行
                    var fitstid = Convert.ToInt32(dr_first[0].ToString());//最后一行 ID
                    DataRow dr_last = dataTable.AsEnumerable().Last<DataRow>();//获取最后一行
                    var lastid = Convert.ToInt32(dr_last[0].ToString());//最后一行 ID
                                                                        //表示只有一个-1 ,即本次查询为第一页
                    if (searchModel.PageStartIndex.Count == 1)
                    {
                        searchModel.PageStartIndex.Add(fitstid);//
                    }
                    searchModel.PageStartIndex.Add(lastid + 1);//下一页  
                }

           
            }
            catch (Exception ex)
            {
                var e = ex.Message; ;
              
            }
            return dataTable;
        }


        public ProfitsInfo GetProfitsInfoByOrderId(string  orderId)
        {
            ProfitsInfo entity = new ProfitsInfo();
            string sql = "Select *  from  ProfitsInfo  where [OrderId]='" + orderId + "'";
            var dataTable = SqlHelper.GetDataTable(sql);
            var listEntity = entity.GetList(dataTable);
            if (listEntity.Count == 1)
            {
                return (ProfitsInfo)listEntity[0];
            }
            else
            {
                return null;
            }

        }

        

        public  List<ProfitsInfo> GetListByDataTable(DataTable dataTable)
        {

            DataRow dr = null;
            List<ProfitsInfo> Entitys = new List<ProfitsInfo>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProfitsInfo profitsInfo = new ProfitsInfo();
                dr = dataTable.Rows[i];
                profitsInfo.Id = Convert.ToInt32(dr["ID"]);
                profitsInfo.OrderId = Convert.ToString(dr["OrderId"]);
                profitsInfo.Profit = Convert.ToDecimal(dr["Profit"]);
                profitsInfo.PayPrices = Convert.ToDecimal(dr["PayPrices"]);
                profitsInfo.DisCount = Convert.ToDecimal(dr["DisCount"]);
                profitsInfo.IsPay = Convert.ToBoolean(dr["IsPay"]);
                profitsInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                profitsInfo.Remark = Convert.ToString(dr["Remark"]);
                Entitys.Add(profitsInfo);
            }

            return Entitys;
        }



    }
}
