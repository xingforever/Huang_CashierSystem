using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 商品单
    /// </summary>
  public  class GoodsInfo:BaseModel
    {
        /// <summary>
        /// 单位
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public  int SortId { get; set; }
        /// <summary>
        /// 供应商信息
        /// </summary>
        public  int WholeSalerId { get; set; }
       
        /// <summary>
        /// 商品名
        /// </summary>
        public  string GoodsName { get; set; }
        /// <summary>
        /// 价格()
        /// </summary>
        public  decimal PurPrice { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal PayPrice { get; set; }       
        /// <summary>
        /// 商品描述
        /// </summary>
        public  string GoodsType { get; set; }
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


        public  WholeSalerInfo WholeSalerInfo { get; set; }

        public  SortInfo SortInfo { get; set; }

        public UnitInfo UnitInfo { get; set; }

      public   GoodsInfo()
        {
            ModelName = "GoodsInfo";            
            WholeSalerInfo = null;
            SortInfo = null;
            UnitInfo = null;
            
        }

        public override string GetSql()
        {
            return "([UnitId],[SortId],[WholeSalerId],[GoodsName],[PurPrice],[PayPrice],[GoodsType],[Total],[SalesCount],[SurplusCount],[CreateTime],[LastTime],[Remark],[DelFlag])";
        }

        public override string GetAddSql()
        {
            

            return "Values('" + this.UnitId + "','" + 
                this.SortId + "','" + 
                this.WholeSalerId + "','" +
                this.GoodsName + "','" + 
                this.PurPrice + "','"+ 
                this.PayPrice + "','" +
                this.GoodsType + "','" + 
                this.Total + "','" +
                this.SalesCount + "','" +
                this.SurplusCount + "','" +
                this.CreateTime + "','" +
                this.LastTime + "','" +
                this.Remark +"',"+
                this.DelFlag+")" ;

        }
        public override string GetEditSql()
        {
            string sql = " Set[UnitId]='" + this.UnitId +
                "', [WholeSalerId]='" + this.WholeSalerId +
                "', [GoodsName]='" + this.GoodsName +
                "', [PayPrice]='" + this.PayPrice +
                "', [Total]='" + this.Total +
                "', [SalesCount]='" + this.SalesCount +
                "', [SurplusCount]='" + this.SurplusCount +
                "', [LastTime]='" + this.LastTime +
                "', [Remark]='" + this.Remark +
                "'  Where [ID]=" + this.Id;

            return sql;
        }


        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
            GoodsInfo goodsInfo = new GoodsInfo();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                goodsInfo.Id = Convert.ToInt32(dr["ID"]);
                goodsInfo.UnitId = Convert.ToInt32(dr["UnitId"]);
                goodsInfo.SortId = Convert.ToInt32(dr["SortId"]);
                goodsInfo.WholeSalerId = Convert.ToInt32(dr["WholeSalerId"]);
                goodsInfo.GoodsType = Convert.ToString(dr["GoodsType"]);
                goodsInfo.PurPrice = Convert.ToDecimal(dr["PurPrice"]);           
                goodsInfo.PayPrice = Convert.ToDecimal(dr["PayPrice"]);
                goodsInfo.Total = Convert.ToDouble(dr["Total"]);
                goodsInfo.SalesCount = Convert.ToDouble(dr["SalesCount"]);
                goodsInfo.SurplusCount = Convert.ToDouble(dr["SurplusCount"]);
                goodsInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                goodsInfo.LastTime = Convert.ToDateTime(dr["LastTime"]);              
                goodsInfo.Remark = Convert.ToString(dr["Remark"]);          
                Entitys.Add(goodsInfo);
            }

            return Entitys;
        }







    }
}
