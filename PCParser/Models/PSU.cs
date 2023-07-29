using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCParser.Models
{
    public class PSU
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public ushort Power { get; set; }
        public string Mass { get; set; }

        public string Sertificate { get; set; }
        public decimal Price { get; set; }

    }
}
