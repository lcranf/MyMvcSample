
using MyMvcSample.Common.ViewModels;


namespace MyMvcSample.ViewModels.Products
{
  
    public class ProductEditModel : BaseProductModel, IEditModel
    {
        
        public int Id { get; set; }
                
    }
}

