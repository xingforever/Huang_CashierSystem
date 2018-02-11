using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class ProfitsInfoBll:BaseBll<ProfitsInfo>
    {

       public   ProfitsInfoBll()
        {
            this.CurrentDal = new  ProfitsInfoDal();
        }
        /// <summary>
        /// 返回当天的销售
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayDataTable()
        {
            //
            return new ProfitsInfoDal().GetTodayDataTable();
        }

        public DataTable GetDataTables( SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            return new ProfitsInfoDal().GetDataTable(searchModel);
        }

    }
}
