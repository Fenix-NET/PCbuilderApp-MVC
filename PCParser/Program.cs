// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PCParser;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PCParser.DTOs;
using PCParser.Models;

Console.WriteLine("Старт программы");

//Console.WriteLine(new string('.', 80));
//TestCPUParse testCPUParse = new TestCPUParse();
//using ParserContext parserContext = new ParserContext();
//testCPUParse.StartParsCPU(parserContext);

//https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=524&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера видеокарт");
ClassParsGPU classParsGPU = new();
using ParserContext parserContext = new ParserContext();
await classParsGPU.StartParseGPU(parserContext);
Console.WriteLine(new string('.', 80));

//https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=7&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера процессоров");
ClassParsCPU classParsCPU = new();
await classParsCPU.StartParsCPU(parserContext);
Console.WriteLine(new string('.', 80));

//https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=3&page=1&sort=%2Bp79%2B1011%2B1008%2B127%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера Материнских плат");
ClassParseMother classParseMother = new();
await classParseMother.StartParsMother(parserContext);
Console.WriteLine(new string('.', 80));

//https://tula.nix.ru/price.html?section=power_supplies_all#c_id=772&fn=772&g_id=631&page=1&sort=%2Bp6920%2B127%2B998%2B2289&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера Блоков питания");
ClassParsPSU classParsPSU = new();
await classParsPSU.StartParsePSU(parserContext);
Console.WriteLine(new string('.', 80));

//https://tula.nix.ru/price.html?section=memory_modules_all#c_id=182&fn=182&g_id=1140&page=1&sort=%2Bp327%2B1965&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера оперативной памяти");
ClassParsRAM classParsRAM = new();
await classParsRAM.StartParseRAM(parserContext);
Console.WriteLine(new string('.', 80));

//https://tula.nix.ru/price.html?section=cases_all#c_id=166&fn=166&g_id=162&page=1&sort=%2Bp1764%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера корпусов");
ClassParsCase classParsCase = new();
await classParsCase.StartParsCase(parserContext);
Console.WriteLine(new string('.', 80));

//Console.WriteLine(new string('.', 80));
//Console.WriteLine("Начало парсинга CPU");
//address = "https://www.xcom-shop.ru/catalog/collections/cpu_for_games/";  //url каталога CPU
//document = await context.OpenAsync(address);
//urlSelector = "a.t";        
//cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();

//priceSelector = "td.d.tac.cell-price > span";

//titlesRef = cells.Select(m => m.Href).ToList();
//titlesPrice = cellsP.Select(m => m.TextContent).ToList();


Console.ReadLine();
