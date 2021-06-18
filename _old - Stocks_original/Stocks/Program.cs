using ClosedXML.Excel;
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

            Console.WriteLine("Start pobierania listy spolek...");
            int c = 0;
            int number = 1;
            List<string> links = new List<string>();
            new GetListOfCompanies().GetLIstOfCompanies(ref links);

            save_to_xml.SaveCompaniesList save = new save_to_xml.SaveCompaniesList();
            //save.WriteXML(links);


            //save.Read(ref links);

            GetParams getParams = new GetParams();


            Console.WriteLine("Start pobierania informacji o spolkach...");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A" + number.ToString()).Value = "Link";
                worksheet.Cell("B" + number.ToString()).Value = "Kurs";
                worksheet.Cell("C" + number.ToString()).Value = "Zmiana1D [%]";
                worksheet.Cell("D" + number.ToString()).Value = "Zmiana7D [%]";
                worksheet.Cell("E" + number.ToString()).Value = "Zmiana1M [%]";
                worksheet.Cell("F" + number.ToString()).Value = "Zmiana3M [%]";
                worksheet.Cell("G" + number.ToString()).Value = "Zmiana1R [%]";
                worksheet.Cell("H" + number.ToString()).Value = "Przychody Ze Sprzedarzy [val]";
                worksheet.Cell("I" + number.ToString()).Value = "Przychody Ze Sprzedarzy [% r/r]";
                worksheet.Cell("J" + number.ToString()).Value = "EBIT [val]";
                worksheet.Cell("K" + number.ToString()).Value = "EBIT [% r/r]";
                worksheet.Cell("L" + number.ToString()).Value = "Ocena";
                worksheet.Cell("M" + number.ToString()).Value = "C/WK";
                worksheet.Cell("N" + number.ToString()).Value = "C/P";
                worksheet.Cell("O" + number.ToString()).Value = "C/Z";
                worksheet.Cell("P" + number.ToString()).Value = "C/ZO";
                worksheet.Cell("Q" + number.ToString()).Value = "ROE";
                worksheet.Cell("R" + number.ToString()).Value = "ROA";
                number++;
                foreach (var link in links)
                {
                    Info param = new Info();
                    getParams.GetParam(ref param, link);
                    worksheet.Cell("A" + number.ToString()).Value = link;
                    worksheet.Cell("B" + number.ToString()).Value = param.Kurs;
                    worksheet.Cell("C" + number.ToString()).Value = param.Zmiana1D;
                    worksheet.Cell("D" + number.ToString()).Value = param.Zmiana7D;
                    worksheet.Cell("E" + number.ToString()).Value = param.Zmiana1M;
                    worksheet.Cell("F" + number.ToString()).Value = param.Zmiana3M;
                    worksheet.Cell("G" + number.ToString()).Value = param.Zmiana1R;
                    worksheet.Cell("H" + number.ToString()).Value = param.PrzychodyZeSprzedarzy+" PLN";
                    worksheet.Cell("I" + number.ToString()).Value = param.PrzychodyZeSprzedarzy_Proc+"%";
                    worksheet.Cell("J" + number.ToString()).Value = param.EBIT+" PLN";
                    worksheet.Cell("K" + number.ToString()).Value = param.EBIT_Proc+"%";
                    worksheet.Cell("L" + number.ToString()).Value = param.Ocena;
                    worksheet.Cell("M" + number.ToString()).Value = param.C_WK;
                    worksheet.Cell("N" + number.ToString()).Value = param.C_P;
                    worksheet.Cell("O" + number.ToString()).Value = param.C_Z;
                    worksheet.Cell("P" + number.ToString()).Value = param.C_ZO;
                    worksheet.Cell("Q" + number.ToString()).Value = param.ROE;
                    worksheet.Cell("R" + number.ToString()).Value = param.ROA;
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
