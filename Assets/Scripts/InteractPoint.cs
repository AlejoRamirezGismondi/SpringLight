using Inventory.Scripts;
using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    private InteractableComponent _interactingCollider;

    public void Interact()
    {
        if (_interactingCollider != null) _interactingCollider.Interact(inventory);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _interactingCollider = col.GetComponent<InteractableComponent>();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _interactingCollider = null;
    }

    private void OnApplicationQuit()
    {
        //inventory.container.Clear();
    }
}
