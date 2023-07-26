// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Html.Dom;
using System.Text.RegularExpressions;
using Test;

Console.WriteLine("Hello, World!");


var config = Configuration.Default.WithDefaultLoader();
var address = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=524&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
var context = BrowsingContext.New(config);
var document = await context.OpenAsync(address);
var urlSelector = "a.t"; //html element to get book names
var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
var titlesRef = cells.Select(m => m.Href).ToList();
var priceSelector = "td.d.tac.cell-price > span"; //html element to get book names
var cellsP = document.QuerySelectorAll(priceSelector);


var titlesPrice = cellsP.Select(m => m.TextContent.Replace(" ", ""));

List<GPUparse> GPUs = new List<GPUparse>();

int x = 0;
Console.WriteLine("Начало парсинга GPU");
for (int i = 0; i < titlesRef.Count; i++)
{
    GPUs.Add(new GPUparse());
    GPUs[x].Price = decimal.Parse(titlesPrice[i]);
    address = titlesRef[i];
    document = await context.OpenAsync(address);

    var manufacturerSelector = "td#tdsa2943";    //"td#tdsa2943"a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component"
    var cellss = document.QuerySelector(manufacturerSelector);
    GPUs[x].Manufacturer = cellss?.TextContent;

    var modelSelector = "td#tdsa2944";
    cellss = document.QuerySelector(modelSelector);
    GPUs[x].Model = cellss?.TextContent;

    var powerSelector = "td#tdsa44456";
    cellss = document.QuerySelector(powerSelector);
    string? power = Regex.Replace(cellss?.TextContent, @"\D+", "");
    GPUs[x].Power = ushort.Parse(power);

    x++;
}
Console.WriteLine("Конец работы");
for (int i = 0; i < GPUs.Count; i++)
{
    Console.WriteLine($"Производитель : {GPUs[i].Manufacturer}");
    Console.WriteLine($"Модель : {GPUs[i].Model}");
    Console.WriteLine($"Цена : {GPUs[i].Price}");
    Console.WriteLine($"Потребление энергии : {GPUs[i].Power}");
    Console.WriteLine("================================================================");
}

//Console.WriteLine("Начало парсинга CPU");
//address = "https://www.xcom-shop.ru/catalog/collections/cpu_for_games/";  //url каталога CPU
//document = await context.OpenAsync(address);
//urlSelector = "a.t";        
//cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();

//priceSelector = "td.d.tac.cell-price > span";

//titlesRef = cells.Select(m => m.Href).ToList();
//titlesPrice = cellsP.Select(m => m.TextContent).ToList();


Console.ReadLine();