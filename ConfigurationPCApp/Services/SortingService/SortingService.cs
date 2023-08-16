using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.DTOs;
using PcBuilderApp.DTOs.CatalogDto;
using PcBuilderApp.Services.SortingService;
using System.Linq;

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
        public async Task<CatalogResponse<List<ProductDto>>> Pagination(CatalogRequest catalogRequest, string sort)
        {
            CatalogResponse<List<ProductDto>> catalogResponse = new();
            int count = _context.Case.AsNoTracking().Count();
            if (catalogRequest.PageSize == PageSize20)
            {
                switch(sort)
                {
                    case ("MinPrice"):
                           var dto = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Price)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize20)
                            .Take(PageSize20)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                            catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto;
                        catalogResponse.NumberOfPages = count / PageSize20;
                        return catalogResponse;

                    case ("MaxPrice"):
                        var dto2 = await _context.Case.AsNoTracking()
                            .OrderByDescending(p => p.Price)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize20)
                            .Take(PageSize20)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto2;
                        catalogResponse.NumberOfPages = count / PageSize20;
                        return catalogResponse;

                    case ("Default"):
                        var dto3 = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize20)
                            .Take(PageSize20)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto3;
                        catalogResponse.NumberOfPages = count / PageSize20;
                        return catalogResponse;
                }
                
            }
            if (catalogRequest.PageSize == PageSize50)
            {
                switch (sort)
                {
                    case ("MinPrice"):
                        var dto = await _context.Case.AsNoTracking()
                         .OrderBy(p => p.Price)
                         .Skip((catalogRequest.PageNumber - 1) * PageSize50)
                         .Take(PageSize50)
                         .Select(p => _mapper.Map<ProductDto>(p))
                         .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto;
                        catalogResponse.NumberOfPages = count / PageSize50;
                        return catalogResponse;

                    case ("MaxPrice"):
                        var dto2 = await _context.Case.AsNoTracking()
                            .OrderByDescending(p => p.Price)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize50)
                            .Take(PageSize50)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto2;
                        catalogResponse.NumberOfPages = count / PageSize50;
                        return catalogResponse;

                    case ("Default"):
                        var dto3 = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize50)
                            .Take(PageSize50)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto3;
                        catalogResponse.NumberOfPages = count / PageSize50;
                        return catalogResponse;
                }
            }
            if (catalogRequest.PageSize == PageSize100)
            {

                switch (sort)
                {
                    case ("MinPrice"):
                        var dto = await _context.Case.AsNoTracking()
                         .OrderBy(p => p.Price)
                         .Skip((catalogRequest.PageNumber - 1) * PageSize100)
                         .Take(PageSize100)
                         .Select(p => _mapper.Map<ProductDto>(p))
                         .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto;
                        catalogResponse.NumberOfPages = count / PageSize100;
                        return catalogResponse;

                    case ("MaxPrice"):
                        var dto2 = await _context.Case.AsNoTracking()
                            .OrderByDescending(p => p.Price)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize100)
                            .Take(PageSize100)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto2;
                        catalogResponse.NumberOfPages = count / PageSize100;
                        return catalogResponse;

                    case ("Default"):
                        var dto3 = await _context.Case.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Skip((catalogRequest.PageNumber - 1) * PageSize100)
                            .Take(PageSize100)
                            .Select(p => _mapper.Map<ProductDto>(p))
                            .ToListAsync();
                        catalogResponse.CurrentPageSize = catalogRequest.PageSize;
                        catalogResponse.Data = dto3;
                        catalogResponse.NumberOfPages = count / PageSize100;
                        return catalogResponse;
                }
            }
            
                catalogResponse.Success = false;
                return catalogResponse;
            
        }


    }

}
