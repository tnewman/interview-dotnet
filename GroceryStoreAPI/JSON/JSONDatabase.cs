using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
