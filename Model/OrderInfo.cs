using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 下单表 ---数据库中没有此表
    /// 当改表数据确定后转换为SalesInfo 
    /// </summary>
   public class OrderInfo
    {
        
        public int GoodsId { get; set;  }
        public  string GoodsName { get; set; }

        public int Count { get; set; }

        public decimal PayPice { get; set; }
        public  decimal DisCount { get; set; }

        public string Remark { get; set; }


        public OrderInfo()
        {
            GoodsId = int.MaxValue;
            GoodsName = "";
            Count = 0;
            PayPice = (decimal)0.0;
            DisCount = (decimal)0.0;
            Remark = "";
        }
       
    }
}
