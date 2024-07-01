namespace ChoppSoft.Domain.Models.Users.Services.Dtos
{
    public record ChangePasswordDto(string Email, string OldPassword, string NewPassword);
}
