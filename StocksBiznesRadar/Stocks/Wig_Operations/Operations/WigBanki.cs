using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigBanki : WigOperation
    {
        public WigBanki()
        {
            SheetName = "Banki";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/BOGDANKA",
                @"https://www.biznesradar.pl/notowania/COALENERG",
                @"https://www.biznesradar.pl/notowania/JSW",
                @"https://www.biznesradar.pl/notowania/KGHM",
                @"https://www.biznesradar.pl/notowania/PRAIRIE"
            };
        }
    }
}
