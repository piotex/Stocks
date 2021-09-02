using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Stocks.GetInfo
{
    public class GetParams
    {
        public void GetParam(ref Info ret, string link)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
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
                    _getParam(ref data, ref startIndex, ref ret);
                    ret.Link = link;
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        private void _getParam(ref string body, ref int startIndex, ref Info info)
        {
            //for (int i = 0; i < 5; i++)
            bool ok = true;

            info.Kurs = _getKurs(ref body, ref startIndex);
            _getZM(ref body, ref startIndex);
            info.Zmiana1D = _getZM(ref body, ref startIndex);
            info.Zmiana7D = _getZM(ref body, ref startIndex);
            info.Zmiana1M = _getZM(ref body, ref startIndex);
            info.Zmiana3M = _getZM(ref body, ref startIndex);
            info.Zmiana1R = _getZM(ref body, ref startIndex);
            //_getPrzychZeSprzed(ref body, ref startIndex);
            info.PrzychodyZeSprzedarzy = _getPrzychZeSprzed(ref body, ref startIndex);
            info.PrzychodyZeSprzedarzy_Proc = _getEbita(ref body, ref startIndex);
            info.EBIT = _getPrzychZeSprzed(ref body, ref startIndex);
            info.EBIT_Proc = _getEbita(ref body, ref startIndex);

            while (ok)
            {
                int startIndex2 = startIndex;
                string sss2 = _getParamName2(ref body, ref startIndex2);
                string sss = _getParamName(ref body, ref startIndex);
                if (sss == "C/WK")
                    info.C_WK = _getParamVal(ref body, ref startIndex);
                if (sss == "C/P")
                    info.C_P = _getParamVal(ref body, ref startIndex);
                if (sss == "C/Z")
                    info.C_Z = _getParamVal(ref body, ref startIndex);
                if (sss == "C/ZO")
                    info.C_ZO = _getParamVal(ref body, ref startIndex);

                if (sss2 == "ROE")
                {
                    startIndex += 161;
                    info.ROE = _getParamVal(ref body, ref startIndex);
                    info.ROE = info.ROE.Remove(info.ROE.Length - 1);        //usuniecie znaku: % z wartosci zeby mozna bylo sortowac
                    info.ROE = info.ROE.Replace('.',',');
                }
                if (sss2 == "ROA")
                    info.ROA = _getParamVal(ref body, ref startIndex);

                if (sss == "")
                {
                    ok = false;
                    break;
                }
            }
            info.Ocena += _getOCENA(ref body, ref startIndex) + "\r\n";
            info.Ocena += _getOCENA(ref body, ref startIndex) + "\r\n";
            info.Ocena += _getOCENA(ref body, ref startIndex) + "\r\n";
            info.Ocena += _getOCENA(ref body, ref startIndex) + "\r\n";
            info.Ocena += _getOCENA(ref body, ref startIndex) ;
        }
        private string _getOCENA(ref string body, ref int startIndex)
        {
            isNext(ref body, ref startIndex, "mówią wskaźniki");
            char critic = '<';
            string ret = "";
            string hrf = "<td class=\"action";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                bool ok = false;
                while (body[startIndex] != critic)
                {
                    if (ok)
                    {
                        ret += body[startIndex];
                    }
                    if (body[startIndex] == '>')
                    {
                        ok = true;
                    }
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getPrzychZeSprzed(ref string body, ref int startIndex)
        {
            char critic = '<';
            string ret = "";
            string hrf = "ss=\"pv\"><span>";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getEbita(ref string body, ref int startIndex)
        {
            char critic = '%';
            string ret = "";
            string hrf = "n class=\"q_ch_per";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                bool ok = false;
                while (body[startIndex] != critic)
                {
                    if (ok)
                    {
                        ret += body[startIndex];
                    }
                    if (body[startIndex] == '>')
                    {
                        ok = true;
                    }
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getZM(ref string body, ref int startIndex)
        {
            char critic = '%';
            string ret = "";
            string hrf = "q_ch_per ";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                bool ok = false;
                while (body[startIndex] != critic)
                {
                    if (ok)
                    {
                        ret += body[startIndex];
                    }
                    if (body[startIndex] == '(')
                    {
                        ok = true;
                    }
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getKurs(ref string body, ref int startIndex)
        {
            char critic = '<';
            string ret = "";
            string hrf = "<span class=\"q_ch_act\">";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getParamName(ref string body, ref int startIndex)
        {
            char critic = '<';
            string ret = "";
            string hrf = "<td class=\"name\"><div>";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getParamName2(ref string body, ref int startIndex)
        {
            char critic = '<';
            string ret = "";
            string hrf = "<td class=\"name\">";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        private string _getParamVal(ref string body, ref int startIndex)
        {
            char critic = '<';
            string ret = "";
            string hrf = "pv\"><span>";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
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
                    if (body[(i + j)] != nextString[j])
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