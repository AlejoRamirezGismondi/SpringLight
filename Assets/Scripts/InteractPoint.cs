using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    private InteractableComponent _interactingCollider;

    public void Interact()
    {
        if (_interactingCollider != null) _interactingCollider.Interact();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        _interactingCollider = col.GetComponent<InteractableComponent>();
    }

    private void OnTriggerExit(Collider other)
    {
        _interactingCollider = null;
    }
}
