namespace MyMvcSample.ViewModels
{
    public class OrderViewModel : BaseOrderModel
    {
        public int Id { get; set; }

        public int NumOfOrderLineItems { get; set; }
    }
}