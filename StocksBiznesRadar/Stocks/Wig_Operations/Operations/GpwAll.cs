using Stocks.GetInfo;
using Stocks.Wig_Operations.Base;
using System.Collections.Generic;

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
    }
}
