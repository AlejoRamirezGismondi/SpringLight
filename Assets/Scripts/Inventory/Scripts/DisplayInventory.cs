using System.Collections.Generic;
using Items.Scripts;
using TMPro;
using UnityEngine;

namespace Inventory.Scripts
{
    public class DisplayInventory : MonoBehaviour
    {
        public InventoryObject inventory;
        [SerializeField] private int NUMBER_OF_COLUMNS;
        private readonly Dictionary<InventorySlot, GameObject> _itemsDisplayed = new();
        private void Start()
        {
            CreateDisplay();
        }
        private void Update()
        {
            UpdateDisplay();
        }
        private void CreateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                if (i >= 9) break;
                var obj = Instantiate(inventory.container[i].itemObject.inventoryDisplayPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                if (inventory.container[i].itemObject.type != ItemType.Tool)
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                _itemsDisplayed.Add(inventory.container[i], obj);
            }
        }
        private void UpdateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                if (i >= 9) break;
                if (_itemsDisplayed.ContainsKey(inventory.container[i]))
                {
                    if (inventory.container[i].itemObject.type != ItemType.Tool)
                        _itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(inventory.container[i].itemObject.inventoryDisplayPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                    if (inventory.container[i].itemObject.type != ItemType.Tool)
                        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                    _itemsDisplayed.Add(inventory.container[i], obj);
                }
            }
        }
        private Vector3 GetPosition(int i)
        {
            // TODO change 1700 to be dynamic
            return new Vector3(-750 + i * 1700 / NUMBER_OF_COLUMNS, 100, 0);
        }
    }
}
