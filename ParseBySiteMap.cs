using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class ParseBySiteMap : IParser
    {
        IHTMLLoader loader;
        string htmlPage = String.Empty;
        public List<string> ListUrls { get; set; }
        public ParseBySiteMap()
        {
            loader = new HTMLLoader();
            ListUrls = new List<string>();
        }
        public void Parse(string sourсeUrl)
        {
            List<string> urlSitemap = new List<string>();            
            htmlPage = loader.LoadHTMLDoc(sourсeUrl + @"/robots.txt");
            urlSitemap = UrlsFromString(htmlPage, "Sitemap", "\n", "\r\n");            
            if (urlSitemap.Count != 0)
            {
                string pg = loader.LoadHTMLDoc(urlSitemap[0]);
                ListUrls = UrlsFromString(pg, "c>", "<sitemap>", "<lo", "<lastmod>", "</sitemap", "</loc>", "</lastmod>");                
            }
        }

        private List<string> UrlsFromString(string source, string startWith, params string[] lst)
        {
            List<string> urls = new List<string>();
            string[] str = source.Split(lst, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in str)
            {
                if (item.StartsWith(startWith))
                {
                    urls.Add(item.Substring(item.IndexOf('h')));
                }
            }
            return urls;
        }        
    }
}
