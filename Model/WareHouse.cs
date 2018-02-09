using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    ////
    /// <summary>
    /// 仓库
    /// </summary>
    public class WareHouse : BaseModel
    {
        /// <summary>
        /// 商品
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 总数
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
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 单价(同样的东西 如果价钱不同 则认为不同货物 则 goodsId不同)
        /// </summary>

        public decimal PrePrice { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
     
        public WareHouse()
        {
          
         
        }

        public override string GetSql()
        {
            return "([GoodsId],[Total],[SalesCount],[SurplusCount],[UpdateTime],[PrePrice],[CreateTime],[Remark],[DelFlag]) ";
        }

        public override string GetAddSql()
        {
            string sql = " Values ('" + this.GoodsId + "','" + this.Total + "'," +
                this.SalesCount + "''" + this.SurplusCount + "'," +
                this.UpdateTime + "','" + this.PrePrice + "'," +
                this.CreateTime + "','" + this.Remark + "'," +
                this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql =  " Set [Remark]='" + this.Remark + "'," + "[UpdateTime]='" +
                this.UpdateTime+"'  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
          
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                WareHouse wareHouse = new WareHouse();
                dr = dataTable.Rows[i];
                wareHouse.Id = Convert.ToInt32(dr["ID"]);
                wareHouse.GoodsId = Convert.ToInt32(dr["GoodsId"]);
                wareHouse.Total = Convert.ToDouble (dr["Total"]);
                wareHouse.SalesCount = Convert.ToDouble(dr["SalesCount"]);
                wareHouse.SurplusCount = Convert.ToDouble(dr["SurplusCount"]);
                wareHouse.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
                wareHouse.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                wareHouse.PrePrice = Convert.ToDecimal(dr["PrePrice"]);
                wareHouse.Remark = Convert.ToString(dr["Remark"]);            
                Entitys.Add(wareHouse);
            }

            return Entitys;
        }
    }
}