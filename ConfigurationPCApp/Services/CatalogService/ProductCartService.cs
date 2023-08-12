using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.DTOs.CatalogDto;

namespace PcBuilderApp.Services.CatalogService
{
	public class ProductCartService/* : IProductCartService*/
	{
		private readonly PcBuilderContext _context;
        private readonly IMapper _mapper;

        public ProductCartService(PcBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        //public async Task<CpuDto> GetProductCartCpu(int id)
        //{
        //    var cpu = await yr.Where(p => p.Id == id).Select(dto => _mapper.Map<CpuDto>(dto)).FirstOrDefaultAsync();
        //    if (cpu == null) { return NotFound; }
        //    return
        //}

        //public async Task<GpuDto> GetProductCartGpu(int id)
        //{
        //    var gpu = await _context.Gpu.Where(p => p.Id == id).Select(dto => _mapper.Map<GpuDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}
        //public async Task<MotherboardDto> GetProductCartMother(int id)
        //{
        //    var mother = await _context.Motherboards.Where(p => p.Id == id).Select(dto => _mapper.Map<MotherboardDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}
        //public async Task<RamDto> GetProductCartRam(int id)
        //{
        //    var ram = await _context.Ram.Where(p => p.Id == id).Select(dto => _mapper.Map<RamDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}

        //public async Task<HddDto> GetProductCartHdd(int id)
        //{
        //    var hdd = await _context.Hdd.Where(p => p.Id == id).Select(dto => _mapper.Map<HddDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}

        //public async Task<SsdDto> GetProductCartSsd(int id)
        //{
        //    var ssd = await _context.Ssd.Where(p => p.Id == id).Select(dto => _mapper.Map<SsdDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}

        //public async Task<PsuDto> GetProductCartPsu(int id)
        //{
        //    var psu = await _context.Psu.Where(p => p.Id == id).Select(dto => _mapper.Map<PsuDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}

        //public async Task<CaseDto> GetProductCartCase(int id)
        //{
        //    var _case = await _context.Case.Where(p => p.Id == id).Select(dto => _mapper.Map<CaseDto>(dto)).FirstOrDefaultAsync();
            
        //    return 
        //}
    }
}
