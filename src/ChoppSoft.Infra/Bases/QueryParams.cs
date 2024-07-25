namespace ChoppSoft.Infra.Bases
{
    public class QueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public string Filters { get; set; } = null;
        public string OrderBy { get; set; } = null;
    }
}
