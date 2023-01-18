using Inventory.Scripts;
using Items.Scripts;
using Newtonsoft.Json;
using UnityEngine;

namespace Crops.Scripts
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SeededState : CropState
    {
        private CropTile _cropTile;
        [JsonProperty] private SeedObject _seedObject;

        public void SetSeedObject(SeedObject seedObject)
        {
            _seedObject = seedObject;
        }

        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            // Do nothing
        }

        public override void Initialize(CropTile cropTile)
        {
            _cropTile = cropTile;
            cropTile.SetCropSprite(_seedObject.cropObject.seedSprite);
            var sprites = Resources.LoadAll<Sprite>("CropStateSprites");
            cropTile.SetSprite(sprites[1]);
        }

        public override void OnNextDay()
        {
            if (!_cropTile.IsWatered()) return;
            GrowingState g = new GrowingState
            {
                CropObject = _seedObject.cropObject
            };
            _cropTile.SetState(g);
        }
    }
}