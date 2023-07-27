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
    internal class ClassParsGPU
    {

        public async Task StartParseGPU()
        {

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var urlSelector = "a.t"; //html element to get book names
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span"; //html element to get book names
            var cellsP = document.QuerySelectorAll(priceSelector);

            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<GPUparse> GPUs = new List<GPUparse>();

            int x = 0;
            Console.WriteLine("Начало парсинга GPU");

            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 //"td#tdsa2944 <a.btn btn-i btn-t-1 btn-c-1 btn-c-2-b"
            var powerSelector = "td#tdsa44456";
            var powerSelectorNull = "td#tdsa893";
            IElement cellss;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                GPUs.Add(new GPUparse());
                GPUs[x].Price = decimal.Parse(titlesPrice[i]);
                address = titlesRef[i];
                document = await context.OpenAsync(address);

                //var manufacturerSelector = "td#tdsa2943";    //"td#tdsa2943"a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component"
                cellss = document.QuerySelector(manufacturerSelector);
                GPUs[x].Manufacturer = cellss?.TextContent ?? string.Empty;

                // var modelSelector = "td#tdsa2944";
                cellss = document.QuerySelector(modelSelector);
                GPUs[x].Model = cellss?.FirstChild.TextContent ?? cellss.TextContent ?? string.Empty;

                // var powerSelector = "td#tdsa44456";
                cellss = document.QuerySelector(powerSelector) ?? document.QuerySelector(powerSelectorNull);
                GPUs[x].Power = ushort.Parse(Regex.Replace(cellss?.TextContent, @"\D+", ""));

                x++;
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < GPUs.Count; i++)
            {
                Console.WriteLine($"Производитель : {GPUs[i].Manufacturer}");
                Console.WriteLine($"Модель : {GPUs[i].Model}");
                Console.WriteLine($"Потребление энергии : {GPUs[i].Power}");
                Console.WriteLine($"Цена : {GPUs[i].Price}");
                Console.WriteLine("================================================================");
            }


        }



    }
}
