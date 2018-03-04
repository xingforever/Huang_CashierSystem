using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public   class GoodsInfoHelper
    {
         /// <summary>
        /// 单位
        /// </summary>
        public string  UnitId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string  SortId { get; set; }
        /// <summary>
        /// 供应商信息
        /// </summary>
        public string  WholeSalerId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 价格()
        /// </summary>
        public decimal PurPrice { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal PayPrice { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 已卖出
        /// </summary>
        public double SalesCount { get; set; }
        /// <summary>
        /// 剩余
        /// </summary>
        public double SurplusCount { get; set; }
        /// <summary>

        public DateTime CreateTime { get; set; }
        /// <summary>
        ///过期时间(报废)
        /// </summary>
        public DateTime LastTime { get; set; }




        public  GoodsInfoHelper GetGoodsInfoHelper(string goodsName,string sortName)
        {

            return null;
        }

    }
}
