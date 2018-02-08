using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitInfo : BaseModel
    {
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }


        public UnitInfo()
        {


        }

        public override string GetModelName()
        {
            return "UnitInfo";
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "名称", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {

            return new List<int>() { 0, 3 };
        }

        public override string GetSql()
        {
            return "([UnitName],[Remark],[DelFlag]) ";
        }
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.UnitName + "','" + this.Remark + "'," + this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set[UnitName]='" + this.UnitName + "', [Remark]='" + this.Remark + "'  Where [ID]=" + this.Id;
            return sql;
        }

        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;
            UnitInfo unitInfo = new UnitInfo();
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = dataTable.Rows[i];
                unitInfo.Id = Convert.ToInt32(dr["ID"]);
                unitInfo.UnitName = Convert.ToString(dr["UnitName"]);
                unitInfo.Remark = Convert.ToString(dr["Remark"]);
                Entitys.Add(unitInfo);
            }

            return Entitys;
        }

    }
}
