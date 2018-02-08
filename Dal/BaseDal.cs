using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public class BaseDal<T> where T : BaseModel, new()
    {

        public bool Add(T entity)
        {
            //表名字
            string modelName = entity.GetModelName();
            int affected = 0;
            string sqls = entity.GetSql();
            string pamerSql = entity.GetAddSql();
            string sql = "Insert into " + "[" + modelName + "]" + sqls + pamerSql;
            try
            {
                affected = SqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return (affected == 1);
        }

        public bool Edit(T entity)
        {
            string modelName = entity.GetModelName();
            int affected = 0;

            string pamerSql = entity.GetEditSql();
            string sql = "Update [" + modelName + "]" + pamerSql;
            try
            {
                affected = SqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            if (affected<1)
            {
                return false;
            }
            return true;

        }

        public T GetEntityById(int id)
        {
            T entity = new T();
            try
            {
                string sql = "Select * from [" + entity.GetModelName() + "] where [ID]=" + id;
                var dataTable = SqlHelper.GetDataTable(sql);
                var listEntity = entity.GetList(dataTable);
                if (listEntity.Count == 1)
                {
                    return (T)listEntity[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public List<T> GetList()
        {
            List<T> list = new List<T>();
            T entity = new T();
            try
            {
                string sql = "Select * from [" + entity.GetModelName() + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);
                var listEntity = entity.GetList(dataTable);
                if (listEntity.Count > 0)
                {
                    listEntity = listEntity.ToList();
                    foreach (var item in listEntity)
                    {
                        list.Add((T)item);
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public DataTable GetDataTable()
        {
            T entity = new T();
            try
            {
                string sql = "Select * from [" + entity.GetModelName() + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);
                return dataTable;
            }
            catch(Exception ex)
            {
                var e = ex.Message; ;
                return null;
            }
        }
        public DataTable GetDataTable(SearchModel searchModel)
        {
            try
            {
                string sql = "Select * from [" + searchModel.ModelName + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            T entity = new T();
            try
            {
                string sql = "Update  [" + entity.GetModelName() + "] Set [DelFlag]= "+true+" Where [ID]=" + id + "";
                var affected = SqlHelper.ExecuteNonQuery(sql);
                if (affected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                string sql = "Update  [" + entity.GetModelName() + "] Set [DelFlag]=" + true + "  Where [ID]=" + entity.Id + "";
                var affected = SqlHelper.ExecuteNonQuery(sql);
                if (affected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
