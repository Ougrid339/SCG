using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.COMMON.Utilities
{
    public static class JsonUtil
    {
        public static Func<string?, JObject?> StringToJsonObject = (str) =>
        {
            if (!String.IsNullOrEmpty(str))
            {
                try
                {
                    return JObject.Parse(str);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        };
    }
}
