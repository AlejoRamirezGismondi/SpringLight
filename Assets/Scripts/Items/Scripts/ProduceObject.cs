using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Produce", menuName = "Inventory/Produce")]
    public class ProduceObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Produce;
            uniqueItem = false;
        }
    }
}