using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    public class UnplowedState : CropState
    {
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is not ToolObject t) return;
            if (t.toolType == ToolType.Hoe) cropTile.SetState(new PlowedState());
        }
        
        public override void Initialize(CropTile cropTile)
        {
            var sprites = Resources.LoadAll<Sprite>("CropStateSprites");
            cropTile.SetSprite(sprites[0]);
            cropTile.SetCropSprite(null);
        }

        public override void OnNextDay()
        {
            // Do nothing
        }
    }
}