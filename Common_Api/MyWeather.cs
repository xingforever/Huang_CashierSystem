using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common_API
{
   public   class MyWeather
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Provice { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 今日时间
        /// </summary>
        public  string TodayTime { get; set;  }
        /// <summary>
        /// 今日温度
        /// </summary>
        public  string TodayTemperature { get; set; }
        /// <summary>
        /// 今日风力
        /// </summary>
        public string TodayWind { get; set; }
        /// <summary>
        /// 今日温度概述
        /// </summary>
        public string TodayWeatherSummary { get; set; }
        /// <summary>
        /// 今日温度详情
        /// </summary>
        public string TodayWeatherDetial { get; set; }
        /// <summary>
        /// 明日风力
        /// </summary>
        public string TomorrowWind { get; set;  }
        /// <summary>
        /// 明日天气概况
        /// </summary>
        public  string TomorrowWeatherSummary { get; set;  }
        /// <summary>
        /// 明天气温
        /// </summary>
        public  string TomorrowTemperature { get; set; }

        public MyWeather()
        {

        }

        public  MyWeather(string[] weatherInfo)
        {
            if (weatherInfo.Length==23||weatherInfo[8]!="")
            {
                this.Provice = weatherInfo[0];
                this.City = weatherInfo[1];
                this.TodayTime = weatherInfo[4];
                this.TodayTemperature = weatherInfo[5];
                this.TodayWeatherSummary = weatherInfo[6];
                this.TodayWind = weatherInfo[7];
                this.TodayWeatherDetial = weatherInfo[10];
                this.TomorrowTemperature = weatherInfo[12];
                this.TomorrowWeatherSummary = weatherInfo[13];
                this.TomorrowWind = weatherInfo[14];
            }
        }


    }
}
