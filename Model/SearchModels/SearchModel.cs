using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
     public class SearchModel
    {
        //表名
        public string ModelName { get; set; }
        //起始id
        public  int startIndex { get; set; }
        //个数
        public   int count { get; set; }
        //条件列表
        public Dictionary<string, string> dic { get; set; }

      public   SearchModel()
        {
            ModelName = "";
            startIndex = 0;
            count = 10;
            dic = new Dictionary<string, string>();
        }
    }
}
