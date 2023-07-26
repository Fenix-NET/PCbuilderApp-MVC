using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationPCApp.Models
{
    public class CPUparse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Socket { get; set; }

        public decimal Price { get; set; }


    }
}
