using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcBuilderApp.DTOs.CatalogDto
{
    public class HddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? MemorySize { get; set; }
        public string? SpindleSpeed { get; set; }
        public string? HddInterface { get; set; }
        public string? InterfaceBandwidth { get; set; }
        public string? Format { get; set; }
        public string? Mass { get; set; }
        public decimal? Price { get; set; }
        public string ImageName { get; set; }

    }
}
