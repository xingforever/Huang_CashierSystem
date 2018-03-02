using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{
   public  class Setting
    {
        public  static string City { get; set;  }
        public static string ProgramName { get; set; }
        public static int GoodsInfoPageCount { get; set; }
        public static int GoodsManagerPageCount { get; set; }
        public static int AllOrderPageCount { get; set; }
        public  static int ProfitPageCount { get; set; }
        public static int NoReceivePageCount { get; set; }

        public  static Setting GetSeeting()
        {
            Setting setting = new Setting();
            var dic = Common.XMLHelper.ReadXML();
            if (dic==null)
            {
                return setting;
            }
            else
            {
                try
                {
                    List<string> keys = new List<string>();
                    foreach (var item in dic.Keys)
                    {
                        keys.Add(item);
                    }
                    
                    Setting.ProgramName = dic[keys[0]];
                    Setting.GoodsInfoPageCount = int.Parse(dic[keys[1]]);
                    Setting.GoodsManagerPageCount = int.Parse(dic[keys[2]]);
                    Setting.AllOrderPageCount = int.Parse(dic[keys[3]]);
                    Setting.ProfitPageCount = int.Parse(dic[keys[4]]);
                    Setting.NoReceivePageCount = int.Parse(dic[keys[5]]);
                }
                catch 
                {
                    
                }
               
            }
            return setting;
        }

        public  Setting()
        {
            ProgramName = "收银系统";
            GoodsInfoPageCount = 30;           
            GoodsManagerPageCount = 30;
            AllOrderPageCount = 30;
            ProfitPageCount = 20;
            NoReceivePageCount = 20;
        }


        public  List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "设置项目", "设置值"}; 
        }
        /// <summary>
        /// 获取显示标题名称
        /// </summary>
        /// <returns></returns>
        public  List<string> GetHanderTxt()
        {
            return new List<string> { "设置项目", "设置值" };
        }
    }
}
