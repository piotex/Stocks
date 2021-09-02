using ClosedXML.Excel;
using Stocks.Wig_Operations.Base;
using Stocks.Wig_Operations.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Stocks.Wig_Operations
{
    public static class FactorySector
    {
        public static List<WigOperation> wigOperations = new List<WigOperation>
        {
            new GpwAll(),
            new WigDiv(),
            new WigBanki(),
            new WigBudownictwo(),
            new WigChemia(),
            new WigEnergia(),
            new WigGames(),
            new WigGornic(),
            new WigInf(),
            new WigLeki(),
            new WigMedia(),
            new WigMoto(),
            new WigNRCHOM(),
            new WigOdzierz(),
            new WigPaliwa(),
            new WigSporzywczy(),
            new WigTelek()
        };

        public static void GetAndSaveSectorData()
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                for (int i = 0; i < wigOperations.Count; i++)
                {
                    WigOperation operation = wigOperations[i];
                    operation.SaveSector(workbook);

                    Console.WriteLine((i+1).ToString() + " --- " + DateTime.Now);
                    Thread.Sleep(4000);
                }
                workbook.SaveAs(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\Stocks\Stocks_Excel\Stocks-" + DateTime.UtcNow.Date.ToString("yyyy/MM/dd") + ".xlsx");
            }
        }
    }
}
