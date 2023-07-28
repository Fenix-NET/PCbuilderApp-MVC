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

namespace PCParser
{
    public class ClassParsPSU
    {

        public async Task StartParsePSU()
        {

            Console.WriteLine("Подготовка парсера");

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://tula.nix.ru/price.html?section=power_supplies_all#c_id=772&fn=772&g_id=927&page=1&sort=%2Bp6920%2B127%2B998%2B2289&spoiler=&store=region-1483_0&thumbnail_view=2";
            using var context = BrowsingContext.New(config);
            using var document = await context.OpenAsync(address);
            var urlSelector = "a.t"; 
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span"; 
            var cellsP = document.QuerySelectorAll(priceSelector);

            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<PSUParse> PSUs = new List<PSUParse>();

            int x = 0;
            Console.WriteLine("Начало парсинга PSU");

            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 
            var powerSelector = "td#tdsa2123";

            IElement cellss;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                PSUs.Add(new PSUParse());
                PSUs[x].Price = decimal.Parse(titlesPrice[i]);
                address = titlesRef[i];
                using var clondoc = await context.OpenAsync(address);

                PSUs[x].Manufacturer = clondoc.QuerySelector(manufacturerSelector).TextContent ?? "n/a";

                PSUs[x].Model = clondoc.QuerySelector(modelSelector).FirstChild.TextContent ?? "n/a";

                PSUs[x].Power = ushort.Parse(Regex.Replace(clondoc.QuerySelector(powerSelector).TextContent, @"\D+", ""));

                x++;
                Console.WriteLine($"Итерация = {x}");
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < PSUs.Count; i++)
            {
                Console.WriteLine($"Производитель : {PSUs[i].Manufacturer}");
                Console.WriteLine($"Модель : {PSUs[i].Model}");
                Console.WriteLine($"Мощность : {PSUs[i].Power}");
                Console.WriteLine($"Цена : {PSUs[i].Price}");
                Console.WriteLine("================================================================");
            }


        }


    }
}
