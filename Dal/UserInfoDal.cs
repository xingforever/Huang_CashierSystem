
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public  class UserInfoDal:BaseDal<UserInfo>
    {
        public UserInfoDal()
        {

        }

        public  bool IsExistName( string name)
        {
           string sql= "Select * from [UserInfo] where [UserName]=" + name;
            var data = SqlHelper.ExecuteNonQuery(sql);
            if (data<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
