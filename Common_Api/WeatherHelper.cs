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

        public  static MyWeather  GetWeather(string province="江西",string city="赣州" )
        {
            
            var s = weather.getWeatherbyCityName(city);
            if (s.Length==23&&s[8]!="")
            {
                return new MyWeather(s);
            }
            return null;
         
        }
    }
}
