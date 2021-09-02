using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigSporzywczy : WigOperation
    {
        public WigSporzywczy()
        {
            SheetName = "Sporzywczy";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/AGROTON",
                @"https://www.biznesradar.pl/notowania/AMBRA",
                @"https://www.biznesradar.pl/notowania/ASTARTA",
                @"https://www.biznesradar.pl/notowania/ATLANTAPL",
                @"https://www.biznesradar.pl/notowania/AUGA",
                @"https://www.biznesradar.pl/notowania/GOBARTO",
                @"https://www.biznesradar.pl/notowania/HELIO",
                @"https://www.biznesradar.pl/notowania/IMCOMPANY",
                @"https://www.biznesradar.pl/notowania/KERNEL",
                @"https://www.biznesradar.pl/notowania/KRVITAMIN",
                @"https://www.biznesradar.pl/notowania/KSGAGRO",
                @"https://www.biznesradar.pl/notowania/MAKARONPL",
                @"https://www.biznesradar.pl/notowania/MBWS",
                @"https://www.biznesradar.pl/notowania/MILKILAND",
                @"https://www.biznesradar.pl/notowania/OTMUCHOW",
                @"https://www.biznesradar.pl/notowania/OVOSTAR",
                @"https://www.biznesradar.pl/notowania/PAMAPOL",
                @"https://www.biznesradar.pl/notowania/PEPEES",
                @"https://www.biznesradar.pl/notowania/SEKO",
                @"https://www.biznesradar.pl/notowania/TARCZYNSKI",
                @"https://www.biznesradar.pl/notowania/WAWEL"
            };
        }
    }
}
