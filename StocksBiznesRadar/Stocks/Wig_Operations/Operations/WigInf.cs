using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigInf : WigOperation
    {
        public WigInf()
        {
            SheetName = "Inf";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/AILLERON",
                @"https://www.biznesradar.pl/notowania/ASSECOBS",
                @"https://www.biznesradar.pl/notowania/ASSECOPOL",
                @"https://www.biznesradar.pl/notowania/ASSECOSEE",
                @"https://www.biznesradar.pl/notowania/ATENDE",
                @"https://www.biznesradar.pl/notowania/BETACOM",
                @"https://www.biznesradar.pl/notowania/BRAND24",
                @"https://www.biznesradar.pl/notowania/COMARCH",
                @"https://www.biznesradar.pl/notowania/COMP",
                @"https://www.biznesradar.pl/notowania/DATAWALK",
                @"https://www.biznesradar.pl/notowania/ELZAB",
                @"https://www.biznesradar.pl/notowania/IFIRMA",
                @"https://www.biznesradar.pl/notowania/K2HOLDING",
                @"https://www.biznesradar.pl/notowania/LIVECHAT",
                @"https://www.biznesradar.pl/notowania/LSISOFT",
                @"https://www.biznesradar.pl/notowania/NTTSYSTEM",
                @"https://www.biznesradar.pl/notowania/OPTEAM",
                @"https://www.biznesradar.pl/notowania/PGSSOFT",
                @"https://www.biznesradar.pl/notowania/SHOPER",
                @"https://www.biznesradar.pl/notowania/SILVAIR-REGS",
                @"https://www.biznesradar.pl/notowania/SYGNITY",
                @"https://www.biznesradar.pl/notowania/TALEX",
                @"https://www.biznesradar.pl/notowania/WASKO"
            };
        }
    }
}
