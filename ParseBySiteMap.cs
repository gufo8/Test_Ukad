using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class ParseBySiteMap : IParser
    {
        IHTMLLoader loader;
        public List<string> ListUrls { get; set; }

        List<string> linksToVisit = new List<string>();
        List<string> visitedLinks = new List<string>();
        Dictionary<string, double> responseTimes = new Dictionary<string, double>();

        public ParseBySiteMap()
        {
            loader = new HTMLLoader();
            ListUrls = new List<string>();
        }
        public void Parse(string sourсeUrl)
        {
            string htmlPage;
            linksToVisit.Add(sourсeUrl);
            (string, string, double) result = (String.Empty, String.Empty, 0);
            while (linksToVisit.Count > 0)
            {
                string currentLink = linksToVisit[0];
                linksToVisit.RemoveAt(0);
                visitedLinks.Add(currentLink);
                if (responseTimes.ContainsKey(currentLink))
                {
                    Console.WriteLine("Response time for " + currentLink + ": " + responseTimes[currentLink]);
                    continue;
                }
                try
                {                    
                    if (!currentLink.Contains("sitemap.xml") || currentLink.Contains(".xml"))
                    {
                        result = loader.LoadHTMLDoc(currentLink + @"/sitemap.xml");
                    }
                    else { result = loader.LoadHTMLDoc(currentLink + @"/sitemap.xml"); }
                    
                    htmlPage = result.Item1;
                    responseTimes.Add(result.Item2, result.Item3);
                    Console.WriteLine("Response time for " + currentLink + ": " + result.Item3);
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error downloading " + currentLink);
                    Console.WriteLine(ex.Message);
                    continue;
                }
                if (htmlPage.Contains("<loc>"))
                {
                    var pageLinks = UrlsFromString(htmlPage, "c>", "<sitemap>", "<url>", "<lo", 
                        "<lastmod>", "</sitemap", "</loc>", "</url>", "</lastmod>");
                    var filteredLinks = pageLinks.Where(link => link.StartsWith(sourсeUrl) | link.StartsWith("/")).Distinct();
                    foreach (var link in filteredLinks)
                    {                                          
                        var fullLink = new Uri(new Uri(sourсeUrl), link).AbsoluteUri;
                        if (fullLink.StartsWith(sourсeUrl) & !linksToVisit.Contains(fullLink) & !visitedLinks.Contains(fullLink))
                        {
                            linksToVisit.Add(fullLink);
                        }
                    }
                }
                else continue;
            }
            ListUrls = visitedLinks;
        }

        private List<string> UrlsFromString(string source, string startWith, params string[] lst)
        {
            List<string> urls = new List<string>();
            string[] str = source.Split(lst, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in str)
            {
                if (item.StartsWith(startWith))
                {
                    urls.Add(item.Substring(item.IndexOf('>')+1));
                }
            }
            return urls;
        }
    }
}
