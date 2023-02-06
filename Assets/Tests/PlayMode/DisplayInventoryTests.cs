using Inventory.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayMode
{
    public class DisplayInventoryTests
    {
        [Test]
        public void DisplayInventoryTestSimplePasses()
        {
            var gameObject = new GameObject();
            var displayInventory = gameObject.AddComponent<DisplayInventory>();
            displayInventory.inventory = ScriptableObject.CreateInstance<InventoryObject>();
            // Use the Assert class to test conditions
            Assert.AreEqual(9, displayInventory.inventory.container.Count);
        }
    }
}