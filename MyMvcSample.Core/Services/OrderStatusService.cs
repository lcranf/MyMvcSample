using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public class OrderStatusService : CrudService<OrderStatus>, IOrderStatusService
    {
        public OrderStatusService(IRepository<OrderStatus> repository)
            : base(repository)
        {
        }
    }
}
