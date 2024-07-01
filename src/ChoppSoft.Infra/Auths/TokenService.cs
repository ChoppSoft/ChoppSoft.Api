using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChoppSoft.Infra.Auths
{
    public static class TokenService
    {
        public const string KEY = "$2a$10$d8FYDot2awwGu5WX/mAmpOXKYYKVoVRVwD98LFK3sCv7eIyCxhcny";

        public static (string Token, DateTime Expires) GenerateToken(Guid id, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KEY);
            var expires = DateTime.UtcNow.AddHours(48);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim("user_id", id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), expires);
        }
    }
}
