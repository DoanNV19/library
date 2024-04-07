namespace LibApp.Application.Models.Responses
{
    public class PagerRes<T>
    {
        public int TotalPage => (int)(TotalRecord / PageSize + (TotalRecord % PageSize > 0 ? 1 : 0));

        public object Data { get; set; }

        public long TotalRecord { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public int? Total { get; set; }
    }
}
