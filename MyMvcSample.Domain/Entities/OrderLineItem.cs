using System.ComponentModel.DataAnnotations;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Domain.Entities
{
    public class OrderLineItem : BaseAuditableEntity
    {
        [Required, StringLength(150)]
        public string Item { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        //Marking a parent entity as required ensures that the OnCascade convention
        //will be applied when generating the database and will allow for easier
        //deletions of graphs via EF
        [Required]
        public virtual Order Order { get; set; }
    }
}