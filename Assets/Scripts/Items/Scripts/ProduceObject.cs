using Newtonsoft.Json;
using UnityEngine;

namespace Items.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    [CreateAssetMenu(fileName = "New Produce", menuName = "Inventory/Produce")]
    public class ProduceObject : ItemObject
    {
        public int value = 1;
        
        public void Awake()
        {
            type = ItemType.Produce;
            uniqueItem = false;
        }
    }
}