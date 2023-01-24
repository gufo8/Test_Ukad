using System;
using System.Net;

namespace Test_Ukad
{
    public class HTMLLoader : IHTMLLoader
    {
        WebClient client;
        public HTMLLoader()         {
            client = new WebClient();
        }
        public string LoadHTMLDoc(string currentUrl)
        {
            string source = null;
            var responce = client.DownloadString(currentUrl);
            if (responce != null)
            {
                source = responce;  
            }
            return source;
        }
    }
}
