using ChoppSoft.Infra.Bases;
using Newtonsoft.Json;
using static BCrypt.Net.BCrypt;

namespace ChoppSoft.Infra.Extensions
{
    public static class StringExtension
    {
        private const int WorkFactor = 10;

        public static string EncodePassword(this string password)
        {
            return HashPassword(password, WorkFactor);
        }

        public static bool VerifyPassword(this string hashPassword, string password)
        {
            return Verify(password, hashPassword);
        }

        public static List<Filter> CreateFilters(this string filters)
        {
            if (string.IsNullOrWhiteSpace(filters))
                return new List<Filter>();

            return JsonConvert.DeserializeObject<List<Filter>>(filters);
        }
    }
}
