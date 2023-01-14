using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Grown")]
    public class GrownState : CropState
    {
        public CropObject cropObject;

        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is not ToolObject { toolType: ToolType.Scythe }) return;
            inventoryComponent.AddItem(cropObject.produce, cropObject.amountOfProduce);
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