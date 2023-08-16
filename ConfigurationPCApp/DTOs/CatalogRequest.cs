using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.DTOs
{
    public class CatalogRequest
    {
        public int? PageSize { get; set; }
        public int PageNumber { get; set; } = 1;
        public string Sort { get; set; } = "Default";

    }
}
