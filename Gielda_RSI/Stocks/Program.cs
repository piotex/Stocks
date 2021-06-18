using ClosedXML.Excel;
using Stocks.exp;
using Stocks.GetInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Stocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start programu...");

            



            int c = 0;
            int number = 1;

            GetParams getParams = new GetParams();


            Console.WriteLine("Start pobierania informacji o spolkach...");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A" + number.ToString()).Value = "Link";
                worksheet.Cell("B" + number.ToString()).Value = "Kurs";
                worksheet.Cell("C" + number.ToString()).Value = "RSI";
                number++;
                foreach (var link in GlobalObj.listaLinkowBiznesRadara)
                {
                    string body = "";
                    getParams.GetDockBody(ref body, link);

                    Info param = getParams.FilterBodyToGetInfo(ref body);
                    param.Link = link;

                    worksheet.Cell("A" + number.ToString()).Value = param.Link;
                    worksheet.Cell("B" + number.ToString()).Value = param.Kurs;
                    worksheet.Cell("C" + number.ToString()).Value = param.RSI;
                    number++;

                    Thread.Sleep(500);
                    Console.WriteLine(c.ToString());
                    c++;
                    if (c%20 == 0)
                    {
                        Thread.Sleep(5000);
                    }
                }
                DateTime dateTime = DateTime.UtcNow.Date;
                workbook.SaveAs(@"C:\Users\pkubo\OneDrive\Desktop\Stocks_Excel\Stocks-" + dateTime.ToString("yyyy/MM/dd") + ".xlsx");

            }
            Console.WriteLine("Koniec :)");
        }
    }
}
