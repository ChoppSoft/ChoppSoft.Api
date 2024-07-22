namespace ChoppSoft.Infra.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToBrazilianDateFormat(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
