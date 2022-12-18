using System;
using System.Collections.Generic;
using Items.Scripts;
using UnityEngine;

namespace Inventory.Scripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        public List<InventorySlot> container = new();
        public int selectedSlot = 0;
        
        public void AddItem(ItemObject itemObject, int amount)
        {
            bool hasItem = false;
            foreach (var slot in container)
            {
                if (slot.itemObject == itemObject)
                {
                    slot.amount += amount;
                    hasItem = true;
                }
            }

            if (!hasItem)
            {
                container.Add(new InventorySlot(itemObject, amount));
            }
        }

        public void NextSelectedItem()
        {
            if (selectedSlot < container.Count - 1) selectedSlot++;
            else selectedSlot = 0;
        }

        public void PreviousSelectedItem()
        {
            if (selectedSlot > 0) selectedSlot--;
            else selectedSlot = container.Count - 1;
        }
    }
    
    [Serializable]
    public class InventorySlot
    {
        public ItemObject itemObject;
        public int amount;
        public InventorySlot(ItemObject itemObject, int amount)
        {
            this.itemObject = itemObject;
            this.amount = amount;
        }
        public void AddAmount(int amount)
        {
            this.amount += amount;
        }
        public void RemoveAmount(int amount)
        {
            this.amount -= amount;
        }
    }
}