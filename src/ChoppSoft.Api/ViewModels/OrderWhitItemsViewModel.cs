namespace ChoppSoft.Api.ViewModels
{
    public class OrderWhitItemsViewModel : OrderViewModel
    {
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
