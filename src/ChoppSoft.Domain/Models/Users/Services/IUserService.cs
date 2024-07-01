using ChoppSoft.Domain.Models.Users.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Users.Services
{
    public interface IUserService
    {
        Task<ServiceResult> GetUser(UserDto model);
        Task<ServiceResult> Register(UserDto model);
        Task<ServiceResult> ChangePassword(ChangePasswordDto model);
        Task<ServiceResult> GetById(Guid id);
    }
}
