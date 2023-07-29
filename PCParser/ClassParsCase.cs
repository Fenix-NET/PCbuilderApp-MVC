using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using PCParser.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCParser
{
    public class ClassParsCase
    {

        public async Task StartParsCase()
        {

            Console.WriteLine("Подготовка парсера");

            var config = Configuration.Default.WithDefaultLoader();
            var adress = "https://tula.nix.ru/price.html?section=cases_all#c_id=166&fn=166&g_id=2000&page=1&sort=%2Bp1764%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2";
            using var context = BrowsingContext.New(config);
            using var document = await context.OpenAsync(adress);
            var urlSelector = "a.t";
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span";
            var cellsP = document.QuerySelectorAll(priceSelector);

            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<Caseparse> caseParses = new List<Caseparse>();

            Console.WriteLine("Начало парсинга Корпусов");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                
            var formSelector = "td#tdsa2510";
            var modelSelectornull = "td#tdsa2944";
            IElement cellss;
            int x = 0;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                caseParses.Add(new Caseparse());
                caseParses[x].Price = decimal.Parse(titlesPrice[i]);
                adress = titlesRef[i];
                using var clondoc = await context.OpenAsync(adress);
                           
                caseParses[x].Manufacturer = clondoc.QuerySelector(manufacturerSelector).TextContent ?? "n/a";

                caseParses[x].Model = clondoc.QuerySelector(modelSelector).FirstChild.TextContent ?? "n/a";

                caseParses[x].Form = clondoc.QuerySelector(formSelector).TextContent ?? "n/a";

                x++;
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < caseParses.Count; i++)
            {
                Console.WriteLine($"Производитель : {caseParses[i].Manufacturer}");
                Console.WriteLine($"Модель : {caseParses[i].Model}");
                Console.WriteLine($"Форм-фактор : {caseParses[i].Form}");
                Console.WriteLine($"Цена : {caseParses[i].Price}");
                Console.WriteLine("================================================================");
            }


        }


    }
}
