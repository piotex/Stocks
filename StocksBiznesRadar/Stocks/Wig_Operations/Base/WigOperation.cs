using ClosedXML.Excel;
using Stocks.GetInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Stocks.Wig_Operations.Base
{
    public class WigOperation
    {
        protected List<string> links;
        protected string SheetName;

        public virtual void SaveSector(XLWorkbook workbook)
        {
            int number = 2;
            
            IXLWorksheet worksheet = workbook.Worksheets.Add(SheetName);
            init_Sektor(worksheet);
            for (int i = 0; i < links.Count; i++)
            {
                string link = links[i];
                add_sub_Sektor(worksheet, link, ref number); 
            }
        }

        protected static void init_Sektor(IXLWorksheet worksheet)
        {
            int number = 1;
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
            worksheet.Cell("Q" + number.ToString()).Value = "ROE [%]";
            worksheet.Cell("R" + number.ToString()).Value = "ROA";
        }
        protected static void add_Sektor(IXLWorksheet worksheet, Info record, ref int number)
        {
            worksheet.Cell("A" + number.ToString()).Value = record.Link;
            worksheet.Cell("B" + number.ToString()).Value = record.Kurs;
            worksheet.Cell("C" + number.ToString()).Value = record.Zmiana1D;
            worksheet.Cell("D" + number.ToString()).Value = record.Zmiana7D;
            worksheet.Cell("E" + number.ToString()).Value = record.Zmiana1M;
            worksheet.Cell("F" + number.ToString()).Value = record.Zmiana3M;
            worksheet.Cell("G" + number.ToString()).Value = record.Zmiana1R;
            worksheet.Cell("H" + number.ToString()).Value = record.PrzychodyZeSprzedarzy + " PLN";
            worksheet.Cell("I" + number.ToString()).Value = record.PrzychodyZeSprzedarzy_Proc + "%";
            worksheet.Cell("J" + number.ToString()).Value = record.EBIT + " PLN";
            worksheet.Cell("K" + number.ToString()).Value = record.EBIT_Proc;
            worksheet.Cell("L" + number.ToString()).Value = record.Ocena;
            worksheet.Cell("M" + number.ToString()).Value = record.C_WK;
            worksheet.Cell("N" + number.ToString()).Value = record.C_P;
            worksheet.Cell("O" + number.ToString()).Value = record.C_Z;
            worksheet.Cell("P" + number.ToString()).Value = record.C_ZO;
            worksheet.Cell("Q" + number.ToString()).Value = record.ROE;
            worksheet.Cell("R" + number.ToString()).Value = record.ROA;
            number++;
        }
        protected void add_sub_Sektor(IXLWorksheet worksheet, string link, ref int number)
        {
            try
            {
                Info param = new Info();
                new GetParams().GetParam(ref param, link);
                add_Sektor(worksheet, param, ref number);

                Thread.Sleep(500);
            }
            catch (Exception eee)
            {
                Console.WriteLine("Wywalil sie: " + link);
            }
        }

        private void old_Version()
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
                    worksheet.Cell("H" + number.ToString()).Value = param.PrzychodyZeSprzedarzy + " PLN";
                    worksheet.Cell("I" + number.ToString()).Value = param.PrzychodyZeSprzedarzy_Proc + "%";
                    worksheet.Cell("J" + number.ToString()).Value = param.EBIT + " PLN";
                    worksheet.Cell("K" + number.ToString()).Value = param.EBIT_Proc + "%";
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
                    if (c % 20 == 0)
                    {
                        Thread.Sleep(5000);
                    }
                }
                DateTime dateTime = DateTime.UtcNow.Date;
                workbook.SaveAs(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\Stocks\Stocks_Excel\Stocks-" + dateTime.ToString("yyyy/MM/dd") + ".xlsx");

            }
            Console.WriteLine("Koniec :)");
        }
    }
}
