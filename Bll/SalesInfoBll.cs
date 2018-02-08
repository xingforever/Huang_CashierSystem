using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class SalesInfoBll:BaseBll<SalesInfo>
    {

       public   SalesInfoBll()
        {
            this.CurrentDal = new  SalesInfoDal();
        }
        /// <summary>
        /// 返回当天的销售
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayDataTable()
        {
            //
            return new SalesInfoDal().GetTodayDataTable();
        }

        public DataTable GetDataTables( SearchModel searchModel)
        {
            searchModel.ModelName = "SalesInfo";
            return new SalesInfoDal().GetDataTable(searchModel);
        }

    }
}
