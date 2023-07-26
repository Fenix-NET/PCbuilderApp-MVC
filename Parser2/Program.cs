// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Parser2;
using System.ComponentModel;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        var config = Configuration.Default.WithDefaultLoader();
        var address = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(address);
        var cellSelector = "a.t"; //html element to get book names
        var cells = document.QuerySelectorAll(cellSelector).OfType<IHtmlAnchorElement>(); ;

        var configP = Configuration.Default.WithDefaultLoader();
        var addressP = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
        var contextP = BrowsingContext.New(config);
        var documentP = await context.OpenAsync(addressP);
        var cellSelectorP = "td.d.tac.cell-price > span"; //html element to get book names
        var cellsP = document.QuerySelectorAll(cellSelectorP);

        var titles = cells.Select(m => m.Href).ToList();
        var titlesP = cellsP.Select(m => m.TextContent).ToList();
        for (var i = 0; i < titlesP.Count; i++)
        {

            Console.WriteLine(titlesP[i]);
            //}
            //x++;
        }
        //GPU gpu = new GPU();
        List<GPU> gpus = new List<GPU>();
        //gpus.Add(new GPU());
        //for (int i = 0; i < titles.Count; i++)
        //{
        //    gpus.Add(new GPU());
        //}
        int x = 0;
        Console.WriteLine("Начало парса Поставщика");
        for (var i = 0; i < titles.Count; i++)
        {

            //int y = 0;
            address = titles[i];
            document = await context.OpenAsync(address);
            var Selector = "td#tdsa2943";    //"td#tdsa2943"a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component"
            var cellss = document.QuerySelector(Selector);
            // string info = cellss.TextContent;
            //if (cellss != null)
            //{
            gpus.Add(new GPU());
            gpus[x].Manufacturer = cellss?.TextContent;
            x++;
            //}
            //x++;
        }
        //for (var i = 0; i < gpus.Count; i++)
        //    {
        //      Console.WriteLine($"Производитель : {gpus[i].Manufacturer}");

        //    }
        x = 0;
        Console.WriteLine("Начало парса Модели");
        for (var i = 0; i < titles.Count; i++)
        {

            address = titles[i];
            document = await context.OpenAsync(address);
            var Selector = "td#tdsa2944";
            var cellss = document.QuerySelector(Selector);
            //if (cellss != null)
            //{
            gpus[x].Model = cellss?.TextContent;
            x++;
            //}

        }
        x = 0;
        Console.WriteLine("Начало парса Цены");
        for (var i = 0; i < titles.Count; i++)
        {

            address = titles[i];
            document = await context.OpenAsync(address);
            var Selector = "a.add_to_cart btn btn-t-0 btn-c-6 IsInBasket CanBeSold pc-component";
            var cellss = document.QuerySelector(Selector);
            //if (cellss != null)
            //{
            gpus[x].Price = cellss?.TextContent;
            x++;
            // }

        }
        x = 0;
        Console.WriteLine("Начало парса Энергии");
        for (var i = 0; i < titles.Count; i++)
        {

            address = titles[i];
            document = await context.OpenAsync(address);
            var Selector = "td#tdsa44456";
            var cellss = document.QuerySelector(Selector);
            //if (cellss != null)
            //{
            gpus[x].Power = cellss?.TextContent;
            x++;
            //}
        }
        for (var i = 0; i < gpus.Count; i++)
        {
            Console.WriteLine($"Производитель : {gpus[i].Manufacturer}");
            Console.WriteLine($"Модель : {gpus[i].Model}");
            Console.WriteLine($"Цена : {gpus[i].Price}");
            Console.WriteLine($"Потребление энергии : {gpus[i].Power}");
            Console.WriteLine("================================================================");
        }
        //for (var i = 0; i < titles.Count(); i++)
        //{
        //    Console.WriteLine(titles[i]);
        //}

        Console.WriteLine("Конец работы");
        Console.ReadLine();
    }
}