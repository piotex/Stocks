using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigNRCHOM : WigOperation
    {
        public WigNRCHOM()
        {
            SheetName = "NRCHOM";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/ALTA",
                @"https://www.biznesradar.pl/notowania/ARCHICOM",
                @"https://www.biznesradar.pl/notowania/ATAL",
                @"https://www.biznesradar.pl/notowania/ATLASEST",
                @"https://www.biznesradar.pl/notowania/BBIDEV",
                @"https://www.biznesradar.pl/notowania/CAVATINA",
                @"https://www.biznesradar.pl/notowania/CCENERGY",
                @"https://www.biznesradar.pl/notowania/CELTIC",
                @"https://www.biznesradar.pl/notowania/DEVELIA",
                @"https://www.biznesradar.pl/notowania/DOMDEV",
                @"https://www.biznesradar.pl/notowania/ECHO",
                @"https://www.biznesradar.pl/notowania/EDINVEST",
                @"https://www.biznesradar.pl/notowania/ELKOP",
                @"https://www.biznesradar.pl/notowania/GTC",
                @"https://www.biznesradar.pl/notowania/HMINWEST",
                @"https://www.biznesradar.pl/notowania/I2DEV",
                @"https://www.biznesradar.pl/notowania/IIAAV",
                @"https://www.biznesradar.pl/notowania/INPRO",
                @"https://www.biznesradar.pl/notowania/LOKUM",
                @"https://www.biznesradar.pl/notowania/MARVIPOL",
                @"https://www.biznesradar.pl/notowania/MLPGROUP",
                @"https://www.biznesradar.pl/notowania/PHN",
                @"https://www.biznesradar.pl/notowania/PLATYNINW",
                @"https://www.biznesradar.pl/notowania/RANKPROGR",
                @"https://www.biznesradar.pl/notowania/TOWERINVT",
                @"https://www.biznesradar.pl/notowania/TRITON",
                @"https://www.biznesradar.pl/notowania/WARIMPEX",
                @"https://www.biznesradar.pl/notowania/WIKANA"
            };
        }
    }
}
