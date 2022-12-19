using UnityEngine;

namespace Items.Scripts
{
    public enum ItemType
    {
        Empty,
        Tool,
        Seed
    }
    
    public abstract class ItemObject : ScriptableObject
    {
        public GameObject inventoryDisplayPrefab;
        public ItemType type;
    }
}