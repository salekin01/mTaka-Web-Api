using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private mTakaDbContext _dbContext = null;

        public Repository(mTakaDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }
        public virtual T GetById(string recordId)
        {
            return _dbSet.Find(recordId);
        }
        public virtual T GetBy(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
            //return _dbSet.AsQueryable().Where(whereCondition).FirstOrDefault();
        }
        //public IEnumerable<T> GetBy(Expression<Func<T, bool>> exp, Expression<Func<T, T>> columns)
        //{
        //    return _dbSet.Where<T>(exp).Select<T, T>(columns);
        //}
        public IEnumerable<U> GetBy<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> columns)
        {
            return _dbSet.Where<T>(exp).Select<T, U>(columns);
        }

        public virtual int Add(T t)
        {
            int ret = 0;
            var result = _dbSet.Add(t);
            if (result != null)
                return ret = 1;
            return ret;
        }
        public virtual int AddRange(IEnumerable<T> t)
        {
            int ret = 0;
            var result = _dbSet.AddRange(t);
            if (result != null)
                return ret = 1;
            return ret;
        }
        public virtual int Update(T t)
        {
            int ret = 0;
            var result = _dbSet.Attach(t);
            _dbContext.Entry(t).State = EntityState.Modified;
            if (result != null)
                return ret = 1;
            return ret;
        }
        public virtual int Delete(T t)
        {
            int ret = 0;
            if (_dbContext.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            var result = _dbSet.Remove(t);
            if (result != null)
                return ret = 1;
            return ret;
        }
        public virtual int RemoveRange(IEnumerable<T> t)
        {
            int ret = 0;
            var result = _dbSet.RemoveRange(t);
            if (result != null)
                return ret = 1;
            return ret;
        }
        public bool IsRecordExist(Expression<Func<T, bool>> where)
        {
            bool ret = false;
            int record = 0;
            record = _dbSet.Where(where).Count();
            if (record > 0)
            {
                ret = true;
            }
            return ret;
        }
        public long GetMaxValue(Expression<Func<T, string>> where)
        {
            int _max = _dbSet.Select(where).Cast<int?>().Max() ?? 0;
            if (_max != null)
            {
                return _max;
                //return long.Parse(_max);
            }
            return 0;
        }
        public long GetMaxValue(Expression<Func<T, int>> where)
        {
            int _max = _dbSet.Select(where).Cast<int?>().Max() ?? 0;
            if (_max != null)
            {
                return _max;
                //return long.Parse(_max);
            }
            return 0;
        }
       
        //public long GetMaxValue<Ttype>(Expression<Func<T, Ttype>> where)
        //{
        //    string _maxVal = string.Empty;
        //    var _max = _dbSet.Max(where);
        //    if (_max != null)
        //    {
        //        _maxVal = _max.ToString();
        //        return long.Parse(_maxVal);
        //    }
        //    return 0;
        //}

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
