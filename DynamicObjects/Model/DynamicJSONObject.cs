using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DynamicObjects.Model
{
    public class DynamicJSONObject
    {
        #region constructors

        private dynamic _obj;
        public DynamicJSONObject()
        {
        }

        public DynamicJSONObject(string jsonString)
        {
            _obj = JsonConvert.DeserializeObject(jsonString);
        }

        #endregion constructors

        public dynamic Dynamo
        {
            get => _obj;
        }
    }
}