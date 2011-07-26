using MyMvcSample.Common.Repository;
using MyMvcSample.Common.Service;
using MyMvcSample.Domain.Db;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Controllers
{
      public class ProductCreateModel
    {
        
        public string Name { get; protected set; }
        
        public decimal Price { get; set; }
        
        public MyMvcSample.Domain.Entities.Order Order { get; set; }
        
        public int AnotherPrivateIntVar { get; set; }
            }
}

