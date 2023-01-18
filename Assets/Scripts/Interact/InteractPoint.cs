using Inventory.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interact
{
    public class InteractPoint : MonoBehaviour
    {
        [SerializeField] private InventoryComponent inventory;
        [FormerlySerializedAs("_interactingCollider")] [SerializeField] private InteractableComponent interactingCollider;

        public void Interact()
        {
            if (interactingCollider != null) interactingCollider.Interact(inventory);
        }
    
        private void OnTriggerExit2D(Collider2D col)
        {
            interactingCollider = null;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            interactingCollider = col.GetComponent<InteractableComponent>();
        }

        private void OnApplicationQuit()
        {
            //inventory.container.Clear();
        }
    }
}
