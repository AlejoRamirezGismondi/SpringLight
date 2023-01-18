using Inventory.Scripts;
using UnityEngine;

namespace Interact
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact(InventoryComponent inventoryComponent);
    }
}