using Interact;
using Inventory.Scripts;

namespace Puzzle4
{
    public class RotatingPuzzle : Interactable
    {
        private RotatingPuzzleManager _manager;

        private void Awake()
        {
            _manager = GetComponentInParent<RotatingPuzzleManager>();
        }

        public override void Interact(InventoryComponent inventoryComponent)
        {
            Rotate();
            _manager.PuzzleWasRotated();
        }

        private void Rotate()
        {
            // Rotate transform 90 degrees clockwise
            transform.Rotate(0, 0, -90);
        }

        public void Rotate(int times)
        {
            for (int i = 0; i < times; i++) Rotate();
        }

        public bool IsUpright()
        {
            return transform.rotation.z % 360 == 0;
        }
    }
}
