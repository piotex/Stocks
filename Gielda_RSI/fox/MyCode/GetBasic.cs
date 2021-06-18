using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fox.MyCode
{
    public abstract class GetBasic : Interfaces.InterfaceGet
    {
        public abstract List<string> Get(string link);

        
        protected bool isNext(ref string body, ref int startIndex, string nextString)
        {
            for (int i = startIndex; i < body.Length; i++)
            {
                bool notOk = false;
                for (int j = 0; j < nextString.Length; j++)
                {
                    if (body[i + j] != nextString[j])
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
