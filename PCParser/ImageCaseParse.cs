using Flurl.Http;
using PCParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCParser
{
    public class ImageCaseParse : BaseParseClass
    {

        public async Task StartParsImage(ParserContext context)
        {
            Console.WriteLine("Парсинг Case");
            var listref = GetListRef();
            var modelSelector = "td#tdsa2944";

            var dir = "C:\\My Project\\PCBuilder\\Images\\Case";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                ImageCase Img = new();
                using var doc = GetPage(link);
                string imgurl = default;
                string imgUrl2 = default;
                string editor = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                Img.CaseModel = editor.Replace('/', '-') ?? "n/a";
                //var imgUrl = doc.GetElementById("goods_photo").GetAttribute("href").ToString();
                try { imgurl = doc.GetElementById("goods_photo").GetAttribute("href").ToString(); }
                catch (Exception ex) { imgurl = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                try { imgUrl2 = imgurl.Substring(0, imgurl.IndexOf("?")); }
                catch (Exception ex) { imgUrl2 = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                //string formatimg = imgUrl2.Substring(2, imgUrl.IndexOf("."));
                string format = Regex.Replace(imgUrl2, @"\D+.+?(?=\.)", "");       // Это ОНО!

                string localFilename = $"{dir}" + "\\" + $"{Img.CaseModel}" + $"{format}";

                var url = imgurl ?? imgUrl2;
                Random random = new Random();
                int indx = random.Next(100, 9999);
                await url.DownloadFileAsync(dir, localFilename = $"{Img.CaseModel}" + "-" + $"{indx}" + $"{format}");

                Img.ImageDir = localFilename;
                context.ImageCases.Add(Img);
                Console.WriteLine(Img.CaseModel);
            }
            context.SaveChanges();
            Console.WriteLine("БД дошло");
        }
    }
}
