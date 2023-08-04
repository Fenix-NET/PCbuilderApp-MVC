using PcBuilderApp.Models.DTOs;

namespace PcBuilderApp.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<List<CpuDto>> GetAllCpu();



    }
}
