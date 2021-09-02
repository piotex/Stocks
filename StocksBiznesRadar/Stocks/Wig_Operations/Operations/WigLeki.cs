using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

namespace Stocks.Wig_Operations.Operations
{
    public class WigLeki : WigOperation
    {
        public WigLeki()
        {
            SheetName = "Leki";
            links = new List<string>
            {
                @"https://www.biznesradar.pl/notowania/BIOMEDLUB",
                @"https://www.biznesradar.pl/notowania/BIOTON",
                @"https://www.biznesradar.pl/notowania/CLNPHARMA",
                @"https://www.biznesradar.pl/notowania/CORMAY",
                @"https://www.biznesradar.pl/notowania/KRKA",
                @"https://www.biznesradar.pl/notowania/MABION",
                @"https://www.biznesradar.pl/notowania/MASTERPHA",
                @"https://www.biznesradar.pl/notowania/PHARMENA",
                @"https://www.biznesradar.pl/notowania/SOPHARMA"
            };
        }
    }
}
