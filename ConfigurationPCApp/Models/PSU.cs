using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcBuilderApp.Models
{
    public class Psu
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }

        public string Model { get; set; }

        public ushort Power { get; set; }
        public string Mass { get; set; }

        public string Sertificate { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ImagePsuId { get; set; }
        public ImagePsu imagePsu { get; set; }

    }
}
