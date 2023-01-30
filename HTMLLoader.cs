using System;
using System.Net;
using System.Diagnostics;

namespace Test_Ukad
{
    public class HTMLLoader : IHTMLLoader
    {
        WebClient client;
        public HTMLLoader()         
        {
            client = new WebClient();
        }
        public (string, string, double) LoadHTMLDoc(string currentUrl)
        {
            (string, string, double) result;
            string htmlPage = null;
            double responseTime = 0;
            try
            {                
                var watch = Stopwatch.StartNew();
                var responce = client.DownloadString(currentUrl);
                watch.Stop();
                responseTime = watch.ElapsedMilliseconds;
                if (responce != null)
                {                   
                    htmlPage = responce;
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
            return result = (htmlPage, currentUrl, responseTime);
        }

       


        //public static double GetResponseTime(string url)
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    using (var client = new WebClient())
        //    {
        //        client.DownloadString(url);
        //    }
        //    stopwatch.Stop();
        //    return stopwatch.Elapsed.TotalMilliseconds;
        //}


        // Download the page
        //    WebClient webClient = new WebClient();
        //string pageHtml;
        //double responseTime;
        //    try
        //    {
        //        var watch = System.Diagnostics.Stopwatch.StartNew();
        //pageHtml = webClient.DownloadString(currentLink);
        //        watch.Stop();
        //        responseTime = watch.ElapsedMilliseconds / 1000.0;
        //        responseTimes.Add(currentLink, responseTime);
        //        Console.WriteLine("Response time for " + currentLink + ": " + responseTime);
        //    }
        //    catch (WebException)
        //    {
        //        Console.WriteLine("Error downloading " + currentLink);
        //        continue;
        //    }


        //public string LoadHTMLDoc(string currentUrl)
        //{
        //    string source = null;
        //    var responce = client.DownloadString(currentUrl);
        //    if (responce != null)
        //    {
        //        source = responce;
        //    }
        //    return source;
        //}


    }
}
