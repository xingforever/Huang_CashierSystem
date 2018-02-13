using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    /// <summary>
    /// 判断网络是否连接成功
    /// </summary>
    public class IsConnectionNET
    {
        //InternetGetConnectedState返回的状态标识位的含义：
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        private const int INTERNET_CONNECTION_PROXY = 4;
        private const int INTERNET_CONNECTION_MODEM_BUSY = 8;

        [DllImport("winInet.dll ")]
        //声明外部的函数：
        private static extern bool InternetGetConnectedState(
            ref int dwFlag,
            int dwReserved
        );

        public static bool IsConnect()
        {
            int dwFlag = 0;
            string netstatus = "";
            if (!InternetGetConnectedState(ref dwFlag, 0))
                return false;
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                    netstatus += " 采用调治解调器上网 \n";

                if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                    netstatus += " 采用网卡上网  \n";

                if ((dwFlag & INTERNET_CONNECTION_PROXY) != 0)
                    netstatus += " 采用代理上网  \n";

                if ((dwFlag & INTERNET_CONNECTION_MODEM_BUSY) != 0)
                    netstatus += " MODEM被其他非INTERNET连接占用  \n";
            }
            return true;
            
        }



    }
}
