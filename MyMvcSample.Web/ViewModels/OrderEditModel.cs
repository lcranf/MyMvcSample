using MyMvcSample.Common.ViewModels;

namespace MyMvcSample.ViewModels
{
    public class OrderEditModel : BaseOrderModel, IEditModel
    {
        public int Id { get; set; }
    }
}