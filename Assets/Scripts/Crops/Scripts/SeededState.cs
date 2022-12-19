using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Seeded")]
    public class SeededState : CropState
    {
        private SeedObject _seedObject;
        
        public void SetSeedObject(SeedObject seedObject)
        {
            _seedObject = seedObject;
        }
        
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            //
        }

        public override void Initialize(CropTile cropTile)
        {
            cropTile.SetCropSprite(_seedObject.cropObject.seedSprite);
        }
    }
}