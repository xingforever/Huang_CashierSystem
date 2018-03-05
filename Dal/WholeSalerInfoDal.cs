using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
   public  class WholeSalerInfoDal:BaseDal<WholeSalerInfo>
    {

        public int GetWholeSaleIdByName(string supName)
        {
            string sql = "Select Id from WholeSalerInfo  where [SupName]= '" + supName+"'";
            var dataTable = SqlHelper.GetDataTable(sql);
            if (dataTable.Rows.Count == 1)
            {
                var dr = dataTable.Rows[0];
                int id = Convert.ToInt32(dr["ID"]);
                return id;
            }
            return int.MaxValue;
        }
    }
}
