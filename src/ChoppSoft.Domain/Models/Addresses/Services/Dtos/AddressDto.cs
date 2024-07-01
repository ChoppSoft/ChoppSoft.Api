namespace ChoppSoft.Domain.Models.Addresses.Services.Dtos
{
    public record AddressDto(Guid customerid,
                             string street,
                             string number,
                             string additionalinformation,
                             string district,
                             string city,
                             string state,
                             string postalcode,
                             string country);
}
