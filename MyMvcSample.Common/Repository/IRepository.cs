using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Repository
{
    public interface IRepository<TEntity> : IReadOnlyRepository
        where TEntity : IEntity
    {
        TEntity Attach(TEntity entity);
        TEntity Create(TEntity entity);
        TEntity CreateOrUpdate(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(int entityId);
        IQueryable<TEntity> QueryBy();
        IQueryable<TEntity> QueryByIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FindById(int entityId);
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> where);
        void Save();
    }
}
