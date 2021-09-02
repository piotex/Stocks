using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigOdzierz : WigOperation
    {
        public WigOdzierz()
        {
            SheetName = "Odzierz";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/CCC",
                @"https://www.biznesradar.pl/notowania/CDRL",
                @"https://www.biznesradar.pl/notowania/ESOTIQ",
                @"https://www.biznesradar.pl/notowania/GLCOSMED",
                @"https://www.biznesradar.pl/notowania/HARPER",
                @"https://www.biznesradar.pl/notowania/INTERSPPL",
                @"https://www.biznesradar.pl/notowania/LPP",
                @"https://www.biznesradar.pl/notowania/LUBAWA",
                @"https://www.biznesradar.pl/notowania/MIRACULUM",
                @"https://www.biznesradar.pl/notowania/MONNARI",
                @"https://www.biznesradar.pl/notowania/PROTEKTOR",
                @"https://www.biznesradar.pl/notowania/REDAN",
                @"https://www.biznesradar.pl/notowania/SANWIL",
                @"https://www.biznesradar.pl/notowania/SILVANO",
                @"https://www.biznesradar.pl/notowania/SOLAR",
                @"https://www.biznesradar.pl/notowania/VRG",
                @"https://www.biznesradar.pl/notowania/WITTCHEN",
                @"https://www.biznesradar.pl/notowania/WOJAS"
            };
        }
    }
}
