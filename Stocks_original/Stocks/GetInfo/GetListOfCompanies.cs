using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Stocks.GetInfo
{
    public class GetListOfCompanies 
    {
        private string _nc_link;
        private string _gpw_link;
        public GetListOfCompanies() 
        {
            _nc_link = "https://www.biznesradar.pl/gielda/newconnect";
            _gpw_link = "https://www.biznesradar.pl/gielda/akcje_gpw";
        }

        public void GetLIstOfCompanies(ref List<string> ret)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_gpw_link);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                string data = readStream.ReadToEnd();
                
                int startIndex = 0;
                _getList(ref data,ref startIndex, ref ret);
                response.Close();
                readStream.Close();
            }
            request = (HttpWebRequest)WebRequest.Create(_nc_link);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                string data = readStream.ReadToEnd();

                int startIndex = 0;
                _getList(ref data, ref startIndex, ref ret);
                response.Close();
                readStream.Close();
            }
        }

        private void _getList(ref string body, ref int startIndex, ref List<string> ret)
        {
            if (isNext(ref body, ref startIndex, "qTableFull\">"))
            {
                if (isNext(ref body, ref startIndex, "s_tt"))
                {
                    while (ret.Count < 15000 )
                    {
                        ret.Add(_getLink(ref body, ref startIndex));
                        if (ret[ret.Count - 1] == "" || ret[ret.Count - 1] == "https://www.biznesradar.pljavascript:void(0)")
                        {
                            ret.RemoveAt(ret.Count - 1);
                            break;
                        }
                    }
                }
            }

        }
        private string _getLink(ref string body, ref int startIndex)
        {
            char critic = '"';
            string ret = "https://www.biznesradar.pl";
            string hrf = "\" href=\"";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while(body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        protected bool isNext(ref string body, ref int startIndex, string nextString)
        {
            for (int i = startIndex; i < body.Length; i++)
            {
                bool notOk = false;
                for (int j = 0; j < nextString.Length; j++)
                {
                    if (body[ (i + j) ] != nextString[j])
                    {
                        notOk = true;
                        break;
                    }
                }
                if (!notOk)
                {
                    startIndex = i;
                    return true;
                }
            }
            return false;
        }
    }
}
