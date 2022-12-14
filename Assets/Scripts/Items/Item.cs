using Items.Scripts;

namespace Items
{
    public class Item : Interactable
    {
        public ItemObject item;
        public override void Interact(InteractPoint interactPoint)
        {
            interactPoint.AddItem(this);
            Destroy(gameObject);
        }
    }
}
