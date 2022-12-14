using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
    public class SeedObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Seed;
        }
    }
}