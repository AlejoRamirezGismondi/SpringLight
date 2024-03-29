﻿using System;
using System.Collections.Generic;
using System.Linq;
using Items.Scripts;
using Newtonsoft.Json;
using UnityEngine;

namespace Inventory.Scripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        public List<InventorySlot> container = new();
        public int selectedSlot;
        public readonly int MaxCapacity = 9;

        // I believe this is only triggered when the Scriptable Object is first created, not on the regular Monobehabior Awake method
        public void Awake()
        {
            if (container.Count > 0) return;
            for (int i = 0; i < MaxCapacity; i++) container.Insert(i, new InventorySlot(EmptyObject.emptyObject, 1));
        }

        public void AddItem(ItemObject itemObject, int amount)
        {
            bool hasItem = false;
            foreach (var slot in container.Where(slot => slot.itemObject == itemObject))
            {
                slot.amount += amount;
                hasItem = true;
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

        // If n is out of bounds, it will just select the first slot
        // Otherwise, it will select the slot at index n
        public void SelectSlot(int n)
        {
            if (n < 0 || n >= MaxCapacity) selectedSlot = 0;
            else selectedSlot = n;
        }

        public InventorySlot GetSelectedSlot()
        {
            return container[selectedSlot];
        }

        public void RemoveSelectedItem(int amount)
        {
            container[selectedSlot].amount -= amount;
            if (container[selectedSlot].amount <= 0)
                container[selectedSlot] = new InventorySlot(EmptyObject.emptyObject, 1);
        }
    }

    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
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