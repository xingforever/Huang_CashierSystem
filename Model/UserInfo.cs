using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
  public   class UserInfo:BaseModel
    {
       public  UserInfo()
        {
            ModelName = "UserInfo";
            //Remark = " ";
            //DelFlag = false;
        }
        /// <summary>
        /// 用户名
        /// </summary>
           
        public  string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public  string PassWord { get; set; }
    

        public override string GetSql()
        {
            return "([UserName],[PassWord],[Remark],[DelFlag]) ";
        }

        public override string GetAddSql()
        {
              string sql = " Values ('" + this.UserName + "','" + this.PassWord + "','" + this.Remark + "'," + this.DelFlag+")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set [UserName]='" + this.UserName + "', [PassWord]='" + this.PassWord + "',[Remark]='" + this.Remark + "'"  + "  Where [ID]="+this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {            
            DataRow dr = null;
            UserInfo userInfo = new UserInfo();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                userInfo.Id = Convert.ToInt32(dr["ID"]);
                userInfo.UserName = Convert.ToString(dr["UserName"]);
                userInfo.Remark = Convert.ToString(dr["Remark"]);
                Entitys.Add(userInfo);
            }
            
            return Entitys;
        }

    }
}
