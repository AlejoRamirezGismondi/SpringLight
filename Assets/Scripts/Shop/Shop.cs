using Interact;
using Inventory.Scripts;
using UI;

namespace Shop
{
    public class Shop : Interactable
    {
        private ShopManager _shopManager;
        private CoinCounter _coinCounter;
        private InventoryComponent _inventory;

        private void Awake()
        {
            _shopManager = FindObjectOfType<ShopManager>();
            _coinCounter = FindObjectOfType<CoinCounter>();
            _inventory = FindObjectOfType<InventoryComponent>();
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            _shopManager.OpenShop();
        }

        public void BuyItem(ShopItem shopItem)
        {
            if (_coinCounter.CanBuy(shopItem.price))
            {
                _coinCounter.SubstractCoins(shopItem.price);
                _inventory.AddItem(shopItem.item, shopItem.amount);
                shopItem.gameObject.SetActive(false);
            }
            else
            {
                // Show error message
            }
        }
    }
}
