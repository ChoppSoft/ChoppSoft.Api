namespace ChoppSoft.Infra.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToMonetary(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
