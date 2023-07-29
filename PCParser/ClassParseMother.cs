using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCParser.DTOs;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;

namespace PCParser
{                                                       //Выделение общей логики в отдельные сервисы
    internal class ClassParseMother : BaseParseClass                   //Оптимизация работы и времени отклика.
    {
        public List<MotherParse> _mothers = new();
        public async Task StartParsMother()
        {
            Console.WriteLine("Подготовка парсера");

            List<string> listref = GetListRef();

            Console.WriteLine("Начало парсинга Motherboard");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 
            var socketSelector = "td#tdsa1307";
            var formSelector = "td#tdsa643";
            var formSelectorNull = "td#tdsa25875";
            var priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";

            foreach (string link in listref)
            {
                MotherParse _mother = new();
                using var doc = GetPage(link);

                _mother.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _mother.Model = doc.QuerySelector(modelSelector).FirstChild?.TextContent ?? "n/a";

                _mother.Socket = doc.QuerySelector(socketSelector).FirstChild?.TextContent ?? "n/a";

                try { _mother.Form = Regex.Replace(doc.QuerySelector(formSelector).FirstChild.Text(), @"\W+\d+\D+\d+\D+", ""); }
                catch (Exception ex) { _mother.Form = doc.QuerySelector(formSelectorNull)?.FirstChild?.TextContent ?? "n/a"; };

                try { _mother.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _mother.Price = 0; }

                Console.WriteLine(_mother.Manufacturer);
                Console.WriteLine(_mother.Model);
                Console.WriteLine(_mother.Socket);
                Console.WriteLine(_mother.Form);
                Console.WriteLine(_mother.Price);
                Console.WriteLine(new string('.', 80));

                _mothers.Add(_mother);
            }
            Console.WriteLine("Конец работы");
            //foreach (MotherParse mother in _mothers)
            //{
            //    Console.WriteLine(mother.Manufacturer);
            //    Console.WriteLine(mother.Model);
            //    Console.WriteLine(mother.Socket);
            //    Console.WriteLine(mother.Form);
            //    Console.WriteLine(mother.Price);
            //    Console.WriteLine(new string('.', 80));
            //}

            //for (int i = 0; i < motherParses.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {motherParses[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {motherParses[i].Model}");
            //    Console.WriteLine($"Сокет : {motherParses[i].Socket}");
            //    Console.WriteLine($"Форм-фактор : {motherParses[i].Form}");
            //    Console.WriteLine($"Цена : {motherParses[i].Price}");
            //    Console.WriteLine("================================================================");
            //}











        }
    }
}
