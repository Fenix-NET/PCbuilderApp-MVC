using AngleSharp.Html.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using System.Text.RegularExpressions;
using PCParser.DTOs;

namespace PCParser
{
    public class ClassParsCPU : BaseParseClass
    {
        public List<CPUparse> _cpus = new();
        public async Task StartParsCPU()
        {
            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга CPU");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";
            var hherzSelector = "td#tdsa3808";
            var socketSelector = "td#tdsa1307";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                CPUparse _cpu = new();
                using var doc = GetPage(link);

                _cpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _cpu.Model = doc.QuerySelector(modelSelector).FirstChild?.TextContent ?? "n/a";

                _cpu.Hherz = doc.QuerySelector(hherzSelector)?.FirstChild?.TextContent ?? "n/a";

                _cpu.Socket = doc.QuerySelector(socketSelector).FirstChild?.TextContent ?? "n/a";

                try { _cpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _cpu.Price = 0; }
                Console.WriteLine(_cpu.Manufacturer);
                Console.WriteLine(_cpu.Model);
                Console.WriteLine(_cpu.Hherz);
                Console.WriteLine(_cpu.Socket);
                Console.WriteLine(_cpu.Price);
                Console.WriteLine(new string('.', 80));

                _cpus.Add(_cpu);
            }
            Console.WriteLine("Конец работы");
            //foreach (CPUparse cpu in _cpus)
            //{
            //    Console.WriteLine(cpu.Manufacturer);
            //    Console.WriteLine(cpu.Model);
            //    Console.WriteLine(cpu.Hherz);
            //    Console.WriteLine(cpu.Socket);
            //    Console.WriteLine(cpu.Price);
            //    Console.WriteLine(new string('.', 80));
            //}
            //for (int i = 0; i < CPUs.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {CPUs[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {CPUs[i].Model}");
            //    Console.WriteLine($"Сокет : {CPUs[i].Socket}");
            //    Console.WriteLine($"Цена : {CPUs[i].Price}");
            //    Console.WriteLine("================================================================");
            //}



        }



    }
}
