using System;


namespace Test_Ukad
{
    public interface IParser
    {
        public List<string> ListUrls { get; set; }
        public void Parse(string sourсeUrl);
    }
}
