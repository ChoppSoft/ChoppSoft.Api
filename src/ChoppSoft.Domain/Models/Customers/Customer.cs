using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Customers.Enums;
using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Customers
{
    public sealed class Customer : Entity
    {
        public Customer(string name,
                        string document,
                        EnumDocumentType documentType,
                        string phoneNumber,
                        string email,
                        DateTime dateOfBirth)
        {
            Name = name;
            Document = document;
            DocumentType = documentType;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;

            Addresses = new List<Address>();
        }

        public Customer() { }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public EnumDocumentType DocumentType { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime BirthDay => new DateTime(DateTime.Now.Year, DateOfBirth.Month, DateOfBirth.Day).Date;

        public ICollection<Address> Addresses { get; set; }

        internal void Update(CustomerDto dto)
        {
            Name = dto.name;
            Document = dto.document;
            DocumentType = dto.documenttype;
            PhoneNumber = dto.phonenumber;
            Email = dto.email;
            DateOfBirth = dto.dateofbirth;
        }
    }
}
