using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    class NoReceiveMoneyBll:BaseBll<NoReceiveMoney>
    {
        NoReceiveMoneyBll()
        {
            this.CurrentDal = new NoReceiveMoneyDal();
        }
    }
}
