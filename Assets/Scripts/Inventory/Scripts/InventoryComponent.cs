using Items;
using Items.Scripts;
using UnityEngine;

namespace Inventory.Scripts
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventoryObject inventory;
        private DisplayInventory _displayInventory;

        private void Awake()
        {
            _displayInventory = FindObjectOfType<DisplayInventory>();
        }

        public void AddItem(Item item)
        {
            inventory.AddItem(item.item, 1);
            _displayInventory.UpdateDisplay();
        }

        public void AddItem(ItemObject item, int amount)
        {
            inventory.AddItem(item, amount);
            _displayInventory.UpdateDisplay();
        }

        public void NextSelectedItem()
        {
            inventory.NextSelectedItem();
            _displayInventory.UpdateDisplay();
        }

        public void PreviousSelectedItem()
        {
            inventory.PreviousSelectedItem();
            _displayInventory.UpdateDisplay();
        }

        public InventorySlot GetSelectedSlot()
        {
            return inventory.GetSelectedSlot();
        }

        public void RemoveSelectedItem(int amount)
        {
            inventory.RemoveSelectedItem(amount);
            _displayInventory.UpdateDisplay();
        }
    }
}