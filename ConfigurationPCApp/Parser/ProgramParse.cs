// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Browser;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfigurationPCApp.Parser.DTOs;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

//Console.WriteLine("Hello, World!");


public class ProgramParse : IParser
{



    public async void StartedParseGPU()
    {
        var config = Configuration.Default.WithDefaultLoader();
        var address = "https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=685&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2";
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(address);

        var urlSelector = "a.t"; 
        var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
        var priceSelector = "td.d.tac.cell-price > span";
        var cellsP = document.QuerySelectorAll(priceSelector);
        var titlesRef = cells.Select(m => m.Href).ToList();
        var titlesPrice = cellsP.Select(m => m.TextContent).ToList();



    }


    List<GPUparseDTO> GPUs = new List<GPUparseDTO>();

    int x = 0;
    Console.WriteLine("Начало парсинга GPU");
        for (var i = 0; i<titlesRef.Count; i++)
        {
            GPUs.Add(new GPUparse());
            GPUs[x].Price = titlesPrice[i];
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
    GPUs[x].Power = power;

        x++;

}            
        
        
       
    
