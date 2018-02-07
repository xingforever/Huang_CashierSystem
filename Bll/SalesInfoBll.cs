using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    class SalesInfoBll:BaseBll<SalesInfo>
    {

        SalesInfoBll()
        {
            this.CurrentDal = new  SalesInfoDal();
        }
    }
}
