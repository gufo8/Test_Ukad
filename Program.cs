

namespace Test_Ukad
{
    // almost all sites (what i checked) have different modifications of the sitemap address
    // checked on - reccomended in your email https://www.litedb.org/ (https://www.litedb.org/sitemap.xml)
    // https://hillary.ua/ (https://hillary.ua/sitemap.xml) - contains not existing pages
    // https://japan-shampoo.com.ua/ (https://japan-shampoo.com.ua/sitemap.xml)  - contains not existing pages
    // https://intellect.ml/ (https://intellect.ml/sitemap.xml)  - contains not existing pages
    // https://metanit.com/ (https://metanit.com/sitemap.xml) - remote server return  - forbidden:)
    //not easy to find site which have that kind of sitemap https://example.com/sitemap.xml

    //a lot have different addresses - which was not checked in this version, for example:
    //Sitemap: https://learn.microsoft.com/_sitemaps/sitemapindex.xml
    //Sitemap: https://learn.microsoft.com/answers/sitemaps/sitemap.xml


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the URL to search for links on the specified site");
            string sourseUrl = Console.ReadLine();

            UserParser userParser = new UserParser(sourseUrl);
            userParser.ShowResult(new ParseByAngleSharp());
            Console.WriteLine("***************************************");
            userParser.ShowResult(new ParseBySiteMap());
        }
    }
}
