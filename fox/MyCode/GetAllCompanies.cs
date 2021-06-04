using Gecko;
using Gecko.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fox.MyCode
{
    public class GetAllCompanies : GetBasic
    {
        private bool _ready;
        public GetAllCompanies()
        {
            _ready = false;
        }

        public override List<string> Get(string linkssss)
        {
            GeckoWebBrowser browser = new GeckoWebBrowser();
            browser.DocumentCompleted += _DocumentCompleted;
            browser.Navigate("https://www.biznesradar.pl/gielda/akcje_gpw");
            while (!_ready)
            {
                Application.DoEvents();
            }
            string body = browser.Document.Body.InnerHtml;
            string link = "";
            int startIndex = 0;
            List<string> ret = new List<string>();
            bool ok = true;
            if (isNext(ref body, ref startIndex, "class=\"qTableFull\">"))
            {
                while (ok)
                {
                    ok = getParam(ref body, ref startIndex, ref link);
                    ret.Add(link);
                    if (link == "/notowania/ZYWIEC")
                    {
                        link = "";
                        break;
                    }
                    link = "";
                }
            }
            _ready = false;
            browser.Navigate("https://www.biznesradar.pl/gielda/newconnect");
            while (!_ready)
            {
                Application.DoEvents();
            }
            body = browser.Document.Body.InnerHtml;
            link = "";
            startIndex = 0;
            ok = true;
            if (isNext(ref body, ref startIndex, "class=\"qTableFull\">"))
            {
                while (ok)
                {
                    ok = getParam(ref body, ref startIndex, ref link);
                    ret.Add(link);
                    if (link == "/notowania/NEPTIS")
                    {
                        link = "";
                        break;
                    }
                    link = "";
                }
            }
            return ret;
        }

        protected bool getParam(ref string body, ref int startIndex, ref string link)
        {
            if (isNext(ref body, ref startIndex, "id=\""))
            {
                string theLast = "href=\"";
                if (isNext(ref body, ref startIndex, theLast))
                {
                    startIndex += theLast.Length;
                    while (body[startIndex] != '"')
                    {
                        link += body[startIndex];
                        startIndex++;
                    }
                    return true;
                }
            }
            return false;
        }

        private void _DocumentCompleted(object sender, GeckoDocumentCompletedEventArgs e)
        {
            _ready = true;
        }
    }
}
