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


Console.WriteLine("Старт программы");
Console.WriteLine(new string('.', 80));
//TestCPUParse testCPUParse = new TestCPUParse();
//testCPUParse.StartParsCPU();
//Console.WriteLine("Запуск парсера видеокарт");
//ClassParsGPU classParsGPU = new();
//await classParsGPU.StartParseGPU();
//Console.WriteLine(new string('.', 80));

//Console.WriteLine("Запуск парсера процессоров");
//ClassParsCPU classParsCPU = new();
//await classParsCPU.StartParsCPU();
//Console.WriteLine(new string('.', 80));

//Console.WriteLine("Запуск парсера Материнских плат");
//ClassParseMother classParseMother = new();
//await classParseMother.StartParsMother();
//Console.WriteLine(new string('.', 80));

//Console.WriteLine("Запуск парсера Блоков питания");
//ClassParsPSU classParsPSU = new();
//await classParsPSU.StartParsePSU();
//Console.WriteLine(new string('.', 80));

//Console.WriteLine("Запуск парсера оперативной памяти");
//ClassParsRAM classParsRAM = new();
//await classParsRAM.StartParseRAM();
//Console.WriteLine(new string('.', 80));

Console.WriteLine("Запуск парсера корпусов");
ClassParsCase classParsCase = new();
await classParsCase.StartParsCase();
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
