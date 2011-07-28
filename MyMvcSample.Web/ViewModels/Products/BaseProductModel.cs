
namespace MyMvcSample.ViewModels.Products
{
  
    public abstract class BaseProductModel 
    {
        
        public string Name { get; protected set; }
        
        public decimal Price { get; set; }
        
        public MyMvcSample.Domain.Entities.Order Order { get; set; }
        
        public int AnotherPrivateIntVar { get; set; }
        
    }
}

