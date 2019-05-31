using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private mTakaDbContext _dbContext = null;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
        {
            _dbContext = new mTakaDbContext();
        }
        public IRepository<T> Repository<T>() where T : class    //if the repository class for a particular type has been created already then same instance will be returned, else a new instance will be returned.
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(_dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public mTakaDbQuery mTakaDbQuery()    //if the repository class for a particular type has been created already then same instance will be returned, else a new instance will be returned.
        {
            mTakaDbQuery repo = new mTakaDbQuery(_dbContext);
            return repo;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public Repository<T> GetRepoInstance<T>() where T : class
        //{
        //    return new Repository<T>(_dbContext);
        //}
    }
}
