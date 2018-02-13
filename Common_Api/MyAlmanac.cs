using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common_API
{
    public class MyAlmanac
    {

        public string nongli { get; set; }//农历
        public string errMessage { get; set; }
        public string gongli { get; set; }//公历
        public string yi { get; set; }//宜
        public string ji { get; set; }//忌
        public string date { get; set; }//日期
        public bool IsGetSuccess = false;

        public MyAlmanac()
        {

        }



    }
}
