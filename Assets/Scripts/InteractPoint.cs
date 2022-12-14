using Inventory.Scripts;
using Items;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractPoint : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;
    private InteractableComponent _interactingCollider;

    public void Interact()
    {
        if (_interactingCollider != null) _interactingCollider.Interact(this);
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item.item, 1);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        _interactingCollider = col.GetComponent<InteractableComponent>();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _interactingCollider = null;
    }
}
