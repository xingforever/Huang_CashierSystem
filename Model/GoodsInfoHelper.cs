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
        public string  UnitName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string  SortName { get; set; }
        /// <summary>
        /// 供应商信息
        /// </summary>
        public string  WholeSalerName { get; set; }

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
        /// <summary>
         /// 备注
         /// </summary>
         public string Remark { get; set; }

        public GoodsInfoHelper()
        {
            //默认一年
            this.LastTime = DateTime.Now + new TimeSpan(365, 0, 0, 0);
        }



        public GoodsInfoHelper(string goodsName,string sortName,string unitName,double  total,double  saleCount,double surplusCount,decimal purPrice,decimal payPrice,string wholeSalesName,DateTime lastTime,string reamark)
        {
            this.GoodsName = goodsName;
            this.SortName = sortName;
            this.UnitName = unitName;
            this.Total = total;
            this.SalesCount = saleCount;
            this.SurplusCount = surplusCount;
            this.PurPrice = purPrice;
            this.PayPrice = payPrice;
            this.WholeSalerName = wholeSalesName;
            this.LastTime = lastTime;
            this.Remark = reamark;
            this.CreateTime = DateTime.Now;
            
        }

      

    }
}
