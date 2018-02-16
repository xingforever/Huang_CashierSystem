using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public class NoReceiveMoneyDal : BaseDal<NoReceiveMoney>
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
        public DataTable GetDataTablebyPammer(int startIndex = 0, int count = 30, bool idAsc = true, DateTime startTime = new DateTime(), DateTime endTime = new DateTime(), Dictionary<string, string> dic = null)
        {
            DateTime dateTime = DateTime.Today;
            string timeStart = (dateTime - new TimeSpan(7, 0, 0, 0, 0)).ToString("yyyy-MM-dd 00:00:00");
            string timeEnd = dateTime.ToString("yyyy-MM-dd 00:00:00");
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
                var flagString = ">=";
                var paiXu = "asc";
                if (!idAsc)
                {
                    flagString = "<=";
                    paiXu = "desc";
                }
                string sql = @"Select *," +
                   "from [NoReceiveMoney] Where [DelFlag]=False And [CreateTime]>=#" + timeStart + "# And [CreateTime] <=#" + timeEnd + "#"
                     + " And  [ID]" + flagString + startIndex;

                string customerName = "";
                if (dic.TryGetValue("NoReceiveMoney_Name", out customerName))
                {
                    sql += @" and " + "[CustomerName]" + " like '%" + customerName + "%'";

                }
                sql += "   Order by [id] " + paiXu;
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
