using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class SoftHelper
    {
        /// <summary>   
        /// 确认认是否有安裝 Access    
        /// </summary>   
        /// <returns>true: 有安裝, false:沒有安裝</returns>   
        public  static  bool CheckAccess()
        {
            Microsoft.Win32.RegistryKey uninstallNode = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (string subKeyName in uninstallNode.GetSubKeyNames())
            {
                Microsoft.Win32.RegistryKey subKey = uninstallNode.OpenSubKey(subKeyName);
                object displayName = subKey.GetValue("DisplayName");
                if (displayName != null)
                {
                    if (displayName.ToString().Contains("Access"))
                    {
                        return true;
                       
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 确认是否安装Excle
        /// </summary>
        /// <returns></returns>

        public static  bool CheckExcel()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }
    }
}
