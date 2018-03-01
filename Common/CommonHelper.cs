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


        public static bool GetTruePage(int pageSum,int pageNow,int id,bool isNest)
        {
            if (isNest)
            {
                if ((pageNow + 1) > pageSum)
                {
                    return false;
                }
            }
            else
            {
                if ((pageNow -1) <=0)
                {
                    return false;
                }
            }
           
            if (id <0)
            {
                return false;
            }
            return true;
        }

        public  static void StartCalc()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "calc.exe ";//"calc.exe"为计算器，
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch 
            {

                ;
            }
          
        }

        public  static  void StartNotePad()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "notepad.exe ";//""notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch 
            {

                ;
            }
            
        }
    }
}
