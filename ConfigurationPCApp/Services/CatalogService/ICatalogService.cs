using Microsoft.EntityFrameworkCore;
using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<List<ProductDto>> GetAllCpuProducts();
        Task<List<ProductDto>> GetAllGpuProducts();
        Task<List<ProductDto>> GetAllMotherboardProducts();
        Task<List<ProductDto>> GetAllRamProducts();
        Task<List<ProductDto>> GetAllHddProducts();
        Task<List<ProductDto>> GetAllSsdProducts();
        Task<List<ProductDto>> GetAllPsuProducts();
        Task<List<ProductDto>> GetAllCaseProducts();


    }
}
