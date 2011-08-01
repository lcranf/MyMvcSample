using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample
{
    public interface IProductService : ICrudService<Product>
    {
    }    
}