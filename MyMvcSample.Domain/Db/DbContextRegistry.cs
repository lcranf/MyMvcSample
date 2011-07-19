using System;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using MyMvcSample.Common.Db;

namespace MyMvcSample.Domain.Db
{
    public class DbContextRegistry : IDbContextRegistry, IDisposable 
    {
        private MyMvcSampleContext _dbContext;
        private bool _disposed;

        public DbContext CurrentContext
        {
            get
            {
                return _dbContext
                    ?? (_dbContext = (MyMvcSampleContext) ServiceLocator.Current.GetInstance<DbContext>());
            }
        }
        
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if(_dbContext != null)  _dbContext.Dispose();

                _disposed = true;
            }
        }
    }
}
