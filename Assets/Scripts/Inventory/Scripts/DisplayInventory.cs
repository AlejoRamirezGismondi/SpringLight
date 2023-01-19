using TMPro;
using UnityEngine;

namespace Inventory.Scripts
{
    public class DisplayInventory : MonoBehaviour
    {
        public InventoryObject inventory;
        private readonly GameObject[] _instantiatedSlots = new GameObject[9];

        private void Start()
        {
            CreateDisplay();
        }

        private void CreateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                var obj = Instantiate(inventory.container[i].itemObject.inventoryDisplayPrefab, Vector3.zero,
                    Quaternion.identity, transform);
                
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                if (!inventory.container[i].itemObject.uniqueItem) obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                
                if (i == inventory.selectedSlot) obj.transform.GetChild(1).gameObject.SetActive(true);
                _instantiatedSlots[i] = obj;
            }
        }

        public void UpdateDisplay()
        {
            foreach (var instantiatedSlot in _instantiatedSlots) Destroy(instantiatedSlot);
            CreateDisplay();
        }

        private Vector3 GetPosition(int i)
        {
            return new Vector3(-750 + i * 1700 / inventory.container.Count, 100, 0);
        }
    }
}