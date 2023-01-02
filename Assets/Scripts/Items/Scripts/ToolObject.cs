using UnityEngine;

namespace Items.Scripts
{
    public enum ToolType
    {
        Hoe,
        Scythe,
        WaterCan
    }
    
    [CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
    public class ToolObject : ItemObject
    {
        public ToolType toolType;
        
        public void Awake()
        {
            type = ItemType.Tool;
            uniqueItem = true;
        }
    }
}