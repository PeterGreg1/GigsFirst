using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GigsFirstBLL
{
    public interface IBasicCrud<T>
    {
        T Insert(T entity);
         bool Delete(int id);
         bool Update(T entity);
         T GetSingle(int id);
         IQueryable<T> Search(Expression<Func<T, bool>> predicate);
         IQueryable<T> GetAll();
    }
}
