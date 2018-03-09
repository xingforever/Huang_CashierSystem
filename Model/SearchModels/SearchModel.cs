using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SearchModel
    {
        /// <summary>
        /// 表名(没什么用 ,用于区别)
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 查询起始ID
        /// </summary>      
        public int StartIndex { get; set; }       
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 查询终止时间
        /// </summary>
        public DateTime EndTime { get; set; }
        //条件列表
        public Dictionary<string, string> dic { get; set; }      
        /// <summary>
        /// 分页起始ID
        /// </summary>
        public List<int> PageStartIndex { get; set; }

        public SearchModel()
        {
            ModelName = "";
            StartIndex = 0;
            PageCount = 20;
            StartTime = new DateTime();//0001/1/1 0:00:00
            EndTime = new DateTime();
            dic = new Dictionary<string, string>();          
            PageStartIndex = new List<int>();
            PageStartIndex.Add(-1);//默认第一位是-1

        }

        public SearchModel(SearchModel searchModel)
        {
            this.ModelName = searchModel.ModelName;
            this.StartIndex = searchModel.StartIndex;
            this.PageCount = searchModel.PageCount;
            this.StartTime = searchModel.StartTime;
            this.EndTime = searchModel.EndTime;
            this.dic = searchModel.dic;
           
            this.PageStartIndex = new List<int>();
            for (int i = 0; i < searchModel.PageStartIndex.Count; i++)
            {
                this.PageStartIndex.Add(searchModel.PageStartIndex[i]);
            }

        }
    }
}
