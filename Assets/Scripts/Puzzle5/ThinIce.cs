using UnityEngine;

namespace Puzzle5
{
    public class ThinIce : MonoBehaviour
    {
        private bool _consumed;
        private SpriteRenderer _spriteRenderer;
        private ThinIceManager _manager;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _manager = gameObject.GetComponentInParent<ThinIceManager>();
            _manager = FindObjectOfType<ThinIceManager>();
        }

        private void Start()
        {
            Reset();
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) Consume();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") && _consumed) _manager.PlayerHasFallen(col.gameObject);
        }

        private void Consume()
        {
            _consumed = true;
            _spriteRenderer.enabled = false;
        }

        public void Reset()
        {
            _consumed = false;
            _spriteRenderer.enabled = true;
        }

        public bool IsConsumed()
        {
            return _consumed;
        }
    }
}
