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

        public  string ModelName { get; set; }
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

        
    }
}
