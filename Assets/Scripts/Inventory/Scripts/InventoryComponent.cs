using DataPersistence;
using DataPersistence.Data;
using Items;
using Items.Scripts;
using UnityEngine;

namespace Inventory.Scripts
{
    public class InventoryComponent : MonoBehaviour, IDataPersistence
    {
        [SerializeField] private InventoryObject inventory;
        private DisplayInventory _displayInventory;

        private void Awake()
        {
            _displayInventory = FindObjectOfType<DisplayInventory>();
            // This resets the inventory to be empty in case the Scriptable Object suffers problems with the data
            if (inventory.container.Count > 0) return;
            for (int i = 0; i < inventory.MaxCapacity; i++) inventory.container.Insert(i, new InventorySlot(EmptyObject.emptyObject, 1));
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

        public void LoadData(GameData data)
        {
            // Load all of the inventory data
            if (data.inventory.Count > 0) inventory.container = data.inventory; // Check in case of new game
            
            // Load the water can level
            foreach (var inventorySlot in inventory.container)
                if (inventorySlot.itemObject is WaterCanToolObject waterCan)
                    waterCan.waterAmount = data.waterCanAmount;
        }

        public void SaveData(GameData data)
        {
            // Save all of the inventory data
            data.inventory = inventory.container;
            
            // Save the water can level
            foreach (var inventorySlot in inventory.container)
                if (inventorySlot.itemObject is WaterCanToolObject waterCan)
                    data.waterCanAmount = waterCan.waterAmount;
        }
    }
}