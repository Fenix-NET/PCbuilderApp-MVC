using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCParser.DTOs
{
    public class GPUparse
    {
        public string? Manufacturer { get; set; }

        public string? Model { get; set; }
        public string Techproc { get; set; }
        public string Memory { get; set; }

        public string MemoryType { get; set; }
        public ushort Power { get; set; }
        public string Mass { get; set; }
        public decimal Price { get; set; }
    }
}
