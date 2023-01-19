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
        public int selectedSlot;
        private const int MaxCapacity = 9;
        
        public void Awake()
        {
            if (container.Count != 0) return;
            for (int i = 0; i < MaxCapacity; i++) container.Insert(i, new InventorySlot(EmptyObject.emptyObject, 1));
        }

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
                InventorySlot slot = container.Find(slot => slot.itemObject == EmptyObject.emptyObject);
                slot.itemObject = itemObject;
                slot.amount = amount;
            }
        }

        public void NextSelectedItem()
        {
            if (selectedSlot < MaxCapacity - 1) selectedSlot++;
            else selectedSlot = 0;
        }

        public void PreviousSelectedItem()
        {
            if (selectedSlot > 0) selectedSlot--;
            else selectedSlot = MaxCapacity - 1;
        }
        
        public InventorySlot GetSelectedSlot()
        {
            return container[selectedSlot];
        }

        public void RemoveSelectedItem(int amount)
        {
            container[selectedSlot].amount -= amount;
            if (container[selectedSlot].amount <= 0) container[selectedSlot] = new InventorySlot(EmptyObject.emptyObject, 1);
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