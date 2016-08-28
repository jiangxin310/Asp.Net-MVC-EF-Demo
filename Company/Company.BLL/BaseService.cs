using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Company.IDAL;

namespace Company.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetDal();
        }

        public IBaseDAL<T> Dal;

        public abstract void SetDal();
        
        public bool Add(T t)
        {
            Dal.Add(t);
            return Dal.SaveChanges();
        }
        public bool Delete(T t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }
        public bool Update(T t)
        {
            Dal.Update(t);
            return Dal.SaveChanges();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }
    }
}
