using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Seeded")]
    public class SeededState : CropState
    {
        private CropTile _cropTile;
        private SeedObject _seedObject;

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
        }

        public override void OnNextDay()
        {
            if (!_cropTile.IsWatered()) return;
            GrowingState g = (GrowingState)nextState;
            g.cropObject = _seedObject.cropObject;
            _cropTile.SetState(nextState);
        }
    }
}