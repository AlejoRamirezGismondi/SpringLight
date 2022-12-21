using Items;
using Items.Scripts;
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

        public void AddItem(ItemObject item, int amount)
        {
            inventory.AddItem(item, amount);
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