namespace ChoppSoft.Domain.Models.Resources.Services.Dtos
{
    public record ResourceDto(string description,
                              string model,
                              string licenseplate,
                              double capacity,
                              bool isowned);
}
