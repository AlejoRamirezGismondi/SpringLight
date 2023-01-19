using Interact;
using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    /**
     * This class is used to create a new game object in the world.
     * This game object represents an item in the game.
     * The item it represents is stored as the ItemObject
     */
    public class Item : Interactable
    {
        public ItemObject item;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.sprite = item.inventoryDisplayPrefab.GetComponent<Image>().sprite;
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            inventoryComponent.AddItem(this);
            Destroy(gameObject);
        }
    }
}
