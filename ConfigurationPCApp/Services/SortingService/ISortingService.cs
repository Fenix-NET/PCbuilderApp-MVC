using Microsoft.AspNetCore.Mvc;
using PcBuilderApp.DTOs.CatalogDto;
using PcBuilderApp.DTOs;

namespace PcBuilderApp.Services.SortingService
{
    public interface ISortingService
    {

        Task<CatalogResponse<List<ProductDto>>> Pagination(CatalogRequest catalogRequest, string sort); 
        //Task<IActionResult> SortBy(string sortBy);

    }
}
