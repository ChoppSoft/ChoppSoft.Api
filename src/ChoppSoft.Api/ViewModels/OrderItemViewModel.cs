namespace ChoppSoft.Api.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductDescription { get; set; }
    }
}
