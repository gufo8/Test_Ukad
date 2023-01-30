using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class UserParser
    {
        string sourceUrl;
        public UserParser(string userUrl)
        {
            sourceUrl = userUrl;
        }
        

        public void ShowResult(IParser parserType)
        {
            parserType.Parse(sourceUrl);            
            Console.WriteLine($"URL -address found after" +
                              $" scraping of the entered " +
                              $"address of the " +
                              $"site using {parserType.GetType().Name} " +
                              $"in the amount: {parserType.ListUrls.Count}");

        }
    }
}
