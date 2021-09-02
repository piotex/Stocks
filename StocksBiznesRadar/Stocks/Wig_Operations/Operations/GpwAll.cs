using ClosedXML.Excel;
using Stocks.GetInfo;
using Stocks.Wig_Operations.Base;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Stocks.Wig_Operations.Operations
{
    public class GpwAll : WigOperation
    {
        public GpwAll()
        {
            links = new List<string>();
            new GetListOfCompanies().GetLIstOfCompanies(ref links);
            SheetName = "GPW_All";
        }
        public override void SaveSector(XLWorkbook workbook)
        {
            int number = 2;

            IXLWorksheet worksheet = workbook.Worksheets.Add(SheetName);
            init_Sektor(worksheet);
            for (int i = 0; i < links.Count; i++)
            {
                string link = links[i];
                add_sub_Sektor(worksheet, link, ref number);
                if (i%20 == 19)
                {
                    Console.WriteLine(i+1);
                    Thread.Sleep(4000);
                }
            }
        }
    }
}
