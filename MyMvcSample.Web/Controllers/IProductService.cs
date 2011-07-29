using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Controllers
{
    public interface IProductService : ICrudService<Product>
    {
    }    
}