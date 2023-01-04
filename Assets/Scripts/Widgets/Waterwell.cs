using Inventory.Scripts;
using Items.Scripts;

namespace Widgets
{
    public class Waterwell : Interactable
    {
        public override void Interact(InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject is WaterCanToolObject o) o.AddWater(5);
        }
    }
}
