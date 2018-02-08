using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
  public   class BaseBll<T>where T : BaseModel, new()
    {
        public BaseDal<T> CurrentDal { get; set; }

       
        public bool Add(T entity)
        {
             return CurrentDal.Add(entity);
        }
        public bool Edit(T entity)
        {
            return CurrentDal.Edit(entity);
        }
        public T GetEntityById(int id)
        {
            return CurrentDal.GetEntityById(id);
        }

        public List<T> GetList()
        {
             return CurrentDal.GetList();
        }
        public DataTable GetDataTable(SearchModel searchModel)
        {
            return CurrentDal.GetDataTable(searchModel);
        }
        public DataTable GetDataTable()
        {
            return CurrentDal.GetDataTable();
        }

        public bool Delete(int id)
        {
            return CurrentDal.Delete(id);
        }
        public bool Delete(T entity)
        {
            return CurrentDal.Delete(entity);
        }

       
    }
}
