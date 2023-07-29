using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PCParser.DTOs;
using System.Diagnostics.Metrics;

namespace PCParser
{
    internal class ClassParsGPU : BaseParseClass
    {

        public List<GPUparse> _gpus = new();
        public async Task StartParseGPU()
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга GPU");

            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 
            var powerSelector = "td#tdsa44456";
            var powerSelectorNull = "td#tdsa893";
            var techprocSelector = "td#tdsa3735";
            var memorySelector = "td#tdsa689";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                GPUparse _gpu = new();
                using var doc = GetPage(link);

                _gpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _gpu.Model = doc.QuerySelector(modelSelector).FirstChild?.TextContent ?? "n/a";

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

                try { _gpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _gpu.Price = 0; }

                Console.WriteLine(_gpu.Manufacturer);
                Console.WriteLine(_gpu.Model);
                Console.WriteLine(_gpu.Power);
                Console.WriteLine(_gpu.Techproc);
                Console.WriteLine(_gpu.Memory);
                Console.WriteLine(_gpu.Price);
                Console.WriteLine(new string('.', 80));

                _gpus.Add(_gpu);
            }
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
            }

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





