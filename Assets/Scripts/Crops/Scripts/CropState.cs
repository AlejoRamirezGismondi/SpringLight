using Inventory.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    public abstract class CropState : ScriptableObject
    {
        public CropState nextState;
        public abstract void Interact(CropTile cropTile, InventoryComponent inventoryComponent);
        public abstract void Initialize(CropTile cropTile);
    }
    
    // public class GrowingState : CropState
    // {
    //     
    // }
    //
    // public class GrownState : CropState
    // {
    //     
    // }
}