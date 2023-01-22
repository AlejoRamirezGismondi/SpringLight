using System.Collections.Generic;
using Crops.Scripts;
using Items.Scripts;
using Newtonsoft.Json;

namespace Inventory.Scripts
{
    public static class CustomConverters
    {
        public static List<JsonConverter> GetGameJsonConverters()
        {
            return new List<JsonConverter>()
            {
                new ScriptableObjectConverter<EmptyObject>(""),
                new ScriptableObjectConverter<ProduceObject>("Produce"),
                new ScriptableObjectConverter<SeedObject>("Seeds"),
                new ScriptableObjectConverter<ToolObject>("Tools"),
                new ScriptableObjectConverter<WaterCanToolObject>("Tools"),
                new ScriptableObjectConverter<CropObject>("Crops"),
                new ItemObjectConverter(),
            };
        }
    }
}