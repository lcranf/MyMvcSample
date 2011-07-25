using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Db;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Controllers
{
  
    public interface IProductService : ICrudService<Product> {}

    public class ProductService : CrudService<Product>, IProductService
    {
        
        // If you are using Dependency Injection, you can delete the following constructor   
        public ProductService()
            : this(new Repository<Product>(new DbContextRegistry())) {}  
             
        public ProductService(IRepository<Product> repository) 
            : base(repository) {}
    }
}