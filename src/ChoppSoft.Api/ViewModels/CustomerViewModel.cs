using ChoppSoft.Domain.Models.Customers.Enums;

namespace ChoppSoft.Api.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public EnumDocumentType DocumentType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }

        public ICollection<AddressViewModel> Addresses { get; set; }
    }
}
