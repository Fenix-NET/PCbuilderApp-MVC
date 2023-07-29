using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace PCParser
{
    public class BaseParseClass
    {
        readonly IConfiguration config = Configuration.Default.WithDefaultLoader();
        protected IDocument GetPage(string url)
        {            
            var document = BrowsingContext.New(config).OpenAsync(url).Result;
            if (document.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Bad document status: {document.StatusCode}");
            return document;
        }
        protected List<string> GetListRef()
        {          
            Console.WriteLine("Вставьте ссылку на каталог");
            var adress = Console.ReadLine();       
            using var document = GetPage(adress);
            var urlSelector = "a.t";
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var listRef = cells.Select(m => m.Href).ToList();
            return listRef;
        }


    }
}
