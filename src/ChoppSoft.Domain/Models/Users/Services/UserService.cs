using ChoppSoft.Domain.Interfaces.Inventories;
using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Models.Users.Services.Dtos;
using ChoppSoft.Infra.Auths;
using ChoppSoft.Infra.Bases;
using ChoppSoft.Infra.Extensions;
using System.Net.Mail;

namespace ChoppSoft.Domain.Models.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult> GetUser(UserDto model)
        {
            var user = await _userRepository.Get(model.Email, model.Password);

            if (user is null)
                return ServiceResult.Failed("Usuário ou senha inválidos.");

            var token = TokenService.GenerateToken(user.Id, user.Email, user.Role);

            return ServiceResult.Successful(new
            {
                User = user.Name,
                Email = user.Email,
                Token = $"Bearer {token.Token}",
                Expires = token.Expires
            });
        }

        public async Task<ServiceResult> Register(UserDto model)
        {
            if (string.IsNullOrEmpty(model.Email) || !MailAddress.TryCreate(model.Email, out var _))
                return ServiceResult.Failed($"E-mail inválido '{model.Email}'");

            var user = await _userRepository.Get(model.Email) ?? await _userRepository.Get(model.Email, false);

            if (user is not null)
                return ServiceResult.Failed($"Já existe um usuário cadastrado para o e-mail '{model.Email}'", new { Id = user.Id });

            user = new User(model.Name, model.Email, model.Password.EncodePassword());
            await _userRepository.Add(user);

            return ServiceResult.Successful($"Usuário criado com sucesso.");
        }

        public async Task<ServiceResult> ChangePassword(ChangePasswordDto model)
        {
            if (string.IsNullOrEmpty(model.Email) || !MailAddress.TryCreate(model.Email, out var _))
                return ServiceResult.Failed($"E-mail inválido '{model.Email}'.");

            if (model.OldPassword == model.NewPassword)
                return ServiceResult.Failed("A nova senha não pode ser igual a anterior.");

            var user = await _userRepository.Get(model.Email, model.OldPassword);

            if (user is null)
                return ServiceResult.Failed($"Não encontramos um registro para o e-mail '{model.Email}'.");

            user.ChangePassword(model.NewPassword);

            await _userRepository.Update(user);

            return ServiceResult.Successful("Senha alterada com sucesso.");
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if(user is null)
                return ServiceResult.Failed($"Não encontramos um registro para o id '{id}'.");

            return ServiceResult.Successful(new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Role,
                user.Active,
                user.CreatedAt
            });
        }

        public async Task<ServiceResult> SetAsManager(Guid UserId)
        {
            var user = await _userRepository.GetById(UserId);

            if (user is null)
                return ServiceResult.Failed($"Não encontramos um registro para o id '{UserId}'.");

            user.ChangeRole("manager");

            await _userRepository.Update(user);

            return ServiceResult.Successful("Usuário definido como administrador.");
        }

        public async Task<ServiceResult> SetAsEmployee(Guid UserId)
        {
            var user = await _userRepository.GetById(UserId);

            if (user is null)
                return ServiceResult.Failed($"Não encontramos um registro para o id '{UserId}'.");

            user.ChangeRole("employee");

            await _userRepository.Update(user);

            return ServiceResult.Successful("Usuário definido como funcionário.");
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var users = await _userRepository.GetAll(page, pageSize);

            return ServiceResult.Successful(users.Select(user => new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Role,
                user.Active,
                user.CreatedAt
            }));
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}