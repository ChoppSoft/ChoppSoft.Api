using ChoppSoft.Domain.Models.Customers;

namespace ChoppSoft.Api.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalInformation { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
