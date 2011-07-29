using AutoMapper;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Mappings
{
    public class EntityToIdTypeConverter<TEntity> : TypeConverter<TEntity, int>
        where TEntity : IEntity
    {
        protected override int ConvertCore(TEntity entity)
        {
            return entity.Id;
        }
    }
}
