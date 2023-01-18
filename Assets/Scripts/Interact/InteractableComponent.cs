using Inventory.Scripts;
using UnityEngine;

namespace Interact
{
    public class InteractableComponent : MonoBehaviour
    {
        private Interactable _interactable;
   
        private void Start()
        {
            _interactable = GetComponent(typeof(Interactable)) as Interactable;
        }

        public void Interact(InventoryComponent inventoryComponent)
        {
            if (_interactable != null) _interactable.Interact(inventoryComponent);
        }
    }
}