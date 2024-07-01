using ChoppSoft.Domain.Models.Customers.Enums;

namespace ChoppSoft.Domain.Models.Customers.Services.Dtos
{
    public record CustomerDto(string name,
                              string document,
                              EnumDocumentType documenttype,
                              string phonenumber,
                              string email,
                              DateTime dateofbirth);
}
