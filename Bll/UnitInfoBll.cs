﻿using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class UnitInfoBll:BaseBll<UnitInfo>
    {
        public  UnitInfoBll()
        {
            this.CurrentDal = new UnitInfoDal();
        }
    }
}
