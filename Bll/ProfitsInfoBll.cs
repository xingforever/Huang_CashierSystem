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
       

        public DataTable GetDataTablebyPammer( SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            return new ProfitsInfoDal().GetDataTablebyPammer(searchModel.startIndex,searchModel.count,searchModel.IsAsc,searchModel.StartTime,searchModel.EndTime,searchModel.dic);
        }

        public ProfitsInfo GetProfitsInfoByOrderId(int orderId)
        {
            return new ProfitsInfoDal().GetProfitsInfoByOrderId(orderId);
        }

    }
}
