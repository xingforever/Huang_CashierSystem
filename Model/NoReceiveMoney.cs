using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 未收账 信息
    /// </summary>
   public  class NoReceiveMoney:BaseModel
    {
        /// <summary>
        /// 销售单
        /// </summary>
        public  int SalesInfoId { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime CreateTime { get; set; }
      
        /// <summary>
        /// 销售单信息
        /// </summary>
        public SalesInfo SalesInfo { get; set; }

        public   NoReceiveMoney()
        {
           
            SalesInfo = null;
           
        }

        public override string GetSql()
        {
            return "([SalesInfoId],[CustomerName],[Phone],[CreateTime],[Remark],[DelFlag]) ";
        }

        public override string GetAddSql()
        {
            string sql = " Values ('" + this.SalesInfoId + "','"
                + this.CustomerName + "','" 
                + this.Phone + "','"
                + this.CreateTime + "','" 
                + this.Remark + "'," +
                this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set [Remark]='" + this.Remark + "'," 
                +" [CustomerName]='"+this.CustomerName+ "',"+
                "[Phone]='" +this.Phone+"'  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
            NoReceiveMoney noReceiveMoney = new NoReceiveMoney();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                noReceiveMoney.Id = Convert.ToInt32(dr["ID"]);
                noReceiveMoney.SalesInfoId = Convert.ToInt32(dr["SalesInfoId"]);
                noReceiveMoney.CustomerName = Convert.ToString(dr["CustomerName"]);
                noReceiveMoney.Phone = Convert.ToString(dr["Phone"]);
                noReceiveMoney.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                noReceiveMoney.Remark = Convert.ToString(dr["Remark"]);                
                Entitys.Add(noReceiveMoney);
            }

            return Entitys;
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "售货单Id编号", "客户姓名", "联系电话", "时间", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {
           return new List<int>() { 0, 6 };
        }

        public override string GetModelName()
        {
            return  "NoReceiveMoney"; 
        }

































    }
}
