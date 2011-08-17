using MyMvcSample.Common.Domain;

namespace MyMvcSample.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}