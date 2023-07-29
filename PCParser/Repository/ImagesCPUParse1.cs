using PCParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCParser
{
    public class ImagesCPUParse1 :BaseParseClass
    {

        public async Task StartParsImage(ParserContext context)
        {
            var listref = GetListRef();
            var modelSelector = "td#tdsa2944";

            var dir = "C:\\My Project\\PCBuilder\\Images\\CPU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                ImageCPU Img = new();
                using var doc = GetPage(link);
                string imgurl = default;
                string imgUrl2 = default;
                Img.CPUModel = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                //var imgUrl = doc.GetElementById("goods_photo").GetAttribute("href").ToString();
                try { imgurl = doc.GetElementById("goods_photo").GetAttribute("href").ToString(); }
                catch (Exception ex) {  imgurl = doc.GetElementById("main_photo").GetAttribute("src").ToString();  }
                try {imgUrl2 = imgurl.Substring(0, imgurl.IndexOf("?")); }
                catch (Exception ex) { imgUrl2 = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                //string formatimg = imgUrl2.Substring(2, imgUrl.IndexOf("."));
                string format = Regex.Replace(imgUrl2, @"\D+.+?(?=\.)", "");       // Это ОНО!
                //await imgUrl.DownloadFileAsync(dir);
                string localFilename = $"{dir}"+"\\"+$"{Img.CPUModel}"+$"{format}";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(imgUrl2, localFilename);
                }

                Img.ImageDir = localFilename;
                context.ImageCPUs.Add(Img);
                Console.WriteLine(Img.CPUModel);
            }
            context.SaveChanges();
            Console.WriteLine("БД дошло");
        }
    }
}
