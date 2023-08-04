namespace PcBuilderApp.Models
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Socket { get; set; }
        public string Form { get; set; }
        public string Mass { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ImageMotherboardId { get; set; }
        public ImageMotherboard imageMotherboard { get; set; }

    }
}
