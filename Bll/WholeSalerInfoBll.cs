using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    class WholeSalerInfoBll:BaseBll<WholeSalerInfo>
    {
        WholeSalerInfoBll()
        {
            this.CurrentDal =  new WholeSalerInfoDal();
        }
    }
}
