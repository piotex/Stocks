using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Stocks.GetInfo
{
    public class GetParams
    {
        public void GetDockBody(ref string body, string link)
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
                    body = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Info FilterBodyToGetInfo(ref string body)
        {
            Info ret = new Info();
            try
            {
                int startIndex = 0;
                ret.Kurs += _get_DATA(ref body, ref startIndex, "q_ch_act\">", '<');
                ret.Kurs += _get_DATA(ref body, ref startIndex, "q_ch_act\">", '<');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }   
        
        private string _get_DATA(ref string body, ref int startIndex, string prefix, char endChar)
        {
            string ret = "";
            if (isNext(ref body, ref startIndex, prefix))
            {
                startIndex += prefix.Length;
                while (body[startIndex] != endChar)
                {
                    ret += body[startIndex];
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