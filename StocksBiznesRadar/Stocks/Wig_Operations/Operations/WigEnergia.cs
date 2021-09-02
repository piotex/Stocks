using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigEnergia : WigOperation
    {
        public WigEnergia()
        {
            SheetName = "Energia";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/BEDZIN",
                @"https://www.biznesradar.pl/notowania/CEZ",
                @"https://www.biznesradar.pl/notowania/ENEA",
                @"https://www.biznesradar.pl/notowania/INTERAOLT",
                @"https://www.biznesradar.pl/notowania/KOGENERA",
                @"https://www.biznesradar.pl/notowania/MLSYSTEM",
                @"https://www.biznesradar.pl/notowania/ONDE",
                @"https://www.biznesradar.pl/notowania/PEP",
                @"https://www.biznesradar.pl/notowania/PGE",
                @"https://www.biznesradar.pl/notowania/PHOTON",
                @"https://www.biznesradar.pl/notowania/TAURONPE",
                @"https://www.biznesradar.pl/notowania/ZEPAK"
            };
        }
    }
}
