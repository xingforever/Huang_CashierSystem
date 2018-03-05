using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public   class GoodsInfoHelperBll
    {
        public  GoodHelperDal goodHelperDal { get; set; }


       public  GoodsInfoHelperBll()
        {
            goodHelperDal = new GoodHelperDal();
        }

        public List<GoodsInfo> GetGoodsInfoList(List<GoodsInfoHelper> goodInfoHelpers)
        {
            return goodHelperDal.GetGoodsInfoList(goodInfoHelpers);

        }

        public List<GoodsInfoHelper> GetGoodsInfoHelperByTable(DataTable dataTable, out List<string> errorMessage)
        {

            return goodHelperDal.GetGoodsInfoHelperByTable(dataTable, out  errorMessage);
        }

        public DataTable GetDataTableByGoodsInfoList(List<GoodsInfo> goodInfosList)
        {
            return goodHelperDal.GetDataTableByGoodsInfoList(goodInfosList);
        }

        public bool InsertData(DataTable dataTable,out string error)
        {
            return goodHelperDal.InsertData(dataTable ,out error);
        }
    }
}
