using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Unplowed")]
    public class UnplowedState : CropState
    {
        public Sprite sprite;

        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject.type != ItemType.Tool) return;
            ToolObject t = (ToolObject)inventoryComponent.GetSelectedSlot().itemObject;
            if (t.toolType == ToolType.Hoe) cropTile.SetState(nextState);
        }
        
        public override void Initialize(CropTile cropTile)
        {
            cropTile.SetSprite(sprite);
            cropTile.SetCropSprite(null);
        }

        public override void OnNextDay()
        {
            // Do nothing
        }
    }
}