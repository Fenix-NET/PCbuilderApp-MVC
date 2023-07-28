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

namespace PCParser
{                                                       //Выделение общей логики в отдельные сервисы
    internal class ClassParseMother                     //Оптимизация работы и времени отклика.
    {                                                   
                                                    


        public async Task StartParsMother()
        {
            Console.WriteLine("Подготовка паарсера");

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=4&page=1&sort=%2Bp79%2B1011%2B1008%2B127%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2";
            using var context = BrowsingContext.New(config);
            using var document = await context.OpenAsync(address);

            var urlSelector = "a.t"; 
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span"; 
            var cellsP = document.QuerySelectorAll(priceSelector);


            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<MotherParse> motherParses  = new List<MotherParse>();

            Console.WriteLine("Начало парсинга Motherboard");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 
            var socketSelector = "td#tdsa1307";
            var formSelector = "td#tdsa643";
            var formSelectorNull = "td#tdsa25875";
            IElement cellss;
            int x = 0;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                motherParses.Add(new MotherParse());
                motherParses[x].Price = decimal.Parse(titlesPrice[i]);
                address = titlesRef[i];
                using var clondoc = await context.OpenAsync(address);
 
                motherParses[x].Manufacturer = clondoc.QuerySelector(manufacturerSelector).TextContent ?? "n/a";

                motherParses[x].Model = clondoc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                motherParses[x].Socket = clondoc.QuerySelector(socketSelector)?.FirstChild.TextContent ?? "n/a";


                try { motherParses[x].Form = Regex.Replace(clondoc.QuerySelector(formSelector).FirstChild.Text(), @"\W+\d+\D+\d+\D+", ""); }
                catch (Exception ex) { motherParses[x].Form = clondoc.QuerySelector(formSelectorNull)?.FirstChild?.TextContent ?? "n/a"; };

                x++;
                Console.WriteLine($"Итерация = {x}");
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < motherParses.Count; i++)
            {
                Console.WriteLine($"Производитель : {motherParses[i].Manufacturer}");
                Console.WriteLine($"Модель : {motherParses[i].Model}");
                Console.WriteLine($"Сокет : {motherParses[i].Socket}");
                Console.WriteLine($"Форм-фактор : {motherParses[i].Form}");
                Console.WriteLine($"Цена : {motherParses[i].Price}");
                Console.WriteLine("================================================================");
            }











        }
    }
}
