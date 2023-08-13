using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.DTOs
{
    public class CatalogRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public SortDto Sort { get; set; }

    }
}
