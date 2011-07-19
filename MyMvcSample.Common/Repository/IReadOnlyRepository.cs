using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Repository
{
    public interface IReadOnlyRepository
    {
        IEntity GetById(int entityId);
    }
}