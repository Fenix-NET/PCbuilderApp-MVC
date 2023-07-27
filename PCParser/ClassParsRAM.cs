using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PCParser.DTOs;

namespace PCParser
{
    public class ClassParsRAM
    {

        public async Task StartParseRAM()
        {

            Console.WriteLine("Подготовка парсера");

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://tula.nix.ru/price.html?section=memory_modules_all#c_id=182&fn=182&g_id=1022&page=1&sort=%2Bp327%2B1965&spoiler=&store=region-1483_0&thumbnail_view=2";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var urlSelector = "a.t";
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var titlesRef = cells.Select(m => m.Href).ToList();
            var priceSelector = "td.d.tac.cell-price > span"; 
            var cellsP = document.QuerySelectorAll(priceSelector);

            var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", "")).ToList();

            List<RAMparse> RAMs = new List<RAMparse>();

            Console.WriteLine("Начало парсинга RAM");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";                
            var MemorySelector = "td#tdsa3360";
            var DDRSelector = "td#tdsa2510";
            IElement cellss;
            int x = 0;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                RAMs.Add(new RAMparse());
                RAMs[x].Price = decimal.Parse(titlesPrice[i]);
                address = titlesRef[i];
                document = await context.OpenAsync(address);
       
                cellss = document.QuerySelector(manufacturerSelector);
                RAMs[x].Manufacturer = cellss?.TextContent;

                cellss = document.QuerySelector(modelSelector);
                RAMs[x].Model = cellss?.FirstChild.TextContent ?? cellss?.TextContent;

                cellss = document.QuerySelector(DDRSelector);
                RAMs[x].DDR = cellss?.FirstChild.TextContent ?? cellss?.TextContent;

                cellss = document.QuerySelector(MemorySelector);
                RAMs[x].Memory = ushort.Parse(Regex.Replace(cellss?.FirstChild.TextContent, @"\D+", "")); //?? 8;        //ushort.Parse(Regex.Replace(cellss.TextContent, @"\D+", ""));

                x++;
            }
            Console.WriteLine("Конец работы");
            for (int i = 0; i < RAMs.Count; i++)
            {
                Console.WriteLine($"Производитель : {RAMs[i].Manufacturer}");
                Console.WriteLine($"Модель : {RAMs[i].Model}");
                Console.WriteLine($"Объем памяти : {RAMs[i].Memory}");
                Console.WriteLine($"Тип памяти : {RAMs[i].DDR}");
                Console.WriteLine($"Цена : {RAMs[i].Price}");
                Console.WriteLine("================================================================");
            }

        }



    }
}
