using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigChemia : WigOperation
    {
        public WigChemia()
        {
            SheetName = "Chemia";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/CIECH",
                @"https://www.biznesradar.pl/notowania/GRUPAAZOTY",
                @"https://www.biznesradar.pl/notowania/PCCROKITA",
                @"https://www.biznesradar.pl/notowania/POLICE",
                @"https://www.biznesradar.pl/notowania/POLWAX"
            };
        }
    }
}
