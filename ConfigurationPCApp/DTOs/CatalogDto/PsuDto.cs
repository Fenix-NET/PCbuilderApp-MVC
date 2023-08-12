using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcBuilderApp.DTOs.CatalogDto
{
    public class PsuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        public string? Herz { get; set; }
        public string? LenghtCable { get; set; }

        public int? Power { get; set; }
        public string? Sertificate { get; set; }
        public string? ConnectorMotherboard { get; set; }
        public string? ConnectorGpu { get; set; }
        public string? Size { get; set; }
        public string? Mass { get; set; }
        public decimal? Price { get; set; }
        public string ImageName { get; set; }

    }
}
