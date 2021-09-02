using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigTelek : WigOperation
    {
        public WigTelek()
        {
            SheetName = "Telek";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/CYFRPLSAT",
                @"https://www.biznesradar.pl/notowania/ORANGEPL"
            };
        }
    }
}
