using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigPaliwa : WigOperation
    {
        public WigPaliwa()
        {
            SheetName = "Paliwa";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/LOTOS",
                @"https://www.biznesradar.pl/notowania/MOL",
                @"https://www.biznesradar.pl/notowania/PGNIG",
                @"https://www.biznesradar.pl/notowania/PKNORLEN",
                @"https://www.biznesradar.pl/notowania/SERINUS",
                @"https://www.biznesradar.pl/notowania/UNIMOT"
            };
        }
    }
}
