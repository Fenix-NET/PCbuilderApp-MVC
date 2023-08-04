namespace PcBuilderApp.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Form { get; set; }
        public string Mass { get; set; }
        public string Materials { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ImageCaseId { get; set; }
        public ImageCase imageCase { get; set; }
    }
}
