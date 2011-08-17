using System.Collections.Generic;
using System.Web.Mvc;

namespace MyMvcSample.ViewModels.Products
{

    public abstract class BaseProductModel
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ProductType { get; set; }

        //One to Many reference objects
        public IEnumerable<SelectListItem> ProductTypes { get; set; }
    }
}

