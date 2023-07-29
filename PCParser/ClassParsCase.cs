using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using PCParser.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PCParser
{
    public class ClassParsCase : BaseParseClass
    {
        public List<Caseparse> _cases = new();
        public async Task StartParsCase()
        {
            Console.WriteLine("Подготовка парсера");

            List<string> listref = GetListRef(); ;

            Console.WriteLine("Начало парсинга Корпусов");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                
            var formSelector = "td#tdsa2510";
            var modelSelectornull = "td#tdsa2944";
            var massSelector = "td#tdsa1672";
            var materialSelector = "td#tdsa2399";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                Caseparse _case = new();
                using var doc = GetPage(link);

                _case.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _case.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Form = doc.QuerySelector(formSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Materials = doc.QuerySelector(materialSelector)?.FirstChild?.TextContent ?? "n/a";

                // string price = Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "");
                try {_case.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch(Exception ex) { _case.Price = 0; }

                Console.WriteLine(_case.Manufacturer);
                Console.WriteLine(_case.Model);
                Console.WriteLine(_case.Form);
                Console.WriteLine(_case.Mass);
                Console.WriteLine(_case.Materials);
                Console.WriteLine(_case.Price);
                Console.WriteLine(new string('.', 80));

                _cases.Add(_case);
                
            }
            Console.WriteLine("Конец работы");
            //foreach (Caseparse casee in _cases)
            //{
            //    Console.WriteLine(casee.Manufacturer);
            //    Console.WriteLine(casee.Model);
            //    Console.WriteLine(casee.Form);
            //    Console.WriteLine(casee.Price);
            //    Console.WriteLine(new string('.', 80));
            //}
            //for (int i = 0; i < caseParses.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {caseParses[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {caseParses[i].Model}");
            //    Console.WriteLine($"Форм-фактор : {caseParses[i].Form}");
            //    Console.WriteLine($"Цена : {caseParses[i].Price}");
            //    Console.WriteLine("================================================================");
            //}


        }


    }
}
