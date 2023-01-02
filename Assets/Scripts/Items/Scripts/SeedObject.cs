using Crops.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
    public class SeedObject : ItemObject
    {
        [FormerlySerializedAs("crop")] public CropObject cropObject;
        
        public void Awake()
        {
            type = ItemType.Seed;
            uniqueItem = false;
        }
    }
}