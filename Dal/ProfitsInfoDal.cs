using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
   public  class ProfitsInfoDal:BaseDal<ProfitsInfo>
    {

        public  DataTable GetTodayDataTable()
        {
            //时间>='2011-8-1 00:00:00' and 时间<='2011-8-10 23:59:59'
            DateTime DateTime = DateTime.Now.Date;
            DateTime dateTime2 = DateTime + new TimeSpan(24, 0, 0,0);
            try
            {
                string sql = "Select * from [ProfitsInfo] Where [DelFlag]=False And [CreateTime]>='" + DateTime+ "' And [CreateTime] <='"+ dateTime2+"'";
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
