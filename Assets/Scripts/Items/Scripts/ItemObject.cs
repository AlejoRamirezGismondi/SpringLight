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
    
    public abstract class ItemObject : ScriptableObject
    {
        public GameObject inventoryDisplayPrefab;
        public ItemType type;
    }
}