using Inventory.Scripts;
using Items.Scripts;
using Newtonsoft.Json;

namespace Crops.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    public class GrownState : CropState
    {
        public CropObject cropObject;

        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is not ToolObject { toolType: ToolType.Scythe }) return;
            inventoryComponent.AddItem(cropObject.produce, cropObject.amountOfProduce);
            cropTile.Reset();
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