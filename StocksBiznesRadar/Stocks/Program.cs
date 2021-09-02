using ClosedXML.Excel;
using Stocks.GetInfo;
using Stocks.save_to_xml;
using Stocks.Wig_Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Stocks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + " Start pobierania informacji o spolkach...");

            FactorySector.GetAndSaveSectorData();
         
            Console.WriteLine("End " + DateTime.Now);
        }
    }
}
//https://www.bankier.pl/gielda/notowania/indeksy-gpw
