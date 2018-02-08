using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
  public   class BaseModel
    {
        public  int Id { get; set; }
        public  bool DelFlag { get; set; }      
        public string Remark { get; set; }
     

        public   BaseModel()
        {
             Remark = " ";
             DelFlag = false;
           
        }

        public virtual string GetSql()
        {
            return "";
        }

        public virtual string GetAddSql()
        {
            return "Values()";
        }
        public virtual string GetEditSql()
        {
            return "Set[] where ID=1 ";
        }

        public virtual List<BaseModel> GetList(DataTable dataTable)
        {

            return null;
        }
        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetHanderTxt()
        {

            return new List<string>();
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public virtual List<int > GetHideIndex()
        {

            return null ;
        }

        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <returns></returns>
        public virtual string GetModelName()
        {
            return " ";
        }


    }
}
