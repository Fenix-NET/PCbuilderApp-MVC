namespace ConfigurationPCApp.Models
{
    public class PSU
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public ushort Power { get; set; }
        public decimal Price { get; set; }
    }
}
