namespace ChoppSoft.Api.ViewModels
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}
