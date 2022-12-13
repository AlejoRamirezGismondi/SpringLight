using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
    public class Tool : Item
    {
        public void Awake()
        {
            type = ItemType.Tool;
        }
    }
}