using System;
using System.Linq;
using System.Linq.Expressions;
using MyMvcSample.Common.Domain;
using MyMvcSample.Common.ViewModels;

namespace MyMvcSample.Common.Service
{

    public interface ICrudService<TEntity> where TEntity : IEntity
    {
        TEntity Update(TEntity entity);

        TEntity UpdateFromModel<TEditModel>(TEditModel editModel)
             where TEditModel : class, IEditModel;

        TEntity Create(TEntity entity);

        TEntity CreateFromModel<TCreateModel>(TCreateModel createModel)
            where TCreateModel : class, ICreateModel;

        TEntity CreateOrUpdate(TEntity entity);

        bool Delete(int id);

        TEntity FindById(int id);

        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> QueryBy(Expression<Func<TEntity, bool>> criteria);
    }
}
