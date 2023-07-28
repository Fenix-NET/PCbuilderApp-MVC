// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TestD;

Console.WriteLine("Hello, World!");
var config = Configuration.Default.WithDefaultLoader();
var address = "https://www.dns-shop.ru/product/ef42e95e5af71b80/videokarta-palit-geforce-rtx-3060-dual-lhr-ne63060019k9-190ad/characteristics/";
using var context = BrowsingContext.New(config);
using var document = await context.OpenAsync(address);
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
var powerSelectorNull = "td#tdsa893";
var powerSelector = "td#tdsa44456";
IElement cellss;
for (int i = 0; i < titlesRef.Count; i++)
{
    GPUs.Add(new GPUparse());
    GPUs[x].Price = decimal.Parse(titlesPrice[i]);
    address = titlesRef[i];
    using var clondoc = await context.OpenAsync(address);

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
    x++;
    Console.WriteLine($"Итерация = {x}");
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
