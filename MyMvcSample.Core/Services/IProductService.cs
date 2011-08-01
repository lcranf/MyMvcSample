using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public interface IProductService : ICrudService<Product>
    {
    }    
}