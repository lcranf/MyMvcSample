using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Extensions
{
    public static class EntityExtensions
    {
        public static TViewModel ToViewModel<TViewModel, TEntity>(this TEntity entity)
            where TEntity : class, IEntity
            where TViewModel : class
        {
            return null;
        }
    }
}
