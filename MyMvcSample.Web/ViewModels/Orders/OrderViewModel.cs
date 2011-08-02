namespace MyMvcSample.ViewModels.Orders
{
    public class OrderViewModel : BaseOrderModel
    {
        public int Id { get; set; }

        public int NumOfOrderLineItems { get; set; }
    }
}