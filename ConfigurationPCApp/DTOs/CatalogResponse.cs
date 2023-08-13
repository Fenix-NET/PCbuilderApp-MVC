namespace PcBuilderApp.DTOs
{
    public class CatalogResponse<T>
    {
        public T Data { get; set; }
        public int NumberOfPages { get; set; }
        public int? CurrentPageSize { get; set; }

        public bool Success { get; set; } = true;

    }
}
