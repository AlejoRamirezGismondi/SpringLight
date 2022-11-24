using TMPro;
using UnityEngine;

namespace Skin.UI
{
    public class SkinNumberDisplay : MonoBehaviour
    {
        [SerializeField] private CharacterSkinManager characterSkinManager;
        private TextMeshProUGUI text;
    
        // Start is called before the first frame update
        void Start()
        {
            text = gameObject.GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            text.text = $"{characterSkinManager.GetCurrentSkinNumber() + 1} / {characterSkinManager.GetTotalSkins()}";
        }
    }
}
