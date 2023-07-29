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
            var adress = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
            using var context = BrowsingContext.New(config);
            using var document = await context.OpenAsync(adress);
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
            var modelSelector = "td#tdsa2944";                 
            var powerSelector = "td#tdsa44456";
            var powerSelectorNull = "td#tdsa893";
            var techprocSelector = "td#tdsa3735";
            var memorySelector = "td#tdsa689";
            IElement cellss;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                GPUs.Add(new GPUparse());
                GPUs[x].Price = decimal.Parse(titlesPrice[i]);
                adress = titlesRef[i];
                using var clondoc = await context.OpenAsync(adress);

                GPUs[x].Manufacturer = clondoc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                GPUs[x].Model = clondoc.QuerySelector(modelSelector)?.FirstChild.TextContent ?? "n/a";

                try
                {
                    GPUs[x].Power = ushort.Parse(Regex.Replace(clondoc.QuerySelector(powerSelector).TextContent, @"\D+", ""));
                }
                catch
                {
                    GPUs[x].Power = ushort.Parse(Regex.Replace(clondoc.QuerySelector(powerSelectorNull).TextContent, @"\D+", ""));
                }
                GPUs[x].Techproc = clondoc.QuerySelector(techprocSelector).TextContent ?? "n/a";

                GPUs[x].Memory = clondoc.QuerySelector(memorySelector).TextContent;

                x++;
                Console.WriteLine($"Итерация = {x}");
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < GPUs.Count; i++)
            {
                Console.WriteLine($"Производитель : {GPUs[i].Manufacturer}");
                Console.WriteLine($"Модель : {GPUs[i].Model}");
                Console.WriteLine($"Потребление энергии : {GPUs[i].Power}");
                Console.WriteLine($"Техпроцесс : {GPUs[i].Techproc}");
                Console.WriteLine($"Память : {GPUs[i].Memory}");
                Console.WriteLine($"Цена : {GPUs[i].Price}");
                Console.WriteLine("================================================================");
            }
        }

    }
}





