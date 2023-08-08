namespace PcBuilderApp.Models
{
    public class Gpu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string? Techproc { get; set; }
        public int? MemorySize { get; set; }
        public string? MemoryType { get; set; }
        public string? HerzMemory { get; set; }
        public string? MaxScreenResolution { get; set; }
        public string? VerDisplayPort { get; set; }
        public string? VerHdmi { get; set; }

        public int? RecommendedPsuPower { get; set; }
        public int? Power { get; set; }
        public string? Mass { get; set; }
        public decimal? Price { get; set; }
        public string ImageName { get; set; }
    }
}
