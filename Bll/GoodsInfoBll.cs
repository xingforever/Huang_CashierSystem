using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class GoodsInfoBll:BaseBll<GoodsInfo>
    {
        GoodsInfoDal dal = new GoodsInfoDal();
        public  GoodsInfoBll()
        {
            this.CurrentDal = new GoodsInfoDal();
        }
        public DataTable GetDataTablebyPammer( SearchModel searchModel )
        {
           
            return dal.GetDataTablebyPammer(searchModel.startIndex, searchModel.count, searchModel.dic);
        }
        public bool EditGoodsInfoCount(int  id, double  salescount, double  surplusCount)
        {
            return dal.EditGoodsInfoCount(id, salescount, surplusCount);
        }

    }
}
