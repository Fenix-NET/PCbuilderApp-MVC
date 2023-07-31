using System.ComponentModel.DataAnnotations.Schema;

namespace PCBuilderApp.Parser.DTOs
{
    public class MotherBoardParseDTO
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Socket { get; set; }
        public string Form { get; set; }
        public decimal Price { get; set; }
    }
}
