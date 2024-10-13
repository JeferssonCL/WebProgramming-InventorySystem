namespace MerchantService.Application.Dtos
{
    public class PageDto<T>
    {
        public IEnumerable<T> Data { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages { get; }

        public PageDto(IEnumerable<T> data, int totalItems, int page, int pageSize)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            TotalItems = totalItems;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
