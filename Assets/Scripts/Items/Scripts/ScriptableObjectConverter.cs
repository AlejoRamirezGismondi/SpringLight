using System;
using Newtonsoft.Json;
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
            writer.WriteValue(value.name);
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var path = _folderPath != "" ? _folderPath + "/" : "";
            return Resources.Load<T>(path + reader.Value);
        }
    }
}