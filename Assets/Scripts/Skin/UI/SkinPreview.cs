using UnityEngine;
using UnityEngine.UI;

namespace Skin.UI
{
    public class SkinPreview : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Image myImage;

        private void Awake()
        {
            spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();
            myImage = gameObject.GetComponent<Image>();
        }

        private void ChangeSprite()
        {
            myImage.sprite = spriteRenderer.sprite;
        }

        // Update is called once per frame
        void Update()
        {
            // There might be a more efficient way than polling for the Sprite all the time, but it provides a simple way
            ChangeSprite();
        }
    }
}
