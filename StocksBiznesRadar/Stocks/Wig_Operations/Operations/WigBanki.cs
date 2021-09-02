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
                @"https://www.biznesradar.pl/notowania/ALIOR",
                @"https://www.biznesradar.pl/notowania/BNP",
                @"https://www.biznesradar.pl/notowania/BOS",
                @"https://www.biznesradar.pl/notowania/GETIN",
                @"https://www.biznesradar.pl/notowania/GETINOBLE",
                @"https://www.biznesradar.pl/notowania/HANDLOWY",
                @"https://www.biznesradar.pl/notowania/ING",
                @"https://www.biznesradar.pl/notowania/MBANK",
                @"https://www.biznesradar.pl/notowania/MILLENNIUM",
                @"https://www.biznesradar.pl/notowania/PEKAO",
                @"https://www.biznesradar.pl/notowania/PKOBP",
                @"https://www.biznesradar.pl/notowania/SPL",
                @"https://www.biznesradar.pl/notowania/SANTANDER",
                @"https://www.biznesradar.pl/notowania/UNICREDIT"
            };
        }
    }
}
