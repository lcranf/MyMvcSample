using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public class OrderService : CrudService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository) 
            : base(repository) {}
    }
}
