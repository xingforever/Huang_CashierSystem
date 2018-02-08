using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
   public class NoReceiveMoneyBll:BaseBll<NoReceiveMoney>
    {
      public  NoReceiveMoneyBll()
        {
            this.CurrentDal = new NoReceiveMoneyDal();
        }
    }
}
