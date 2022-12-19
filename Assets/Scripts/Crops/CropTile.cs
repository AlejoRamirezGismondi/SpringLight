using Crops.Scripts;
using Inventory.Scripts;
using UnityEngine;

namespace Crops
{
    public class CropTile : Interactable
    {
        private CropState State { set; get; }
        [SerializeField] private CropState initialState;
        [SerializeField] private SpriteRenderer cropSpriteRenderer;
        private SpriteRenderer _spriteRenderer;

        public void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            State = initialState;
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            State.Interact(this, inventoryComponent);
        }

        public void SetSprite(Sprite sprite)
        {
            if (sprite != null) _spriteRenderer.sprite = sprite;
        }
        
        public void SetCropSprite(Sprite sprite)
        {
            if (sprite != null) cropSpriteRenderer.sprite = sprite;
        }

        public void SetState(CropState newState)
        {
            State = newState;
            State.Initialize(this);
        }
    }
}