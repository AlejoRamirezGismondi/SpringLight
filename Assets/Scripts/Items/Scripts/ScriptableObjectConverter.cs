using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items.Scripts
{
    public class ScriptableObjectConverter<T> : JsonConverter<T> where T: ScriptableObject
    {
        private readonly string _folderPath;
        
        public ScriptableObjectConverter(string folderPath)
        {
            _folderPath = folderPath;
        }

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            JObject jo = new JObject
            {
                { "name", value.name },
                { "type", typeof(T).FullName }
            };
            jo.WriteTo(writer);
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var path = _folderPath != "" ? _folderPath + "/" : "";
            var jo = JObject.Load(reader);
            var name = jo["name"].Value<string>();
            return Resources.Load<T>(path + name);
        }
    }
}