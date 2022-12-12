using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
    private Interactable _interactable;
   
    private void Start()
    {
        _interactable = GetComponent(typeof(Interactable)) as Interactable;
    }

    public void Interact()
    {
        if (_interactable != null) _interactable.Interact();
    }
}