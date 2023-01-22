using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items.Scripts
{
    public enum ItemType
    {
        Empty,
        Tool,
        Seed,
        Produce
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class ItemObject : ScriptableObject
    {
        public GameObject inventoryDisplayPrefab;
        public ItemType type;
        public bool uniqueItem;
    }
    
    public class ItemObjectConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            // string name = jo["name"].Value<string>();
            string type = jo["type"].Value<string>();
            Type t = Type.GetType(type);
            return jo.ToObject(t, serializer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ItemObject);
        }
        
        public override bool CanWrite => false;
    }
}