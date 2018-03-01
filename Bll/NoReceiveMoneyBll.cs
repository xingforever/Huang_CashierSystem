using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public class NoReceiveMoneyBll:BaseBll<NoReceiveMoney>
    {
        
      public  NoReceiveMoneyBll()
        {
            this.CurrentDal = new NoReceiveMoneyDal();
        }

        public DataTable GetDataTablebyPammer(SearchModel searchModel)
        {
            searchModel.ModelName = "NoReceiveMoney";
            return new NoReceiveMoneyDal().GetDataTablebyPammer(searchModel);
        }
    }
}
