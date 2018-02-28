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
        ProfitsInfoDal profitsInfoDal = new ProfitsInfoDal();

       public   ProfitsInfoBll()
        {
            this.CurrentDal = new  ProfitsInfoDal();
        }
       

        public DataTable GetDataTablebyPammer( SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            return profitsInfoDal.GetDataTablebyPammer(searchModel);
        }
        public int GetDataTableCountByPammer(SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            searchModel.PageCount = int.MaxValue;
            var table = profitsInfoDal.GetDataTablebyPammer(searchModel);
            if (table==null||table.Rows.Count==0)
            {
                return 0;
            }
            return table.Rows.Count;


        }

        public List<ProfitsInfo> GetListByPammer(SearchModel searchModel)
        {
            return profitsInfoDal.GetListByPammer(searchModel);
        }

        public ProfitsInfo GetProfitsInfoByOrderId(string  orderId)
        {
            return new ProfitsInfoDal().GetProfitsInfoByOrderId(orderId);
        }

    }
}
