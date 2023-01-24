using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukad
{
    public class UserParser
    {
        IParser parser;
        string sourceUrl;
        public UserParser(string userUrl)
        {
            parser = new ParseByAngleSharp();
            sourceUrl = userUrl;
        }       

        public void ShowResult(IParser type)
        {
            parser = type;
            parser.Parse(sourceUrl);
            if (parser.ListUrls.Count != 0)
            {
                foreach (var item in parser.ListUrls)
                {
                    Console.WriteLine(item);
                }
            }
            else { Console.WriteLine("No links found on the specified page"); };
            Console.WriteLine($"Urls found after using {type.GetType().Name} a website: {parser.ListUrls.Count}");

        }       

    }
}
