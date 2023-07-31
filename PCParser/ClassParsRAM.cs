using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PCParser.Models;

namespace PCParser
{
    public class ClassParsRAM : BaseParseClass
    {
       // public List<RAM> _rams = new();
        //private readonly ParserContext _parserContext;
        //public ClassParsRAM()
        //{
        //    _parserContext = new ParserContext();
        //}
        public async Task StartParseRAM(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга RAM");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                
            var MemorySelector = "td#tdsa3360";
            var NmodulSelector = "td#tdsa4273";
            var DDRSelector = "td#tdsa2510";
            var massSelector = "td#tdsa1672";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                Models.RAM _ram = new();
                using var doc = GetPage(link);

                _ram.Manufacturer =  doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _ram.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _ram.DDR = doc.QuerySelector(DDRSelector)?.FirstChild?.TextContent ?? "n/a";

                try {_ram.Memory = ushort.Parse(Regex.Replace(doc.QuerySelector(MemorySelector).FirstChild.TextContent, @"\D+", "")); }
                catch (Exception ex) { _ram.Memory = 0; }

                try {_ram.Nmodule =  byte.Parse(doc.QuerySelector(NmodulSelector)?.FirstChild.TextContent); }
                catch(Exception ex) { _ram.Nmodule = 0;}

                _ram.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _ram.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _ram.Price = 0; }

                Console.WriteLine(_ram.Manufacturer);
                Console.WriteLine(_ram.Model);
                Console.WriteLine(_ram.DDR);
                Console.WriteLine(_ram.Memory);
                Console.WriteLine(_ram.Nmodule);
                Console.WriteLine(_ram.Mass);
                Console.WriteLine(_ram.Price);
                Console.WriteLine(new string('.', 80));

                _context.RAMs.Add(_ram);
                
            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (RAMparse ram in _rams)
            //{
            //    Console.WriteLine(ram.Manufacturer);
            //    Console.WriteLine(ram.Model);
            //    Console.WriteLine(ram.DDR);
            //    Console.WriteLine(ram.Memory);
            //    Console.WriteLine(ram.Price);
            //    Console.WriteLine(new string('.', 80));
            //}
            //for (int i = 0; i < RAMs.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {RAMs[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {RAMs[i].Model}");
            //    Console.WriteLine($"Объем памяти : {RAMs[i].Memory}");
            //    Console.WriteLine($"Тип памяти : {RAMs[i].DDR}");
            //    Console.WriteLine($"Цена : {RAMs[i].Price}");
            //    Console.WriteLine("================================================================");
            //}

        }



    }
}
