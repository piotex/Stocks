using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigMoto : WigOperation
    {
        public WigMoto()
        {
            SheetName = "Moto";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/ACAUTOGAZ",
                @"https://www.biznesradar.pl/notowania/AUTOPARTN",
                @"https://www.biznesradar.pl/notowania/BAHOLDING",
                @"https://www.biznesradar.pl/notowania/DEBICA",
                @"https://www.biznesradar.pl/notowania/GROCLIN",
                @"https://www.biznesradar.pl/notowania/INTERCARS",
                @"https://www.biznesradar.pl/notowania/SANOK"
            };
        }
    }
}
