namespace ChoppSoft.Domain.Models.Resources.Services.Dtos
{
    public record ResourceDto(string description,
                              string model,
                              string licenseplate,
                              decimal capacity,
                              bool isowned);
}
