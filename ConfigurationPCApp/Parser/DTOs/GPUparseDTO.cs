using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp.Parser.DTOs
{
    public class GPUparseDTO
    {
        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public ushort Power { get; set; }
        public decimal Price { get; set; }
    }
}
