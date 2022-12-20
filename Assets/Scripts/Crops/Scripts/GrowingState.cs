using Inventory.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Growing")]
    public class GrowingState : CropState
    {
        private CropTile _cropTile;
        public CropObject cropObject;
        private int _elapsedDays;
        
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            // Do nothing
        }

        public override void Initialize(CropTile cropTile)
        {
            _cropTile = cropTile;
            cropTile.SetCropSprite(cropObject.growingSprite);
        }

        public override void OnNextDay()
        {
            if (_elapsedDays >= cropObject.daysToGrow)
            {
                // TODO Add the crop to the grown state
                _cropTile.SetState(nextState);
            }
            // TODO check for water
            else _elapsedDays++;
        }
    }
}