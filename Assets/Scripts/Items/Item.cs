using Inventory.Scripts;
using Items.Scripts;

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
        public override void Interact(InventoryComponent inventoryComponent)
        {
            inventoryComponent.AddItem(this);
            Destroy(gameObject);
        }
    }
}
