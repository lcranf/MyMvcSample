using MyMvcSample.Common.ViewModels;

namespace MyMvcSample.ViewModels.Orders
{
    public class OrderEditModel : BaseOrderModel, IEditModel
    {
        public int Id { get; set; }
    }
}