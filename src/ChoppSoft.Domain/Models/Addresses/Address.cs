using ChoppSoft.Domain.Models.Addresses.Services.Dtos;
using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Addresses
{
    public sealed class Address : Entity
    {
        public Address(Guid customerId, 
                       string street, 
                       string number, 
                       string additionalInformation, 
                       string district, 
                       string city, 
                       string state, 
                       string postalCode, 
                       string country)
        {
            CustomerId = customerId;
            Street = street;
            Number = number;
            AdditionalInformation = additionalInformation;
            District = district;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        public Address() { }

        public Guid CustomerId { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string AdditionalInformation { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public bool IsDefault { get; private set; } = false;

        public Customer Customer { get; private set; }

        internal void Update(AddressDto dto)
        {
            Street = dto.street;
            Number = dto.number;
            AdditionalInformation = dto.additionalinformation;
            District = dto.district;
            City = dto.city;
            State = dto.state;
            PostalCode = dto.postalcode;
            Country = dto.country;
        }

        internal void SetAsDefault()
        {
            IsDefault = true;
        }
    }
}
