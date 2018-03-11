using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CashierSystem
{
   /// <summary>
   /// 初始化数据
   /// </summary>
    public  class InitGoodsData
    {
        /// <summary>
        /// 商品辅助类服务
        /// </summary>
        GoodsInfoHelperBll GoodsInfoHelperBll = new GoodsInfoHelperBll();

        int readData = 0;
        int trueData = 0;
        int successData = 0;
        /// <summary>
        /// 初始化导入数据
        /// </summary>
        /// <param name="dataTble">数据表</param>
        /// <param name="changeMessages">数据转换错误报告</param>
        /// <param name="insertDataMessage">数据导入报告</param>
        /// <returns></returns>
        public   bool AddGoodsData(DataTable dataTble , out List<string> changeMessages,out List<string>insertDataMessage)
        {
            changeMessages = new List<string>();
            insertDataMessage = new List<string>();
            //从DataTable 获取商品帮助表
            readData = dataTble.Rows.Count;
            List<GoodsInfoHelper> goodinfosHelper = GoodsInfoHelperBll.GetGoodsInfoHelperByTable(dataTble,out changeMessages);
            trueData = goodinfosHelper.Count;
            if (goodinfosHelper==null)
            {
                return false;
            }
            //将商品帮助表转换为标准商品信息表
            List<GoodsInfo> goodindoList = GoodsInfoHelperBll.GetGoodsInfoList(goodinfosHelper);
            successData = goodindoList.Count;         
            //快速插入数据
            var isSucess = GoodsInfoHelperBll.InsertData(goodindoList, out insertDataMessage);
            if (isSucess)
            {
                insertDataMessage.Add("共读取数据" + readData + "条, " + "符合条件数据 " + trueData + "条, " + "导入成功" + successData + "条");
                return true;

            }
            else
            {
                return false;
            }


        }

    }
}
