using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Customers.Enums;
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
        }

        public Customer() { }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public EnumDocumentType DocumentType { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
