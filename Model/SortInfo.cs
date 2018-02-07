using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    public class SortInfo : BaseModel
    {
        public string SortName { get; set; }

   

       public  SortInfo(){
            ModelName = "SortInfo";
        }

        public override string GetSql()
        {
            return "([SortName],[Remark],[DelFlag]) ";
        }

        public override string GetAddSql()
        {
            string sql = " Values ('" + this.SortName + "','"  + this.Remark + "'," + this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set [SortName]='" + this.SortName + "',[Remark]='" + this.Remark + "'" + "  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
            SortInfo sortInfo = new SortInfo();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                sortInfo.Id = Convert.ToInt32(dr["ID"]);
                sortInfo.SortName = Convert.ToString(dr["SortName"]);
                sortInfo.Remark = Convert.ToString(dr["Remark"]);
             
                Entitys.Add(sortInfo);
            }

            return Entitys;
        }

    }
}
