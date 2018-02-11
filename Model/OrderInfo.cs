using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 订单表
    /// </summary>
   public class OrderInfo:BaseModel
    {
        /// <summary>
        /// 订单号--下单的年月日小时分钟秒
        /// </summary>
        public  string OrderId;
        public int GoodsId { get; set;  }
        public  string GoodsName { get; set; }
        public int Count { get; set; }

        public decimal PayPrice { get; set; }
        public  decimal DisCount { get; set; }

       public  DateTime CreateTime { get; set; }

        public GoodsInfo GoodsInfo { get; set; }

        public OrderInfo()
        {
            GoodsId = int.MaxValue;
            GoodsName = "";
            Count = 0;
            PayPrice = (decimal)0.0;
            DisCount = (decimal)0.0;
            GoodsInfo = null;
        }


        public override string GetSql()
        {
            return "([OrderId],[GoodsId],[Count],[DisCount],[PayPice],[CreateTime],[Remark],[DelFlag])";
        }

        public override string GetAddSql()
        {
            return "Values('" + this.OrderId + "','" +
                this.GoodsId + "','" +
                this.Count + "','" +
                this.DisCount + "','" +
                this.PayPrice + "','" +  
                this.CreateTime+ "','" +
                this.Remark + "'," +
                this.DelFlag + ")";
        }
        /// <summary>
        /// 修改商品类型,数量,折扣,备注
        /// </summary>
        /// <returns></returns>
        public override string GetEditSql()
        {
            string sql = " Set[GoodsId]='" + this.GoodsId +            
              "', [DisCount]='" + this.DisCount +
              "', [Count]='" + this.Count +             
              "', [Remark]='" + this.Remark +
              "'  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {
            DataRow dr = null;
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                OrderInfo orderInfo = new OrderInfo();
                dr = dataTable.Rows[i];
                orderInfo.Id = Convert.ToInt32(dr["ID"]);
                orderInfo.OrderId = Convert.ToString(dr["OrderId"]);
                orderInfo.GoodsName = Convert.ToString(dr["GoodsId"]);
                orderInfo.Count = Convert.ToInt32(dr["Count"]);
                orderInfo.DisCount = Convert.ToInt32(dr["DisCount"]);
                orderInfo.PayPrice = Convert.ToInt32(dr["PayPice"]);
                orderInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                orderInfo.Remark = Convert.ToString(dr["Remark"]);
                orderInfo.DelFlag = Convert.ToBoolean(dr["DelFlag"]);
                Entitys.Add(orderInfo);
            }

            return Entitys;
        }

        public override List<string> GetTableName()
        {
            return new List<string>() { "ID", "OrderId", "GoodsName", "Count", "DisCount", "Prices", "CreateTime","Remark", "DelFlag" };
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {

            return new List<string>() { "ID编号", "订单号", "商品名称", "数量", "折扣", "收款","订单日期", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {

            return new List<int>()
            {
                0,7
            };
        }

        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <returns></returns>
        public override string GetModelName()
        {
            return "OrderInfo";
        }


    }
}
