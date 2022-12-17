using Crops.CropState;
using Inventory.Scripts;
using UnityEngine;

namespace Crops
{
    public class CropTile : Interactable
    {
        public SpriteRenderer spriteRenderer;
        public Sprite unplowed;
        public Sprite plowed;
        public Crop Crop;
        private CropState.CropState State { get; set; }

        public void Start()
        {
            State = new UnplowedState(this);
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            State = State.NextState(this);
        }
    }
}