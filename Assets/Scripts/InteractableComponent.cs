using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
    private Interactable _interactable;
   
    private void Start()
    {
        _interactable = GetComponent(typeof(Interactable)) as Interactable;
    }

    public void Interact(InteractPoint interactPoint)
    {
        if (_interactable != null) _interactable.Interact(interactPoint);
    }
}