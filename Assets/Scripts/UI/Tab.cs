using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Tab : MonoBehaviour
    {
        private static readonly Color GrayedOut = new(0.65f,0.65f, 0.65f);
        private static readonly Color White = new(1,1, 1);

        private Image _image;
        private Vector3 pos;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            pos = transform.position;
        }

        public void GrayOut()
        {
            _image.color = GrayedOut;
            pos = new Vector3(pos.x, pos.y, -1);
        }

        public void Activate()
        {
            _image.color = White;
            pos = new Vector3(pos.x, pos.y, 0);
        }
    }
}
