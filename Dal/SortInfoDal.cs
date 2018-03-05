using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Dal
{
   public   class SortInfoDal : BaseDal<SortInfo>
    {

      public SortInfoDal()
        {

        }

        public int GetSortIdByName(string sortName)
        {
            string sql = "Select Id from  SortInfo where [SortName]= '" + sortName+"'";
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
