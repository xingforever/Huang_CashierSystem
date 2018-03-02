using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common_API
{


   public   class WeatherHelper
    {

       static  WeatherWeb.WeatherWebService weather = new WeatherWeb.WeatherWebService();

        WeatherHelper()
        {
          
        }
        public static string [] GetSupportProvince()
        { 
            var p = weather.getSupportProvince();
            return p;
        }
        public static string[] GetSupportCity(string province)
        {
            var p = weather.getSupportCity(province);
            return p;
        }

        public  static MyWeather  GetWeather(string city="赣州" )
        {
            city = GetTrueCity(city);
            var s = weather.getWeatherbyCityName(city);
            if (s.Length==23&&s[8]!="")
            {
                return new MyWeather(s);
            }
            return null;
         
        }
        /// <summary>
        /// 默认城市代码有编号
        /// 去除编号
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public  static  string GetTrueCity(string city)
        {
            try
            {
                int end = city.IndexOf('(');
                var result = city.Remove(end).Trim();
                return result;
            }
            catch 
            {

                return city;
            }
           


        }

        
    }
}
