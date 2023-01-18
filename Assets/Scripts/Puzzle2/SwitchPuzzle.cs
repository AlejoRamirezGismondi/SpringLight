using Interact;
using Inventory.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Puzzle2
{
    public class SwitchPuzzle : Interactable
    {
        [SerializeField] private SwitchPuzzle[] connectedPuzzles;
        [SerializeField] private Sprite activatedSprite;
        [SerializeField] private Sprite deactivatedSprite;
        [SerializeField] private bool activated;
        private SwitchPuzzleManager _manager;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            _manager = GetComponentInParent<SwitchPuzzleManager>();
        }

        void Start()
        {
            _spriteRenderer.sprite = activated ? activatedSprite : deactivatedSprite;
        }

        private void Flip()
        {
            activated = !activated;
            _spriteRenderer.sprite = activated ? activatedSprite : deactivatedSprite;
            _manager.SwitchWasFlipped();
        }
        
        public bool IsActivated()
        {
            return activated;
        }

        public void Activate()
        {
            activated = true;
            _spriteRenderer.sprite = activatedSprite;
        }
        
        public override void Interact(InventoryComponent inventoryComponent)
        {
            Flip();
            foreach (var puzzle in connectedPuzzles) puzzle.Flip();
        }
    }
}
