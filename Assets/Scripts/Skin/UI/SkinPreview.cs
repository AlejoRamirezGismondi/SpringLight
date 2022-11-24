using UnityEngine;

namespace Skin.UI
{
    public class SkinPreview : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private SpriteRenderer _mySpriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            _mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    
        private void ChangeSprite()
        {
            _mySpriteRenderer.sprite = spriteRenderer.sprite; 
        }

        // Update is called once per frame
        void Update()
        {
            // There might be a more efficient way than polling for the Sprite all the time, but it provides a simple way
            ChangeSprite();
        }
    }
}
