using CashierSystem;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = "Admins";
            userInfo.PassWord = Md5Helper.EncryptString("Admins");
            userInfo.Remark = "超级管理员";
            var isSuccess = DataManager.UserInfoBLL.Add(userInfo);
            if (isSuccess)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("不成功");
            }
            Console.ReadKey();
        }
    }
}
