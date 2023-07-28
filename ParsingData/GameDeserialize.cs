using Newtonsoft.Json;


namespace ParsingData
{
    public class GameDeserialize : IDeserializer<RootObject, string>
    {
        public async Task<RootObject> Deserialize(string obj)
        {
           if(string.IsNullOrEmpty(obj))
           {
              throw new ArgumentNullException(nameof(obj));
           }
           var rObj = await Task.FromResult(JsonConvert.DeserializeObject<RootObject>(obj));
            
           if(rObj == null)
           {
              rObj = new RootObject();
           }

           return rObj;
        }
    }
}
