using System.Data.Entity;
using System.Linq;
using FizzWare.NBuilder;
using MyMvcSample.Domain.Entities;

namespace MyMvcSample.Domain.Db
{
    public class MyMvcSampleContextInitializer : DropCreateDatabaseIfModelChanges<MyMvcSampleContext>
    {
        protected override void Seed(MyMvcSampleContext context)
        {
            var orderStatuses = new[]
                                    {
                                        new OrderStatus {Name = "Received"},
                                        new OrderStatus {Name = "Processing"},
                                        new OrderStatus {Name = "Charged"},
                                        new OrderStatus {Name = "Packaging"},
                                        new OrderStatus {Name = "Shipped"},
                                        new OrderStatus {Name = "Cancelled" }
                                    };

            orderStatuses.ToList().ForEach(os => context.OrderStatuses.Add(os));

            var orders = Builder<Order>.CreateListOfSize(25)
                                       .WhereAll()
                                       .HaveDoneToThem(o => o.Id = 0)
                                       .HaveDoneToThem(o => o.OrderStatus = Pick<OrderStatus>.RandomItemFrom(orderStatuses))
                                       .HaveDoneToThem(o => o.UpdatedBy = null)
                                       .HaveDoneToThem(o => o.UpdatedOn = null)
                                       .Build();

            var lineItems = Builder<OrderLineItem>.CreateListOfSize(50)
                .WhereAll()
                .HaveDoneToThem(li => li.Id = 0)
                .HaveDoneToThem(o => o.UpdatedBy = null)
                .HaveDoneToThem(o => o.UpdatedOn = null)
                //assign lineitem to a random order
                .HaveDoneToThem(li => Pick<Order>.RandomItemFrom(orders).AddLineItem(li))
                .Build();

            //save in context
            orders.ToList().ForEach(o => context.Orders.Add(o));
        }
    }
}
