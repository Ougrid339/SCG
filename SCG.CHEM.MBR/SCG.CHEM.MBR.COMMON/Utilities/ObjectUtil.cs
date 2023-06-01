using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.MBR.COMMON.Utilities
{
    public static class ObjectUtil
    {
        public static void CopyProperties<T, TU>(T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(q => q.CanRead).ToList();
            var destProps = typeof(TU).GetProperties().Where(q => q.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(q => q.Name == sourceProp.Name))
                {
                    var p = destProps.First(q => q.Name == sourceProp.Name);

                    if (p.CanWrite)
                    {
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }

        public static TTarget Convert<TSource, TTarget>(TSource sourceItem)
        {
            if (null == sourceItem)
            {
                return default(TTarget);
            }

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace, NullValueHandling = NullValueHandling.Ignore };

            var serializedObject = JsonConvert.SerializeObject(sourceItem, deserializeSettings);

            return JsonConvert.DeserializeObject<TTarget>(serializedObject);
        }
    }
}
