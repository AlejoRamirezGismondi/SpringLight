using DataPersistence;
using DataPersistence.Data;
using UnityEngine;

namespace Shop
{
    public class ShopPersistence : MonoBehaviour, IDataPersistence
    {
        private ShopItem[] _shopItems;

        private void Awake()
        {
            _shopItems = FindObjectsOfType<ShopItem>();
        }

        public void LoadData(GameData data)
        {
            for (var i = 0; i < data.shopItemsBought.Length; i++)
            {
                _shopItems[i].bought = data.shopItemsBought[i];
                _shopItems[i].gameObject.SetActive(!data.shopItemsBought[i]);
            }
        }

        public void SaveData(GameData data)
        {
            bool[] activeItems = new bool[_shopItems.Length];
            for (var index = 0; index < _shopItems.Length; index++)
                activeItems[index] = _shopItems[index].bought;
            data.shopItemsBought = activeItems;
        }
    }
}