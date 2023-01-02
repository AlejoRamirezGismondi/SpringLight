using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Empty", menuName = "Inventory/Empty")]
    public class EmptyObject : ItemObject
    {
        private static EmptyObject _instance;

        public void Awake()
        {
            type = ItemType.Empty;
            uniqueItem = true;
        }

        // This is a singleton instance of the scriptable object EmptyObject that is used to represent an empty slot in the inventory
        public static EmptyObject emptyObject
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<EmptyObject>("Empty");
                }
                return _instance;
            }
        }
    }
}