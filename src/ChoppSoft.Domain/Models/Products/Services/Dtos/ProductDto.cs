namespace ChoppSoft.Domain.Models.Products.Services.Dtos
{
    public record ProductDto(string identifier,
                             string description,
                             string brand,
                             double capacity,
                             decimal price);
}
