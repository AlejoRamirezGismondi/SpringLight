using Skin.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skin
{
    /**
     * This class is responsible for the UI of the skin manager
     * It is responsible for the following:
     * - Refreshing the current skin
     * - Getting a new skin
     * - Reading the code from the input field
     */
    public class SkinManager : MonoBehaviour
    {
        private string _code = "";
        private NetworkManager _networkManager;
        private CharacterSkinManager _characterSkinManager;

        // Start is called before the first frame update
        void Start()
        {
            _networkManager = gameObject.GetComponent<NetworkManager>();
            _characterSkinManager = GameObject.Find("CharacterSkinManager").GetComponent<CharacterSkinManager>();
            foreach (var button in FindObjectsOfType<Button>(true))
            {
                switch (button.name)
                {
                    case "Refresh":
                        button.onClick.AddListener(RefreshSkin);
                        break;
                    case "EnterCode":
                        button.onClick.AddListener(EnterCode);
                        break;
                }
            }

            var findObjectOfType = FindObjectOfType<TMP_InputField>(true);
            findObjectOfType.onValueChanged.AddListener(ReadStringCodeInput);
        }

        private void ReadStringCodeInput(string s)
        {
            _code = s;
        }

        private void EnterCode()
        {
            if (SkinRegistry.Contains(_code)) RefreshSkin(_code);
            else GetSkin(_code);
        }

        private void RefreshSkin()
        {
            string currentName = _characterSkinManager.GetCurrentSkinName();
            if (currentName.Equals("Character 1") || currentName.Equals("Character")) return;
            RefreshSkin(SkinRegistry.GetCodeForName(currentName));
        }

        private void GetSkin(string code)
        {
            if (code.Length > 0) _networkManager.GetSprite(code);
        }

        private void RefreshSkin(string code)
        {
            if (code == "") return;
            SkinRegistry.DeleteSkin(code);
            GetSkin(code);
        }
    }
}