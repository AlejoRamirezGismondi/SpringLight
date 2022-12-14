using UnityEngine;

namespace Items.Scripts
{
    public enum ItemType
    {
        Tool,
        Seed
    }
    
    public abstract class ItemObject : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;
    }
}