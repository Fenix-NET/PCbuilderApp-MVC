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
    }
}
