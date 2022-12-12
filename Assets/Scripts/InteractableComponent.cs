using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
   private Interactable _interactable;
   
   private void Start()
   {
      _interactable = GetComponent<Interactable>();
   }

   public void Interact()
   {
      _interactable.Interact();
   }
}
