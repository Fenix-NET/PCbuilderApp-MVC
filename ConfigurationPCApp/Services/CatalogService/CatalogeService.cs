using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.Models;
using PcBuilderApp.Models.DTOs;
using static NuGet.Packaging.PackagingConstants;

namespace PcBuilderApp.Services.CatalogService
{
    public class CatalogeService : ICatalogService
    {

        private readonly IMapper _mapper;
        private readonly PcBuilderContext _context;
        public CatalogeService(IMapper mapper, PcBuilderContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<CpuDto>> GetAllCpu()
        {

           
                        //.Select(dto => _mapper.Map<CPUsDTO>(dto)).ToListAsync();

            var dbCpu = await _context.Cpus
                        .Include(im => im.ImageCpu).Select(cp => _mapper.Map<CpuDto>(cp)).ToListAsync();
            //.Where(cpu => cpu.Price != 0)
            //.Include(img => img.ImageCPUId).Select(img => _mapper.Map<CPUsDTO> (img))
            //.ToListAsync();
            //var dbCpu = await _context.ImageCPUs
            //               .Select(dto => _mapper.Map<CPUsDTO>(dto)).ToListAsync();



            return dbCpu;
           

        }
    }
}
