using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        //Repository<T> GetRepoInstance<T>() where T : class;
        IRepository<T> Repository<T>() where T : class;
        mTakaDbQuery mTakaDbQuery();
        void Commit();
    }
}