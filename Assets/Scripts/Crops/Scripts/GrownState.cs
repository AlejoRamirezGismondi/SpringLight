using Inventory.Scripts;
using Items.Scripts;
using Newtonsoft.Json;
using UnityEngine;

namespace Crops.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    public class GrownState : CropState
    {
        public CropObject CropObject;

        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is not ToolObject { toolType: ToolType.Scythe }) return;
            inventoryComponent.AddItem(CropObject.produce, CropObject.amountOfProduce);
            cropTile.Reset();
        }

        public override void Initialize(CropTile cropTile)
        {
            cropTile.SetCropSprite(CropObject.grownSprite);
            var sprites = Resources.LoadAll<Sprite>("CropStateSprites");
            cropTile.SetSprite(sprites[1]);
        }

        public override void OnNextDay()
        {
            // Do nothing
        }
    }
}