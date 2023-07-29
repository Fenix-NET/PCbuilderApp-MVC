using AngleSharp.Html.Dom;
using AngleSharp;
using PCParser.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace PCParser
{
    public class TestCPUParse : BaseParseClass
    {

        public List<CPUparse> _cpus = new();

        public TestCPUParse() { }

        public async Task StartParsCPU()
        {
            Console.WriteLine("Подготовка парсера"); 
            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга CPU");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 //"td#tdsa2944 <a.btn btn-i btn-t-1 btn-c-1 btn-c-2-b"
            var socketSelector = "td#tdsa1307";

            foreach(string link in listref) 
            {
                CPUparse _cpu = new();
                using var doc = GetPage(link);

                _cpu.Manufacturer = doc.QuerySelector(manufacturerSelector).TextContent ?? "n/a";

                _cpu.Model = doc.QuerySelector(modelSelector).FirstChild.TextContent ?? "n/a";
                Console.WriteLine($"Модель : {_cpu.Model}");

                _cpu.Socket = doc.QuerySelector(socketSelector).FirstChild.TextContent ?? "n/a";

                _cpus.Add( _cpu );
            }
            Console.WriteLine("Конец работы");

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
