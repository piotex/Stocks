using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigGames : WigOperation
    {
        public WigGames()
        {
            SheetName = "Games";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/11BIT",
                @"https://www.biznesradar.pl/notowania/CDPROJEKT",
                @"https://www.biznesradar.pl/notowania/CIGAMES",
                @"https://www.biznesradar.pl/notowania/PLAYWAY",
                @"https://www.biznesradar.pl/notowania/TSGAMES"
            };
        }
    }
}
