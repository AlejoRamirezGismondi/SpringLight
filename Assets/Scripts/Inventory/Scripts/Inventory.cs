using System;
using System.Collections.Generic;
using Items.Scripts;
using UnityEngine;

namespace Inventory.Scripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class Inventory : ScriptableObject
    {
        public List<InventorySlot> container = new List<InventorySlot>();
        
        public void AddItem(Item item, int amount)
        {
            bool hasItem = false;
            foreach (var slot in container)
            {
                if (slot.item == item)
                {
                    slot.amount += amount;
                    hasItem = true;
                }
            }

            if (!hasItem)
            {
                container.Add(new InventorySlot(item, amount));
            }
        }
    }
    
    [Serializable]
    public class InventorySlot
    {
        public Item item;
        public int amount;
        public InventorySlot(Item item, int amount)
        {
            this.item = item;
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