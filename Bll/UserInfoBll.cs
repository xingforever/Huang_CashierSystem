using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    class UserInfoBll:BaseBll<UserInfo>
    {

        UserInfoBll()
        {
             this.CurrentDal=new UserInfoDal();
        }
    }
}
