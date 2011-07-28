using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Repository
{
    public interface IAttachableRepository
    {
        IEntity Attach(IEntity entity);
    }
}