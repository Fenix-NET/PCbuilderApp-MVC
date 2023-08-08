namespace PcBuilderApp.Models
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string? Chipset { get; set; }
        public string? MemoryType { get; set; }
        public int? MemorySlots { get; set; }
        public string? MaxMemoryHerz { get; set; }
        public int? MaxMemorySize { get; set; }
        public string Socket { get; set; }
        public byte? NumM2 { get; set; }
        public string Form { get; set; }
        public string? Mass { get; set; }
        public decimal? Price { get; set; }
        public string ImageName { get; set; }

    }
}
