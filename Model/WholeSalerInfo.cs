using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    /// <summary>
    /// 供货信息
    /// </summary>
    public class WholeSalerInfo : BaseModel
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>

        public string AddressInfo { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>

        public string Management { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelePhone { get; set; }


        public WholeSalerInfo()
        {


        }

        public override string GetModelName()
        {
            return "WholeSalerInfo";
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "供货商店名", "供货商地址", "负责人", "联系电话", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {
            return new List<int>() { 0, 6 };
        }


        public override string GetSql()
        {
            return "([SupName],[AddressInfo],[Management],[TelePhone],[Remark],[DelFlag]) ";
        }
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.SupName + "','" +
                this.AddressInfo + "','" +
                this.Management + "','" +
                this.TelePhone + "','" +
                this.Remark + "'," +
                this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set[SupName]='" + this.SupName +
                 "', [AddressInfo]='" + this.AddressInfo +
                 "', [Management]='" + this.Management +
                 "', [TelePhone]='" + this.TelePhone +
                 "', [Remark]='" + this.Remark +
                 "'  Where [ID]=" + this.Id;

            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
            WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                wholeSalerInfo.Id = Convert.ToInt32(dr["ID"]);
                wholeSalerInfo.SupName = Convert.ToString(dr["SupName"]);
                wholeSalerInfo.AddressInfo = Convert.ToString(dr["AddressInfo"]);
                wholeSalerInfo.Management = Convert.ToString(dr["Management"]);
                wholeSalerInfo.TelePhone = Convert.ToString(dr["TelePhone"]);
                wholeSalerInfo.Remark = Convert.ToString(dr["Remark"]);

                Entitys.Add(wholeSalerInfo);
            }

            return Entitys;
        }

    }
}