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

Console.WriteLine(new string('.', 80));
Console.WriteLine("Старт программы");
TestCPUParse testCPUParse = new TestCPUParse();
testCPUParse.StartParsCPU();
//ClassParsGPU classParsGPU = new();

//await classParsGPU.StartParseGPU();
//ClassParsCPU classParsCPU = new();
//Console.WriteLine(new string('.', 80));
//await classParsCPU.StartParsCPU();
//ClassParseMother classParseMother = new();
//Console.WriteLine(new string('.', 80));
//await classParseMother.StartParsMother();
//ClassParsPSU classParsPSU = new();
//Console.WriteLine(new string('.', 80));
//await classParsPSU.StartParsePSU();
//ClassParsRAM classParsRAM = new();
//Console.WriteLine(new string('.', 80));
//await classParsRAM.StartParseRAM();
//ClassParsCase classParsCase = new();
//Console.WriteLine(new string('.', 80));
//await classParsCase.StartParsCase();

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
