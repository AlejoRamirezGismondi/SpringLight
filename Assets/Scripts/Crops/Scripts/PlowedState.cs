using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    public class PlowedState : CropState
    {
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is not SeedObject o) return;
            // Maybe there is a better way to do this
            SeededState s = new SeededState();
            s.SetSeedObject(o);
            cropTile.SetState(s);
            inventoryComponent.RemoveSelectedItem(1);
        }

        public override void Initialize(CropTile cropTile)
        {
            var sprites = Resources.LoadAll<Sprite>("CropStateSprites");
            cropTile.SetSprite(sprites[1]);
            cropTile.SetCropSprite(null);
        }

        public override void OnNextDay()
        {
            // Do nothing
        }
    }
}