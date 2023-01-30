using System;

namespace Test_Ukad
{
    public interface IHTMLLoader
    {
        public (string, string, double) LoadHTMLDoc(string currentUrl);
    }
}
