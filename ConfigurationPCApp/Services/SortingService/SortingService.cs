using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.DTOs;
using PcBuilderApp.DTOs.CatalogDto;
using PcBuilderApp.Services.SortingService;

namespace PcBuilderApp.Services.SortingService
{
    public class SortingService : ISortingService
    {
        private readonly PcBuilderContext _context;
        private readonly IMapper _mapper;
        public SortingService(PcBuilderContext pcBuilderContext, IMapper mapper)
        {
            _context = pcBuilderContext;
            _mapper = mapper;
        }
        private int PageSize20 { get; } = 20;
        private int PageSize50 { get; } = 50;
        private int PageSize100 { get; } = 100;
        //public Task<IActionResult> SortBy(string sortBy)
        //{

        //}
        public async Task<CatalogResponse<List<ProductDto>>> Pagination(int? size, int num)
        {
            CatalogResponse<List<ProductDto>> catalogResponse = new();
            if (size == PageSize20)
            {
                
                int count = _context.Case.AsNoTracking().Count();
                var dto = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((num - 1) * PageSize20)
                            .Take(PageSize20)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                catalogResponse.CurrentPageSize = size;
                catalogResponse.Data = dto;
                catalogResponse.NumberOfPages = count / PageSize20;
                return catalogResponse;
            }
            if (size == PageSize50)
            {
                
                int count = _context.Case.AsNoTracking().Count();
                var dto = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((num - 1) * PageSize50)
                            .Take(PageSize50)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                catalogResponse.CurrentPageSize = size;
                catalogResponse.Data = dto;
                catalogResponse.NumberOfPages = count / PageSize50;
                return catalogResponse;
            }
            if (size == PageSize100)
            {
                
                int count = _context.Case.AsNoTracking().Count();
                var dto = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((num - 1) * PageSize100)
                            .Take(PageSize100)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                catalogResponse.CurrentPageSize = size;
                catalogResponse.Data = dto;
                catalogResponse.NumberOfPages = count / PageSize100;
                return catalogResponse;
            }
            catalogResponse.Success = false;
            return catalogResponse;
        }


    }

}
