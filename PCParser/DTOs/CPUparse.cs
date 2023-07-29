using System.ComponentModel.DataAnnotations.Schema;

namespace PCParser.DTOs
{
    public class CPUparse
    {
        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public string? Hherz { get; set; }

        public string? Socket { get; set; }

        public decimal Price { get; set; }

    }
}
