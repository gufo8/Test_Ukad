using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class ParseByAngleSharp : IParser
    {
        IHTMLLoader loader;
        public List<string> ListUrls { get; set; }

        List<string> linksToVisit = new List<string>();
        List<string> visitedLinks = new List<string>();
        Dictionary<string, double> responseTimes = new Dictionary<string, double>();

        public ParseByAngleSharp()
        {
            loader = new HTMLLoader();
            ListUrls = new List<string>();
        }

        public void Parse(string sourсeUrl)
        {
            string htmlPage;
            linksToVisit.Add(sourсeUrl);
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
                    (string, string, double) result = loader.LoadHTMLDoc(currentLink);
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
                var doc = new HtmlParser().ParseDocument(htmlPage);
                var pageLinks = doc.QuerySelectorAll("a")
                                   .Select(a => a.GetAttribute("href"))
                                   .Where(href => !string.IsNullOrEmpty(href));
                var filteredLinks = pageLinks.Where(link => link.StartsWith(sourсeUrl) && !visitedLinks.Contains(link));

                foreach (var link in filteredLinks)
                {
                    if (!linksToVisit.Contains(link))
                    {
                        linksToVisit.Add(link);
                    }
                }
            }
            ListUrls = visitedLinks;
        }
    }
}

