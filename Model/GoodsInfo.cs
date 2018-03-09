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
                  
            WholeSalerInfo = null;
            SortInfo = null;
            UnitInfo = null;
           

        }

        public  override string GetModelName()
        {
             return  "GoodsInfo";
        }
        public override string GetSql()
        {
            return "([GoodsName],[SortId],[UnitId],[GoodsType],[PurPrice],[PayPrice],[Total],[SalesCount],[SurplusCount],[WholeSalerId],[CreateTime],[LastTime],[Remark],[DelFlag])";
        }

        public override string GetAddSql()
        {
            
            return "Values('" + this.GoodsName + "','" + 
                this.SortId + "','" + 
                this.UnitId + "','" +
                this.GoodsType + "','" + 
                this.PurPrice + "','"+ 
                this.PayPrice + "','" +                
                this.Total + "','" +
                0 + "','" +
                this.Total + "','" +
                this.WholeSalerId + "','" +
                this.CreateTime + "','" +
                this.LastTime + "','" +
                this.Remark +"',"+
                this.DelFlag+")" ;

        }
        public override string GetEditSql()
        {
            string sql = " Set[UnitId]='" + this.UnitId +
                 "', [SortId]='" + this.SortId +
                "', [WholeSalerId]='" + this.WholeSalerId +
                "', [GoodsName]='" + this.GoodsName +
                "', [PurPrice]='" + this.PurPrice +
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
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                GoodsInfo goodsInfo = new GoodsInfo();
                dr = dataTable.Rows[i];
                goodsInfo.Id = Convert.ToInt32(dr["ID"]);
                goodsInfo.GoodsName = Convert.ToString(dr["GoodsName"]);
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

        public override List<string> GetTableName()
        {
            //DgvName
            // return new List<string> { "ID","GoodsName", "SortName", "UnitName", "GoodsType", "PurPrice", "PayPrice", "Total", "SalesCount", "SurplusCount", "WholeSalerName", "CreateTime", "LastTime", "Remark", "DelFlag" }; 
            return new List<string> { "ID","GoodsName", "SortName", "UnitName", "GoodsType", "PurPrice" ,"PayPrice", "Total","SurplusCount", "WholeSalerName", "Remark" }; ;
        }

        /// <summary>
        /// 获取标题显示名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
           
           //DgvDisPlayName
            return new List<string> { "ID编号", "商品名", "类别", "单位", "规格","单价","售价", "总量","库存", "供货商", "备注" }; ;
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {
            //默认 隐藏的数据
            return  new List<int>() { 0,5,7}; 
        }




    }
}
