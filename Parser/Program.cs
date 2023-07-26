// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Dom;

Console.WriteLine("Hello, World!");
//var config = Configuration.Default.WithDefaultLoader();
//var address = "https://www.citilink.ru/catalog/videokarty/?ref=mainmenu";
//var document = await BrowsingContext.New(config).OpenAsync(address);
//string text = document.QuerySelector("a.app-catalog-9gnskf e1259i3g0").Text();
//Console.WriteLine(text);
Console.WriteLine("Конец работы");

var config = Configuration.Default.WithDefaultLoader();
var address = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
var context = BrowsingContext.New(config);
var document = await context.OpenAsync(address);
var cellSelector = "span.search-result-name"; //html element to get book names
var cells = document.QuerySelectorAll(cellSelector);
var titles = cells.Select(m => m.TextContent).ToList();

for (var i = 0; i < titles.Count(); i++)
{
    Console.WriteLine(titles[i]);
}

Console.WriteLine("Конец работы");
Console.ReadLine();