using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Core.Services
{
    public class ProductTypeService : CrudService<ProductType>, IProductTypeService
    {
        public ProductTypeService(IRepository<ProductType> repository) 
            : base(repository)
        {
        }
    }
}