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

        public int lastIndex { get; set; }
        public int nextIndex { get; set; }
        //个数
        public   int count { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public  bool IsAsc { get; set; }

        public  DateTime StartTime { get; set;  }

        public  DateTime EndTime { get; set;  }
        //条件列表
        public Dictionary<string, string> dic { get; set; }

      public   SearchModel()
        {
            ModelName = "";
            startIndex = 0;
            lastIndex = startIndex;
            nextIndex = 3;
            count = 3;
            IsAsc = true;
            StartTime =new DateTime ();//0001/1/1 0:00:00
            EndTime = new DateTime();
            dic = new Dictionary<string, string>();
        }
    }
}
