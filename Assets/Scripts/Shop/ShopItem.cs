using Items.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopItem : MonoBehaviour
    {
        private Shop _shop;
        public ItemObject item;
        public int amount;
        public int price;
        public bool bought;
        
        public Image icon;
        public TextMeshProUGUI amountText;
        public TextMeshProUGUI priceText;
        public TextMeshProUGUI itemName;

        private void Awake()
        {
            _shop = FindObjectOfType<Shop>(true);
        }

        private void Start()
        {
            icon.sprite = item.inventoryDisplayPrefab.GetComponent<Image>().sprite;
            amountText.text = amount.ToString();
            priceText.text = price.ToString();
            itemName.text = item.name;
        }

        public void Buy()
        {
            _shop.BuyItem(this);
        }
    }
}
