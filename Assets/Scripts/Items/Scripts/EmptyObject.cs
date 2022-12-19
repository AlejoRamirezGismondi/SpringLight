using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Empty", menuName = "Inventory/Empty")]
    public class EmptyObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Empty;
        }

        public static readonly EmptyObject emptyObject = CreateInstance<EmptyObject>();
    }
}