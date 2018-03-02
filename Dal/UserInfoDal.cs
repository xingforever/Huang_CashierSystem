
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class UserInfoDal : BaseDal<UserInfo>
    {
        public UserInfoDal()
        {

        }

        public bool IsExistName(string name)
        {
            string sql = "Select * from [UserInfo] where [UserName]='" + name + "' and [Delflag]=" + false;
            var dataTable = SqlHelper.GetDataTable(sql);
            var listEntity = new UserInfo().GetList(dataTable);
            if (listEntity.Count <= 0)
            {
                return false;
            }
            return true;
        }

        public bool IsTrueNameAndPwd(string name, string pwd,out int id)
        {
            id = int.MaxValue;
            var isExist = IsExistName(name);
            if (isExist)
            {
                string sql = "Select * from [UserInfo] where [UserName]='" + name + "' and [Delflag]=" + false; ;
                var dataTable = SqlHelper.GetDataTable(sql);
                var listEntity = new UserInfo().GetList(dataTable);
                UserInfo userInfo = new UserInfo();
                if (listEntity.Count == 1)
                {
                    userInfo = (UserInfo)listEntity[0];
                    id = userInfo.Id;
                }
                else
                {
                    return false;
                }
                string pwds = Md5Helper.EncryptString(pwd);
                if (pwds.Equals(userInfo.PassWord))
                {
                    return true;
                }

            }
            return false;
        }
    }
}
