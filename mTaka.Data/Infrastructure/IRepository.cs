using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        T GetById(string recordId);
        T GetBy(Expression<Func<T, bool>> predicate);
        //IEnumerable<T> GetBy(Expression<Func<T, bool>> exp, Expression<Func<T, T>> columns);
        IEnumerable<U> GetBy<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> columns);
        int Add(T t);
        int AddRange(IEnumerable<T> t);
        int Update(T t);
        int Delete(T t);
        int RemoveRange(IEnumerable<T> t);
        bool IsRecordExist(Expression<Func<T, bool>> where);
        long GetMaxValue(Expression<Func<T, string>> where);
        long GetMaxValue(Expression<Func<T, int>> where);
        //long GetMaxValue<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> column);
    }
}
