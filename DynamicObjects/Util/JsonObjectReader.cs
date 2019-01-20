using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicObjects.Util
{
    public class JsonObjectReader
    {
        public object Load(Type type, string filename)
        {
            if (!File.Exists(filename))
                return Activator.CreateInstance(type);

            var jsonFile = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject(jsonFile, type);
        }
        public JObject LoadJsonObject(string filename)
        {
            dynamic objDynamic=null;
            if (!File.Exists(filename))
                return objDynamic;

            var jsonFile = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject<JObject>(jsonFile);
        }
    }
}
