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
    public class GetPTV : GetBasic
    {
        private bool _ready;
        public GetPTV()
        {
            _ready = false;
        }

        public override List<string> Get(string linksssss)
        {
            GeckoWebBrowser browser = new GeckoWebBrowser();
            browser.DocumentCompleted += _DocumentCompleted;
            browser.Navigate(linksssss);
            while (!_ready)
            {
                Application.DoEvents();
            }
            string body = browser.Document.Body.InnerHtml;
            string link = "";
            int startIndex = 0;
            List<string> ret = new List<string>();
            bool ok = true;
            if (isNext(ref body, ref startIndex, "<h3 class=\"section-header\">WSKAŹNIKI</h3>"))
            {
                ok = getParam(ref body, ref startIndex, ref link);
                ret.Add(link);
                link = "";

                int old_id = startIndex;
                while (ok)
                {
                    ok = getParam(ref body, ref startIndex, ref link);
                    if (startIndex - old_id < 5000)
                    {
                        ret.Add(link);
                        old_id = startIndex;
                        link = "";
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return ret;
        }
        protected bool getParam(ref string body, ref int startIndex, ref string link)
        {
            if (isNext(ref body, ref startIndex, "<td class=\"name\"><div>"))
            {
                startIndex += "<td class=\"name\"><div>".Length;
                for (int i = 0; i < 4; i++)
                {
                    link += body[startIndex + i];
                }
                link += ": ";
                string theLast = "<span>";
                if (isNext(ref body, ref startIndex, theLast))
                {
                    startIndex += theLast.Length;
                    while (body[startIndex] != '<')
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
