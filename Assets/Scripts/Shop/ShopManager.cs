using UnityEngine;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject shop;
        
        private void Start()
        {
            shop.SetActive(false);
        }
        
        public void OpenShop()
        {
            shop.SetActive(true);
        }
        
        public void CloseShop()
        {
            shop.SetActive(false);
        }
    }
}