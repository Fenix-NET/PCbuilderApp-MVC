using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcBuilderApp.Models
{
    public class Ssd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? MemorySize { get; set; }
        public string? SsdInterface { get; set; }
        public string? SsdResource { get; set; }
        public string? ReadingSpeed { get; set; }
        public string? RecordingSpeed { get; set; }
        public string? Controller { get; set; }
        public string? ChipType { get; set; }
        public string? Format { get; set; }
        public string? Mass { get; set; }
        public decimal? Price { get; set; }
        public string ImageName { get; set; }

    }
}
