using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class ParseByAngleSharp : IParser
    {
        IHTMLLoader loader;
        string htmlPage = String.Empty;
        public List<string> ListUrls { get; set; }
        public ParseByAngleSharp()
        {
            loader = new HTMLLoader();
            ListUrls = new List<string>();  
        }

        public async void Parse(string sourсeUrl)
        {
            htmlPage = loader.LoadHTMLDoc(sourсeUrl);
            var parserAngleSh = new HtmlParser();
            var doc = await parserAngleSh.ParseDocumentAsync(htmlPage);
            var items = doc.QuerySelectorAll("a");
            foreach (var item in items)
            {
                if (item.GetAttribute("href") != null)
                {
                    ListUrls.Add(item.GetAttribute("href").ToString());
                }
            }
        }
        
    }
}
