using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class OrderInfoBll:BaseBll<OrderInfo>
    {
        OrderInfoDal dal = new OrderInfoDal();
        public OrderInfoBll()
        {
            this.CurrentDal = new OrderInfoDal();
        }
        public DataTable GetDataTablebyPammer(SearchModel searchModel)
        {

            return dal.GetDataTablebyPammer(searchModel.startIndex, searchModel.count, searchModel.dic);
        }

        public DataTable GetTodayDataTable(SearchModel searchModel)
        {            
            return dal.GetTodayDataTable(searchModel.StartTime,searchModel.EndTime,searchModel.dic);
        }
    }
}
