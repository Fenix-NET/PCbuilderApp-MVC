using AutoMapper;
using PcBuilderApp.Models;
using PcBuilderApp.Models.DTOs;

namespace PcBuilderApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cpu,CpuDto>();
            CreateMap<ImageCpu,CpuDto>();

        }

    }
}
