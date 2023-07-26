using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationPCApp.Parser.DTOs
{
    public class CPUparseDTO
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Socket { get; set; }

        public decimal Price { get; set; }


    }
}
