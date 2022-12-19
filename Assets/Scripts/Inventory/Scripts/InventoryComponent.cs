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

        public void NextSelectedItem()
        {
            inventory.NextSelectedItem();
        }

        public void PreviousSelectedItem()
        {
            inventory.PreviousSelectedItem();
        }

        public InventorySlot GetSelectedSlot()
        {
            return inventory.GetSelectedSlot();
        }

        public void RemoveSelectedItem(int amount)
        {
            inventory.RemoveSelectedItem(amount);
        }
    }
}