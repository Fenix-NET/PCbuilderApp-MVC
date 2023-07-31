using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PCParser.Models;

namespace PCParser
{
    public class ClassParsGPU : BaseParseClass
    {

       // public List<GPU> _gpus = new();
        //private readonly ParserContext _parserContext;
        //public ClassParsGPU()
        //{
        //    _parserContext = new ParserContext();
        //}
        public async Task StartParseGPU(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга GPU");

            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";
            var powerSelector = "td#tdsa44456";
            var powerSelectorNull = "td#tdsa893";
            var techprocSelector = "td#tdsa3735";
            var memorySelector = "td#tdsa689";
            var memoryTypeSelector = "td#tdsa4187";
            var massSelector = "td#tdsa1672";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                Models.GPU _gpu = new();
                using var doc = GetPage(link);

                _gpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _gpu.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                try
                {
                    _gpu.Power = ushort.Parse(Regex.Replace(doc.QuerySelector(powerSelector).TextContent, @"\D+", ""));
                }
                catch
                {
                    try { _gpu.Power = ushort.Parse(Regex.Replace(doc.QuerySelector(powerSelectorNull).TextContent, @"\D+", "")); }
                    catch { _gpu.Power = 0; }
                }
                _gpu.Techproc = doc.QuerySelector(techprocSelector)?.TextContent ?? "n/a";

                _gpu.Memory = doc.QuerySelector(memorySelector)?.TextContent ?? "n/a";

                _gpu.MemoryType = doc.QuerySelector(memoryTypeSelector)?.FirstChild?.TextContent ?? "n/a";

                _gpu.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _gpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _gpu.Price = 0; }

                Console.WriteLine(_gpu.Manufacturer);
                Console.WriteLine(_gpu.Model);
                Console.WriteLine(_gpu.Power);
                Console.WriteLine(_gpu.Techproc);
                Console.WriteLine(_gpu.Memory);
                Console.WriteLine(_gpu.MemoryType);
                Console.WriteLine(_gpu.Mass);
                Console.WriteLine(_gpu.Price);
                Console.WriteLine(new string('.', 80));

                _context.GPUs.Add(_gpu);
                
            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (GPUparse gpu in _gpus)
            //{
            //    Console.WriteLine(gpu.Manufacturer);
            //    Console.WriteLine(gpu.Model);
            //    Console.WriteLine(gpu.Power);
            //    Console.WriteLine(gpu.Techproc);
            //    Console.WriteLine(gpu.Memory);
            //    Console.WriteLine(gpu.Price);
            //    Console.WriteLine(new string('.', 80));


            //for (int i = 0; i < GPUs.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {GPUs[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {GPUs[i].Model}");
            //    Console.WriteLine($"Потребление энергии : {GPUs[i].Power}");
            //    Console.WriteLine($"Техпроцесс : {GPUs[i].Techproc}");
            //    Console.WriteLine($"Память : {GPUs[i].Memory}");
            //    Console.WriteLine($"Цена : {GPUs[i].Price}");
            //    Console.WriteLine("================================================================");
            //}
        }
    }
}






