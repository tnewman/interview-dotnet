using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GroceryStoreAPI.JSON
{
    public class JSONDatabase
    {
        public JSONData loadJSONData()
        {
            using (StreamReader file = File.OpenText(@"database.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject json = (JObject)JToken.ReadFrom(reader);
                return json.ToObject<JSONData>();
            }
        }

        public JSONData saveJSONData(JSONData jsonData)
        {
            using (StreamWriter file = File.CreateText(@"database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, jsonData);
            }

            return jsonData;
        }
    }
}
