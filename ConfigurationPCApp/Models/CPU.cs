using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationPCApp.Models
{
    public class CPU
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        [ForeignKey(nameof(MotherBoardParseDTO))]
        public string Socket { get; set; }

        public decimal Price { get; set; }


    }
}
