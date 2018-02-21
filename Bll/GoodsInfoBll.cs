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
           
            return dal.GetDataTablebyPammer(searchModel);
        }
        /// <summary>
        /// 获取符合条件的行数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public int  GetDataTableCountByPammer(SearchModel searchModel)
        {
            searchModel.startIndex = 0;
            searchModel.count = int.MaxValue;
            return dal.GetDataTablebyPammer(searchModel).Rows.Count;
        }


        public bool EditGoodsInfoCount(int  id, double  salescount, double  surplusCount)
        {
            return dal.EditGoodsInfoCount(id, salescount, surplusCount);
        }

    }
}
