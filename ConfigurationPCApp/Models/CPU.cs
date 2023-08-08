using Npgsql.Internal.TypeHandlers;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuilderApp.Models
{
    public class Cpu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manufacturer { get; set; }

        public string Model { get; set; }

        public string? Hherz { get; set; }

        public int? Core { get; set; }

        public int? Streams { get; set; }

        public string? Socket { get; set; }
        public string? IntegratedGraphics { get; set; }
        public string? MemoryType { get; set; }
        public string? MaxMemoryType { get; set; }
        public int? MaxMemorySize { get; set; }

        public string? CriticalTemp { get; set; }
        public string? Mass { get; set; }

        public decimal? Price { get; set; }
        public string ImageName { get; set; }

    }
}
