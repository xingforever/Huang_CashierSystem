using com.show.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common_API
{
    /// <summary>
    /// 黄历API 
    /// </summary>
   public  class AlmanacApiHelper
    {
        // 网址 https://www.showapi.com  注册账号为 2945873057@qq.com  期限 1年 
        //官方文档;https://www.showapi.com/api/lookPoint/856
        public static  string my_appId = "56814";//端口号

        public static  string my_appSecret = "0c16da7aff6840e7ad5e52da243ff699";//密匙

        public static string nongli;//农历
        public static string errMessage;

        public static string gongli;//公历
        public static string yi;//宜
        public static string ji;//忌

        public static string  date;
        AlmanacApiHelper()
        {
         

        }

        public  static bool GetData()
        {
            DateTime dateTime = DateTime.Today;
            date = dateTime.ToString("yyyyMMdd");
            String jsonStr = new ShowApiRequest("http://route.showapi.com/856-1", my_appId, my_appSecret)
            .addTextPara("date", date)
            .post();

            JObject obj = (JObject)JsonConvert.DeserializeObject(jsonStr);  //序列化（也可使用JToken代替JObject）  

            bool isSuccess= obj["showapi_res_code"].ToString()=="0"?true:false;//api是否调用成功
            if (isSuccess)
            {
                JObject jrobj = (JObject)JsonConvert.DeserializeObject((obj["showapi_res_body"].ToString()));//黄历结构体的主要数据
                nongli = jrobj["nongli"].ToString();
                gongli= jrobj["gongli"].ToString();
                ji= jrobj["ji"].ToString();
                yi= jrobj["yi"].ToString();
            }
            else
            {
                errMessage = obj["showapi_res_error"].ToString();
            }

            return isSuccess;

        }
      
     
       

       


    }
}
