namespace PCParser.Models
{
    public class GPU
    {
        public int Id { get; set; }
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
