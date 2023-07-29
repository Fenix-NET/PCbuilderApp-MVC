using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCParser.DTOs
{
    public class Case
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Form { get; set; }
        public string Mass { get; set; }
        public string Materials { get; set; }
        public decimal Price { get; set; }
    }
}
