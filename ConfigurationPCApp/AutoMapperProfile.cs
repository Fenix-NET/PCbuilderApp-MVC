using AutoMapper;
using PcBuilderApp.DTOs.CatalogDto;
using PcBuilderApp.Models;

namespace PcBuilderApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cpu, ProductDto>();
            CreateMap<Gpu, ProductDto>();
            CreateMap<Motherboard, ProductDto>();
            CreateMap<Ram, ProductDto>();
            CreateMap<Hdd, ProductDto>();
            CreateMap<Ssd, ProductDto>();
            CreateMap<Psu, ProductDto>();
            CreateMap<Case, ProductDto>();
            CreateMap<Cpu, CpuDto>();
            CreateMap<Gpu, GpuDto>();
            CreateMap<Motherboard, MotherboardDto>();
            CreateMap<Ram, RamDto>();
            CreateMap<Hdd, HddDto>();
            CreateMap<Ssd, SsdDto>();
            CreateMap<Psu, PsuDto>();
            CreateMap<Case, CaseDto>();
        }

    }
}
