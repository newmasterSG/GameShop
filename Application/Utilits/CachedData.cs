using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilits
{
    public static class CachedData
    {
        public static byte[] SerializeData(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }

        public static T DeserializeCachedData<T>(byte[] cachedData)
        {
            var json = Encoding.UTF8.GetString(cachedData);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
