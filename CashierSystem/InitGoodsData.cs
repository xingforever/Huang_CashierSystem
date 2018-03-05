using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CashierSystem
{
    public  class InitGoodsData
    {

        GoodsInfoHelperBll GoodsInfoHelperBll = new GoodsInfoHelperBll();

        int readData = 0;
        int trueData = 0;
        int SuccessData = 0;
        public  bool AddGoodsData(DataTable dataTble , out List<string> errorManager)
        {
             errorManager = new List<string>();
            //从DataTable 获取商品帮助表
            List<GoodsInfoHelper> goodinfosHelper = GoodsInfoHelperBll.GetGoodsInfoHelperByTable(dataTble,out errorManager);
            if (goodinfosHelper==null)
            {
                return false;
            }
            //将商品帮助表转换为标准商品信息表
            List<GoodsInfo> goodindoList = GoodsInfoHelperBll.GetGoodsInfoList(goodinfosHelper);
            //将标准商品信息表转换DataTable
            DataTable goodInfoListDataTable = GoodsInfoHelperBll.GetDataTableByGoodsInfoList(goodindoList);
            string error;
            //快速插入数据
            var isSucess = GoodsInfoHelperBll.InsertData(goodInfoListDataTable,out error);
            if (isSucess)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
