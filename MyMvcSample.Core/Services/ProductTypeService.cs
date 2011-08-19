using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Db;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public class ProductTypeService : CrudService<ProductType>, IProductTypeService
    {
        // If you are using Dependency Injection, you can delete the following constructor   
        public ProductTypeService()
            : this(new Repository<ProductType>(new DbContextRegistry()))
        {
        }

        public ProductTypeService(IRepository<ProductType> repository) 
            : base(repository)
        {
        }
    }
}