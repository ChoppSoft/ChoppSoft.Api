using ChoppSoft.Infra.Bases;
using ChoppSoft.Infra.Extensions;

namespace ChoppSoft.Domain.Models.Users
{
    public sealed class User : Entity
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; } = "employee";

        internal string GenerateNewPassword()
        {
            var chars = "abcdefghjkmnpqrstuvwxyz023456789!@#$%&*";
            var password = string.Empty;
            var random = new Random();

            for (int f = 0; f < 8; f++)
            {
                password += chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return password;
        }

        internal void ChangePassword(string newPassword) => Password = newPassword.EncodePassword();

        internal void ChangeRole(string newRole) => Role = newRole;
    }
}
