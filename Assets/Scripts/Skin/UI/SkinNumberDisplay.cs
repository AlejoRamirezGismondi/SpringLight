using TMPro;
using UnityEngine;

namespace Skin.UI
{
    public class SkinNumberDisplay : MonoBehaviour
    {
        private CharacterSkinManager _characterSkinManager;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _characterSkinManager = FindObjectOfType<CharacterSkinManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _text = gameObject.GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _text.text = $"{_characterSkinManager.GetCurrentSkinNumber() + 1} / {_characterSkinManager.GetTotalSkins()}";
        }
    }
}
