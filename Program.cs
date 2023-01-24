

namespace Test_Ukad
{
    // not too much sites gives answers
    // checked on - always give answer https://learn.microsoft.com/
    // https://www.gsmarena.com/
    // https://www.mobileshop.eu/
    //...............other

    // spent time - not full 4 days 
    // rewrote 3 times 
    // refactoring - 1 time 
    // debug.... 
    // did not use try/catch - did not have enough time (was ill)


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the URL to search for links on the specified site");
            string sourseUrl = Console.ReadLine();

            UserParser userParser = new UserParser(sourseUrl);
            userParser.ShowResult(new ParseByAngleSharp());            
            userParser.ShowResult(new ParseBySiteMap());
        }
    }
}
