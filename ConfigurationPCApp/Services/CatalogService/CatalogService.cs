using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.Services.CatalogService
{
    public class CatalogService : ICatalogService
    {

        private readonly IMapper _mapper;
        private readonly PcBuilderContext _context;
        public CatalogService(IMapper mapper, PcBuilderContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllCpuProducts()
        {
            return await _context.Cpu.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllGpuProducts()
        {
            return await _context.Gpu.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllMotherboardProducts()
        {
            return await _context.Motherboards.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllRamProducts()
        {
            return await _context.Ram.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllHddProducts()
        {
            return await _context.Hdd.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllSsdProducts()
        {
            return await _context.Ssd.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllPsuProducts()
        {
            return await _context.Psu.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }
        public async Task<List<ProductDto>> GetAllCaseProducts()
        {
            return await _context.Case.Select(dto => _mapper.Map<ProductDto>(dto)).ToListAsync();
        }

        public async Task<CpuDto> GetProductCartCpu(int id)
        {
            
            return await _context.Cpu.Where(p => p.Id == id).Select(dto => _mapper.Map<CpuDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<GpuDto> GetProductCartGpu(int id)
        {
            return await _context.Gpu.Where(p => p.Id == id).Select(dto => _mapper.Map<GpuDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<MotherboardDto> GetProductCartMother(int id)
        {
            return await _context.Motherboards.Where(p => p.Id == id).Select(dto => _mapper.Map<MotherboardDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<RamDto> GetProductCartRam(int id)
        {
            return await _context.Ram.Where(p => p.Id == id).Select(dto => _mapper.Map<RamDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<HddDto> GetProductCartHdd(int id)
        {
            return await _context.Hdd.Where(p => p.Id == id).Select(dto => _mapper.Map<HddDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<SsdDto> GetProductCartSsd(int id)
        {
            return await _context.Ssd.Where(p => p.Id == id).Select(dto => _mapper.Map<SsdDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<PsuDto> GetProductCartPsu(int id)
        {
            return await _context.Psu.Where(p => p.Id == id).Select(dto => _mapper.Map<PsuDto>(dto)).FirstOrDefaultAsync();
        }
        public async Task<CaseDto> GetProductCartCase(int id)
        {
            return await _context.Case.Where(p => p.Id == id).Select(dto => _mapper.Map<CaseDto>(dto)).FirstOrDefaultAsync();
        }

    }
}
