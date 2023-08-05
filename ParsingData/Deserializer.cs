using Domain.Entities;
using Domain.Entities.Games;
using Newtonsoft.Json;


namespace ParsingData
{
    public class Deserializer<T> : IDeserializer<RootObject<T>, string> where T : EntityBase
    {
        public async Task<RootObject<T>> Deserialize(string obj)
        {
           if(string.IsNullOrEmpty(obj))
           {
              throw new ArgumentNullException(nameof(obj));
           }
           var rObj = await Task.FromResult(JsonConvert.DeserializeObject<RootObject<T>>(obj));
            
           if(rObj == null)
           {
              rObj = new RootObject<T>();
           }

           return rObj;
        }
    }
}
