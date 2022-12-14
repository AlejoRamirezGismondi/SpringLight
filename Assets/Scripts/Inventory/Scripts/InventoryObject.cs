using System;
using System.Collections.Generic;
using Items.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Scripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        public List<InventorySlot> container = new List<InventorySlot>();
        
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