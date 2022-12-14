using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
    public class ToolObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Tool;
        }
    }
}