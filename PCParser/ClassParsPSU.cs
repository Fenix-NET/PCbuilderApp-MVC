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
using PCParser.Models;

namespace PCParser
{
    public class ClassParsPSU : BaseParseClass
    {
        //public List<PSU> _psus = new();
        //private readonly ParserContext _parserContext;
        //public ClassParsPSU()
        //{
        //    _parserContext = new ParserContext();
        //}
        public async Task StartParsePSU(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга PSU");

            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 
            var powerSelector = "td#tdsa2123";
            var massSelector = "td#tdsa1672";
            var sertifSelector = "td#tdsa2027";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                Models.PSU _psu = new();
                using var doc = GetPage(link);

                _psu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _psu.Model = doc.QuerySelector(modelSelector)?.FirstChild.TextContent ?? "n/a";

                try { _psu.Power = ushort.Parse(Regex.Replace(doc.QuerySelector(powerSelector).TextContent, @"\D+", "")); }
                catch (Exception ex) { _psu.Power = 0; }

                try {_psu.Sertificate = Regex.Replace(doc.QuerySelector(sertifSelector).TextContent, @"^.+?(?=80)", ""); }  //@"\W+\D+", ""
                catch (Exception ex) { _psu.Sertificate = "n/a"; }

                _psu.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _psu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _psu.Price = 0; }

                Console.WriteLine(_psu.Manufacturer);
                Console.WriteLine(_psu.Model);
                Console.WriteLine(_psu.Power);
                Console.WriteLine(_psu.Sertificate);
                Console.WriteLine(_psu.Mass);
                Console.WriteLine(_psu.Price);
                Console.WriteLine(new string('.', 80));

                _context.PSUs.Add(_psu);
                
            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (PSUParse psu in _psus)
            //{
            //    Console.WriteLine(psu.Manufacturer);
            //    Console.WriteLine(psu.Model);
            //    Console.WriteLine(psu.Power);
            //    Console.WriteLine(psu.Price);
            //    Console.WriteLine(new string('.', 80));
            
            //for (int i = 0; i < PSUs.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {PSUs[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {PSUs[i].Model}");
            //    Console.WriteLine($"Мощность : {PSUs[i].Power}");
            //    Console.WriteLine($"Цена : {PSUs[i].Price}");
            //    Console.WriteLine("================================================================");
            //}


        }


    }
}
