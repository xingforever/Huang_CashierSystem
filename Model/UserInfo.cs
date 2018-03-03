using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
  public   class UserInfo:BaseModel
    {
     
        /// <summary>
        /// 用户名
        /// </summary>
           
        public  string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public  string PassWord { get; set; }

        public UserInfo()
        {
           
        }

        public override string GetModelName()
        {
            return "UserInfo";
        }

        /// <summary>
        /// 获取表格值名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "UserName", "PassWord", "Remark", "DelFlag" }; ;
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "用户名", "密码", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {
            return new List<int>() { 0, 2, 4 };
        }

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
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserInfo userInfo = new UserInfo();
                dr = dataTable.Rows[i];
                userInfo.Id = Convert.ToInt32(dr["ID"]);
                userInfo.UserName = Convert.ToString(dr["UserName"]);
                userInfo.Remark = Convert.ToString(dr["Remark"]);
                userInfo.PassWord=Convert.ToString(dr["PassWord"]);
                Entitys.Add(userInfo);
            }
            
            return Entitys;
        }

    }
}
