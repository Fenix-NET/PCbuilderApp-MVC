using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuilderApp.Models
{
    public class Cpu
    {
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string Name { get; set; }

        public string? Model { get; set; }

        public string? Hherz { get; set; }

        public sbyte Core { get; set; }

        public sbyte Streams { get; set; }

        public string? Socket { get; set; }
        public string Mass { get; set; }

        public decimal Price { get; set; }
        public string Image { get; set; }

        public int ImageCpuId { get; set; }

        public ImageCpu ImageCpu { get; set; }

    }
}
