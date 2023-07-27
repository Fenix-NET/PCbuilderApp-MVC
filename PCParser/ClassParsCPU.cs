﻿using AngleSharp.Html.Dom;
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
            var address = "https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=4&page=1&sort=%2Bp79%2B1011%2B1008%2B127%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
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
            
            IElement cellss;
            int x = 0;
            for (int i = 0; i < titlesRef.Count; i++)
            {
                CPUs.Add(new CPUparse());
                CPUs[x].Price = decimal.Parse(titlesPrice[i]);
                address = titlesRef[i];
                document = await context.OpenAsync(address);
          
                cellss = document.QuerySelector(manufacturerSelector);
                CPUs[x].Manufacturer = cellss?.TextContent ?? string.Empty;

                // var modelSelector = "td#tdsa2944";
                cellss = document.QuerySelector(modelSelector);
                CPUs[x].Model = cellss?.FirstChild.TextContent ?? cellss?.TextContent ?? string.Empty;

                // var powerSelector = "td#tdsa44456";
                cellss = document.QuerySelector(socketSelector);

                CPUs[x].Socket = cellss?.FirstChild.TextContent ?? cellss?.TextContent ?? string.Empty;

                x++;
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