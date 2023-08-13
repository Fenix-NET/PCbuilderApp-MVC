using Microsoft.AspNetCore.Mvc;
using PcBuilderApp.DTOs.CatalogDto;
using PcBuilderApp.DTOs;

namespace PcBuilderApp.Services.SortingService
{
    public interface ISortingService
    {

        Task<CatalogResponse<List<ProductDto>>> Pagination(int? size, int num); 
        //Task<IActionResult> SortBy(string sortBy);

    }
}
