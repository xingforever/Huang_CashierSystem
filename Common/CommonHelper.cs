using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  static  class CommonHelper
    {
        /// <summary>
        /// 获取正确的价格区间
        /// </summary>
        /// <param name="mixMoneyString"></param>
        /// <param name="maxMoneyString"></param>
        /// <param name="mixMoney"></param>
        /// <param name="maxMoney"></param>
        /// <returns></returns>
        public static bool GetTrueSearchMoney(string mixMoneyString, string maxMoneyString, out decimal mixMoney, out decimal  maxMoney)
        {
            mixMoney = (decimal) 0;
            maxMoney = decimal.MaxValue ;
            if (mixMoneyString=="")
            {
                mixMoneyString = "0";
            }
            if (maxMoneyString=="")
            {
                maxMoneyString = decimal.MaxValue.ToString();
            }
            if (!decimal.TryParse(mixMoneyString, out  mixMoney))
            {
                return false;
            }
            if (!decimal.TryParse(maxMoneyString, out maxMoney))
            {
                return false;
            }
            if (mixMoney>maxMoney)
            {
                return false;
            }
            return true;



        }

    }
}
