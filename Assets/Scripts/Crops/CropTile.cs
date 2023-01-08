using Crops.Scripts;
using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops
{
    public class CropTile : Interactable
    {
        private CropState State { set; get; }
        [SerializeField] private CropState initialState;
        [SerializeField] private SpriteRenderer cropSpriteRenderer;
        private SpriteRenderer _spriteRenderer;
        private bool _watered;

        // Cannot use Start because the state must be loaded from the CropManager in case there is Loaded Data.
        // Crop Manager has the responsibility of calling the Initialize method on every CropTile when the scene is loaded
        public void Initialize()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            State = initialState;
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject.type == ItemType.Tool)
            {
                ToolObject t = (ToolObject)inventoryComponent.GetSelectedSlot().itemObject;
                if (t.toolType == ToolType.WaterCan)
                {
                    WaterCanToolObject w = (WaterCanToolObject)t;
                    if (w.HasWater())
                    {
                        Water();
                        w.UseWater();
                    }
                }
            }
            State.Interact(this, inventoryComponent);
        }

        public void SetSprite(Sprite sprite)
        {
            if (sprite != null) _spriteRenderer.sprite = sprite;
        }

        public void SetCropSprite(Sprite sprite)
        {
            cropSpriteRenderer.sprite = sprite;
        }

        public void SetState(CropState newState)
        {
            State = newState;
            State.Initialize(this);
        }

        public void NextDay()
        {
            State.OnNextDay();
            _watered = false;
            // Remove the shade applied to the _spriteRenderer in the Water() method
            _spriteRenderer.color = Color.white;
        }

        private void Water()
        {
            _watered = true;
            // Apply a shade to the _spriteRenderer to indicate that the crop has been watered
            UpdateWateredColor();
        }

        public bool IsWatered()
        {
            return _watered;
        }

        private void UpdateWateredColor()
        {
            if (_watered) _spriteRenderer.color = new Color(0.4f, 0.4f, 0.4f, 1f);
        }
        
        public CropTileObject GetCropTileObject()
        {
            CropTileObject cropTileObject = ScriptableObject.CreateInstance<CropTileObject>();
            cropTileObject.initialState = initialState;
            cropTileObject.state = State;
            cropTileObject.watered = _watered;
            cropTileObject.sprite = _spriteRenderer.sprite;
            cropTileObject.cropSprite = cropSpriteRenderer.sprite;
            return cropTileObject;
        }

        public void LoadFromCropTileObject(CropTileObject cropTileObject)
        {
            initialState = cropTileObject.initialState;
            State = cropTileObject.state;
            
            _watered = cropTileObject.watered;
            UpdateWateredColor();

            _spriteRenderer.sprite = cropTileObject.sprite;
            if (cropTileObject.cropSprite) cropSpriteRenderer.sprite = cropTileObject.cropSprite;
        }
    }
}