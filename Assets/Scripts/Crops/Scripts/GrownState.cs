using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Grown")]
    public class GrownState : CropState
    {
        public CropObject cropObject;
        public int amountOfProduce;
        
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            var tool = inventoryComponent.GetSelectedSlot().itemObject;
            if (tool.type != ItemType.Tool || tool.name != "Scythe") return;
            inventoryComponent.AddItem(cropObject.produce, amountOfProduce);
            cropTile.SetState(nextState);
        }

        public override void Initialize(CropTile cropTile)
        {
            cropTile.SetCropSprite(cropObject.grownSprite);
        }

        public override void OnNextDay()
        {
            // Do nothing
        }
    }
}