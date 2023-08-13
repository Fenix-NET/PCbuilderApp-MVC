using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PcBuilderApp.DTOs;
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
        Task<CatalogResponse<List<ProductDto>>> GetAllCaseProducts();
        Task<CpuDto> GetProductCartCpu(int id);
        Task<GpuDto> GetProductCartGpu(int id);
        Task<MotherboardDto> GetProductCartMother(int id);
        Task<RamDto> GetProductCartRam(int id);
        Task<HddDto> GetProductCartHdd(int id);
        Task<SsdDto> GetProductCartSsd(int id);
        Task<PsuDto> GetProductCartPsu(int id);
        Task<CaseDto> GetProductCartCase(int id);


    }
}
