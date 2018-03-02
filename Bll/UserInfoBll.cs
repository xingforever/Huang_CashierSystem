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
        public UserInfoDal dal = new UserInfoDal();
        public UserInfoBll()
        {
             this.CurrentDal=new UserInfoDal();
        }

        public bool IsExistName(string name)
        {
            return dal.IsExistName(name);
        }

        public  bool IsTrueNameAndPwd(string name,string pwd,out int  id)
        {
           return dal.IsTrueNameAndPwd( name,  pwd,out  id);
        }
    }
}
