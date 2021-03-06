using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository) 
            : base(repository)
        {
        }
    }
}