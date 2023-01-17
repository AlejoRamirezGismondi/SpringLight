using Inventory.Scripts;
using Newtonsoft.Json;

namespace Crops.Scripts
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GrowingState : CropState
    {
        private CropTile _cropTile;
        [JsonProperty] public CropObject CropObject;
        [JsonProperty] private int _elapsedDays;
        
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            // Do nothing
        }

        public override void Initialize(CropTile cropTile)
        {
            _cropTile = cropTile;
            cropTile.SetCropSprite(CropObject.growingSprite);
        }

        public override void OnNextDay()
        {
            if (!_cropTile.IsWatered()) return;
            if (_elapsedDays >= CropObject.daysToGrow)
            {
                GrownState g = new GrownState
                {
                    cropObject = CropObject
                };
                _cropTile.SetState(g);
            }
            else _elapsedDays++;
        }
    }
}