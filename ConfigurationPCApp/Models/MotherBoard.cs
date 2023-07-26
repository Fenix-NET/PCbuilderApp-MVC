using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationPCApp.Models
{
    public class MotherBoard
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }
        [ForeignKey(nameof(CPU))]
        public string Socket { get; set; }

        public string Form { get; set; }
        public decimal Price { get; set; }

    }
}
