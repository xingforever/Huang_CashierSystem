using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 销售表
    /// </summary>
   public  class ProfitsInfo:BaseModel
    { 

        /// <summary>
        /// 订单信息
        /// </summary>
        public string  OrderId { get; set; }
      
        /// <summary>
        /// 总利润
        /// </summary>
        public  decimal Profit{ get; set; }
        /// <summary>
        /// 总折扣
        /// </summary>
        public  decimal DisCount { get; set; }
        /// <summary>
        /// 是否支付完成
        /// </summary>
        public  bool IsPay { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime CreateTime { get; set; }           
      

        public OrderInfo OrderInfo { get; set; }

       public  ProfitsInfo()
        {
         
            OrderInfo = null;
          
        }
        public override string GetModelName()
        {
            return "ProfitsInfo";
        }
        /// <summary>
        /// 获取表格值名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "OrderId",  "Profit","DisCount", "CreateTime",
             "IsPay",  "Remark", "DelFlag" }; ;
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        { 
            return new List<string> { "ID编号", "订单编号",  "利润", "折扣", "订单时间", "是否支付", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {

            return new List<int>() { 0, 7};
        }

        public override string GetSql()
        {
            return "([OrderId],[Profit],[DisCount],[CreateTime],[IsPay],[Remark],[DelFlag]) ";
        }

        public override string GetAddSql()
        {
            string sql = " Values ('" + this.OrderId + "','"              
                  + this.Profit + "','" + this.CreateTime + "','"
                  +this.DisCount+"',"
                  + this.IsPay + ",'"  + this.Remark + "',"
                  +  this.DelFlag + ")";

            return sql;
        }
        /// <summary>
        /// 修改是否支付和备注
        /// </summary>
        /// <returns></returns>
        public override string GetEditSql()
        {
            string sql = " Set [Remark]='" + this.Remark + "',"+ "[IsPay] = " + this.IsPay + "  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;           
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProfitsInfo profitsInfo = new ProfitsInfo();
                dr = dataTable.Rows[i];
                profitsInfo.Id = Convert.ToInt32(dr["ID"]);
                profitsInfo.OrderId = Convert.ToString(dr["OrderId"]);             
                profitsInfo.Profit = Convert.ToDecimal(dr["Profit"]);
                profitsInfo.IsPay = Convert.ToBoolean(dr["IsPay"]);
                profitsInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                profitsInfo.Remark = Convert.ToString(dr["Remark"]);                
                Entitys.Add(profitsInfo);
            }

            return Entitys;
        }

    }
}
