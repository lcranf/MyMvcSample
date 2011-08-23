using System.Collections.Generic;
using AutoMapper;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Mappings
{
    public class EntityToIdTypeConverter<TEntity> : TypeConverter<TEntity, int>
        where TEntity : IEntity
    {
        protected override int ConvertCore(TEntity entity)
        {
            return (EqualityComparer<TEntity>.Default.Equals(entity, default(TEntity))) ? -1 : entity.Id;
        }
    }
}
