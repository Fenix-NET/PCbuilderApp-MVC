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
    public class ClassParsCPU
    {

        public async Task StartParsCPU()
        {
            Console.WriteLine("Подготовка парсера");

            var config = Configuration.Default.WithDefaultLoader();
            var adress = "https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=171&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2";
            using var context = BrowsingContext.New(config);
            using var document = await context.OpenAsync(adress);
            var urlSelector = "a.t"; //html element to get book names
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span"; //html element to get book names
            var cellsP = document.QuerySelectorAll(priceSelector);

            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<CPUparse> CPUs = new List<CPUparse>();
            
            Console.WriteLine("Начало парсинга CPU");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                 //"td#tdsa2944 <a.btn btn-i btn-t-1 btn-c-1 btn-c-2-b"
            var socketSelector = "td#tdsa1307";
            
            //IElement cellss;
            int x = 0;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                CPUs.Add(new CPUparse());
                CPUs[x].Price = decimal.Parse(titlesPrice[i]);
                adress = titlesRef[i];
                using var clondoc = await context.OpenAsync(adress);
                         
                CPUs[x].Manufacturer = clondoc.QuerySelector(manufacturerSelector).TextContent ?? "n/a";

                CPUs[x].Model = clondoc.QuerySelector(modelSelector).FirstChild.TextContent ?? "n/a";
                Console.WriteLine($"Модель : {CPUs[x].Model}");

                CPUs[x].Socket = clondoc.QuerySelector(socketSelector).FirstChild.TextContent ?? "n/a";

                x++;
                Console.WriteLine($"Итерация = {x}");
            }
            Console.WriteLine("Конец работы");

            for (int i = 0; i < CPUs.Count; i++)
            {
                Console.WriteLine($"Производитель : {CPUs[i].Manufacturer}");
                Console.WriteLine($"Модель : {CPUs[i].Model}");
                Console.WriteLine($"Сокет : {CPUs[i].Socket}");
                Console.WriteLine($"Цена : {CPUs[i].Price}");
                Console.WriteLine("================================================================");
            }



        }



    }
}
