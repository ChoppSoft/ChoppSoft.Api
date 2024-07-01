using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Addresses
{
    public class Address : Entity
    {
        public Guid CustomerId { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string AdditionalInformation { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public bool IsDefault { get; private set; }

        public Customer Customer { get; private set; }
    }
}
