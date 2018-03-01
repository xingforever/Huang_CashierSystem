using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class UserInfoBll:BaseBll<UserInfo>
    {

        public UserInfoBll()
        {
             this.CurrentDal=new UserInfoDal();
        }

        public bool IsExistName(string name)
        {
            return new UserInfoDal().IsExistName(name);
        }
    }
}
