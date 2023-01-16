using Inventory.Scripts;
using UnityEngine;
using Widgets;

namespace Crops.Scripts
{
    public abstract class CropState
    {
        public abstract void Interact(CropTile cropTile, InventoryComponent inventoryComponent);
        public abstract void Initialize(CropTile cropTile);
        public abstract void OnNextDay();
    }
}