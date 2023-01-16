using System.Collections.Generic;
using System.Linq;
using Inventory.Scripts;
using Items.Scripts;

namespace Widgets
{
    public class SellBin : Interactable, IDayChangeObserver
    {
        private readonly List<ProduceObject> _itemsToSell = new();
        private CoinCounter _coinCounter;

        private void Start()
        {
            _coinCounter = FindObjectOfType<CoinCounter>();
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            ItemObject item = inventoryComponent.GetSelectedSlot().itemObject;
            if (item is not ProduceObject produceObject) return;
            
            _itemsToSell.Add(produceObject);
            inventoryComponent.RemoveSelectedItem(1);
        }

        public void NextDay()
        {
            // Calculate the total value of the items to sell
            var totalValue = _itemsToSell.Sum(produceObject => produceObject.value);
            // Add the total value to the player's money
            _coinCounter.AddCoins(totalValue);
            // Clear List
            _itemsToSell.Clear();
        }
    }
}
