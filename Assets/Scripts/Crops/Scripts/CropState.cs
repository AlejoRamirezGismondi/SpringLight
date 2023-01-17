using Inventory.Scripts;
using Newtonsoft.Json;

namespace Crops.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    public abstract class CropState
    {
        public abstract void Interact(CropTile cropTile, InventoryComponent inventoryComponent);
        public abstract void Initialize(CropTile cropTile);
        public abstract void OnNextDay();
    }
}