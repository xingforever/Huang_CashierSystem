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
        public  int StartIndex { get; set; }     
        //个数
        public  int PageCount { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public  bool IsAsc { get; set; }

        public  DateTime StartTime { get; set;  }

        public  DateTime EndTime { get; set;  }
        //条件列表
        public Dictionary<string, string> dic { get; set; }
        /// <summary>
        /// 辅助变量(存储上下页任务)
        /// </summary>
        public int Tag { get; set; }

        public List<int> PageStartIndex { get; set; }

      public   SearchModel()
        {
            ModelName = "";
            StartIndex = 0;          
            PageCount = 3;
            IsAsc = true;
            StartTime =new DateTime ();//0001/1/1 0:00:00
            EndTime = new DateTime();
            dic = new Dictionary<string, string>();
            Tag = -1;
            PageStartIndex = new List<int>();
            PageStartIndex.Add(-1);//默认第一位是-1

        }

        public  SearchModel(SearchModel searchModel)
        {
            this.ModelName = searchModel.ModelName;
            this.StartIndex = searchModel.StartIndex;          
            this.PageCount = searchModel.PageCount;
            this.IsAsc = true;
            this.StartTime = searchModel.StartTime;
            this.EndTime = searchModel.EndTime;
            this.dic = searchModel.dic;
            this.Tag = searchModel.Tag;
            this.PageStartIndex = new List<int>();
            for (int i = 0; i < searchModel.PageStartIndex.Count; i++)
            {
                this.PageStartIndex.Add(searchModel.PageStartIndex[i]);
            }

        }
    }
}
