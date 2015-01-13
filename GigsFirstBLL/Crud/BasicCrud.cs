using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using GigsFirstDAL;

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

    public class BasicCrud<T> : IBasicCrud<T> where T : class
    {
        public DbContext Context { get; private set; }
        private DbSet<T> _dbSet;
        public GigsFirstEntities db {get;set;}

        public BasicCrud()
        {
            Context = new GigsFirstEntities();
            _dbSet = Context.Set<T>();
            db = new GigsFirstEntities();
        }

        public T Insert(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                Context.SaveChanges();
                return entity;
            }

            catch (Exception e)
            {
                return null;
            }     
        }

        public bool Delete(int id)
        {
            try
            {
                _dbSet.Remove(_dbSet.Find(id));
                Context.SaveChanges();
                return true; 
            }

            catch (Exception e)
            {
                return false;
            }    
           
        }

        public bool Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }

        public virtual T GetSingle(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }
    }
}
