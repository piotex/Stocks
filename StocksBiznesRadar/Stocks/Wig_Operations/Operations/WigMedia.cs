using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigMedia : WigOperation
    {
        public WigMedia()
        {
            SheetName = "Media";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/3RGAMES",
                @"https://www.biznesradar.pl/notowania/4FUNMEDIA",
                @"https://www.biznesradar.pl/notowania/AGORA",
                @"https://www.biznesradar.pl/notowania/ASMGROUP",
                @"https://www.biznesradar.pl/notowania/ATMGRUPA",
                @"https://www.biznesradar.pl/notowania/COMPERIA",
                @"https://www.biznesradar.pl/notowania/IMS",
                @"https://www.biznesradar.pl/notowania/KCI",
                @"https://www.biznesradar.pl/notowania/KINOPOL",
                @"https://www.biznesradar.pl/notowania/LARQ",
                @"https://www.biznesradar.pl/notowania/MEDIACAP",
                @"https://www.biznesradar.pl/notowania/MUZA",
                @"https://www.biznesradar.pl/notowania/PMPG",
                @"https://www.biznesradar.pl/notowania/WIRTUALNA"
            };
        }
    }
}
