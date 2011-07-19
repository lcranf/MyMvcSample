using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MyMvcSample.Common.Domain;
using MyMvcSample.Common.Extensions;

namespace MyMvcSample.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        [Required, StringLength(150)]
        public string Name { get; set; }

        public DateTime? OrderDate { get; set; }

        public virtual ICollection<OrderLineItem> OrderItems { get; set; }

        public void AddLineItem(OrderLineItem lineItem)
        {
            AddLineItems(new[] { lineItem });
        }

        public void AddLineItems(IEnumerable<OrderLineItem> lineItems)
        {
            if (!lineItems.Any()) return;

            if (OrderItems.IsNullOrEmpty())
            {
                OrderItems = new List<OrderLineItem>();
            }

            lineItems.ToList().ForEach(li => { OrderItems.Add(li); li.Order = this; });
        }
    }
}
