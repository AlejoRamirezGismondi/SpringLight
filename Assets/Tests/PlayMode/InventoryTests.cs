using Inventory.Scripts;
using Items.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayMode
{
    public class InventoryTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void InventoryObjectAwake()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            // Use the Assert class to test conditions
            Assert.AreEqual(9, inventoryObject.container.Count);
        }
        
        [Test]
        public void InventoryObjectAddItem()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.AddItem(EmptyObject.emptyObject, 1);
            // Use the Assert class to test conditions
            Assert.AreEqual(2, inventoryObject.container[0].amount);
        }
        
        [Test]
        public void InventoryObjectNextSelectedItem()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.NextSelectedItem();
            // Use the Assert class to test conditions
            Assert.AreEqual(1, inventoryObject.selectedSlot);
        }
        
        [Test]
        public void InventoryObjectPreviousSelectedItem()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.PreviousSelectedItem();
            // Use the Assert class to test conditions
            Assert.AreEqual(8, inventoryObject.selectedSlot);
        }
        
        [Test]
        public void InventoryObjectGetSelectedSlot()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.NextSelectedItem();
            // Use the Assert class to test conditions
            Assert.AreEqual(1, inventoryObject.GetSelectedSlot().amount);
        }
        
        [Test]
        public void InventoryObjectRemoveSelectedItem()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.RemoveSelectedItem(1);
            // Use the Assert class to test conditions
            Assert.AreEqual(1, inventoryObject.container[0].amount);
        }
        
        [Test]
        public void InventoryObjectRemoveSelectedItem2()
        {
            var inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
            inventoryObject.Awake();
            inventoryObject.RemoveSelectedItem(1);
            // Use the Assert class to test conditions
            Assert.AreEqual(EmptyObject.emptyObject, inventoryObject.container[0].itemObject);
        }
    }
}