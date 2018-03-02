using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Common
{
    public class XMLHelper
    {

        public static Dictionary<string, string> ReadXML(string path="setting.xml")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //检查是否存在配置文件
            if (!File.Exists(path))
            {
                dic = GetDefaultSetting();
                var isSaveSuccess=  WriteXML(dic);
                if (!isSaveSuccess)
                {
                    return null;
                }
            }
            dic = new Dictionary<string, string>();
            XDocument document = XDocument.Load(path);
            //获取到XML的根元素进行操作
            XElement root = document.Root;          
           
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                XElement Xmlname = item.Element("name");
                XElement Xmlvalue = item.Element("value");
                if (Xmlname!=null&& Xmlvalue!=null)
                {                    
                    dic.Add(Xmlname.Value, Xmlvalue.Value);
                }
               

            }
            //配置文件被人修改
            if (dic.Count!=6)
            {
                return GetDefaultSetting();
            }
            return dic;
           
        }

        public static bool WriteXML(Dictionary<string ,string >dic,string path="setting.xml")
        {
            try
            {
                XDocument document = new XDocument();
                XElement root = new XElement("setting");
                XElement listitem = new XElement("listitem");
                for (int i = 0; i < dic.Count; i++)
                {
                    foreach (var itemKey in dic.Keys)
                    {
                        listitem.SetElementValue("name", itemKey);
                        listitem.SetElementValue("name1", dic[itemKey]);
                        root.Add(listitem);
                    }

                }                
                root.Save(path);
                return true;
            }
            catch 
            {
                return false;
               
            }
          
            
        }

        public static Dictionary<string ,string> GetDefaultSetting()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("标题名称","收银系统");
            dic.Add("商品信息页数", "30");
            dic.Add("商品管理页数", "30");
            dic.Add("销售记录页数", "30");
            dic.Add("利润信息页数", "20");
            dic.Add("待收账信息页数", "20");
            return dic;
        }
    }
}
