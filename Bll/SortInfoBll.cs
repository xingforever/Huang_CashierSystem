using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class SortInfoBll : BaseBll<SortInfo>
    {

        public SortInfoBll()
        {
            this.CurrentDal = new SortInfoDal();
        }
    }
}
