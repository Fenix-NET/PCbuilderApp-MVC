namespace ConfigurationPCApp.Models
{
    public class RAM
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public ushort Memory { get; set; }
        public string DDR { get; set; }
        public decimal Price { get; set; }

    }
}
