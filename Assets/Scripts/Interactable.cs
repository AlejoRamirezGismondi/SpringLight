using Inventory.Scripts;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(InventoryComponent inventoryComponent);
}