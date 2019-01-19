using System;
using System.IO;
using Newtonsoft.Json;

namespace DynamicObjects.Util
{
    public class SettingsReader
    {
        private readonly string _configurationFilePath;
        private readonly string _classNameSuffix;

        public SettingsReader(string configurationFilePath, string classNameSuffix = "Settings")
        {
            _configurationFilePath = configurationFilePath;
            _classNameSuffix = classNameSuffix;
        }

        public T Load<T>() where T : class, new() => Load(typeof(T)) as T;

        public T LoadSection<T>() where T : class, new() => LoadSection(typeof(T)) as T;

        public object Load(Type type)
        {
            if (!File.Exists(_configurationFilePath))
                return Activator.CreateInstance(type);

            var jsonFile = File.ReadAllText(_configurationFilePath);

            return JsonConvert.DeserializeObject(jsonFile, type);
        }

        public object LoadSection(Type type)
        {
            if (!File.Exists(_configurationFilePath))
                return Activator.CreateInstance(type);

            var jsonFile = File.ReadAllText(_configurationFilePath);
            var section = ToCamelCase(type.Name.Replace(_classNameSuffix, string.Empty));
            var settingsData = JsonConvert.DeserializeObject<dynamic>(jsonFile);
            var settingsSection = settingsData[section];

            var ret = settingsSection == null
                ? Activator.CreateInstance(type)
                : JsonConvert.DeserializeObject(JsonConvert.SerializeObject(settingsSection), type);
            return ret;
        }

        private static string ToCamelCase(string text)
            => string.IsNullOrWhiteSpace(text)
                ? string.Empty
                : $"{text[0].ToString().ToLowerInvariant()}{text.Substring(1)}";
    }
}