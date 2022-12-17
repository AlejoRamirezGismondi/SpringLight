using Items;
using UnityEngine;

namespace Inventory.Scripts
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventoryObject inventory;
        
        public void AddItem(Item item)
        {
            inventory.AddItem(item.item, 1);
        }
    }
}