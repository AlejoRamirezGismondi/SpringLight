using UnityEngine;

namespace Items.Scripts
{
    public enum ItemType
    {
        Tool
    }
    
    public abstract class Item : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;
    }
}