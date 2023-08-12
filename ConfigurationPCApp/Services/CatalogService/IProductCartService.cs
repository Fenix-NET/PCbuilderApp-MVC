using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.Services.CatalogService
{
	public interface IProductCartService
	{
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
