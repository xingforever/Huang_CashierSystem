using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public  class UnitInfoDal:BaseDal<UnitInfo>
    {

      public UnitInfoDal()
        {

        }

        public int GetUnitIdByName(string unitName)
        {
            string sql = "Select Id from  UnitInfo where [UnitName]= '" + unitName+"'";
            var dataTable = SqlHelper.GetDataTable(sql);
            if (dataTable.Rows.Count == 1)
            {
                var dr = dataTable.Rows[0];
                int id = Convert.ToInt32(dr["ID"]);
                return id;
            }
            return int.MaxValue;
        }

        //public  bool Delete(int id)
        //{
        //    UnitInfo entity = new UnitInfo();
        //    try
        //    {
        //        var theOldEntity = GetEntityById(id);
        //        var oldRemark = theOldEntity.Remark;
        //        var oldUnitName = theOldEntity.UnitName;
        //        //考虑是否替换 备注换为单位名称(如果删除了单位, 那么商品无法正常显示)
        //        //被删除后: unitName="",Remark:oldReMark;oldUnitName
        //        string sql = "Update  [" + entity.GetModelName() + "] Set [DelFlag]= " + true + " " +",[UnitName]=''"+",[Remark]="+ theOldEntity.Remark+";"+oldUnitName+
        //            "Where [ID]=" + id + "";
        //        var affected = SqlHelper.ExecuteNonQuery(sql);
        //        if (affected > 0)
        //        {
        //            //将

        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
