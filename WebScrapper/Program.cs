using System;
using System.Threading.Tasks;

namespace WebScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //HousesForRent.LookForItems();
            var rr = new RestrictedPages().Main().Result;
        }
    }
}
