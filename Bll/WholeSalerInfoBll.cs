using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class WholeSalerInfoBll : BaseBll<WholeSalerInfo>
    {
        public WholeSalerInfoBll()
        {
            this.CurrentDal = new WholeSalerInfoDal();
        }
    }
}
