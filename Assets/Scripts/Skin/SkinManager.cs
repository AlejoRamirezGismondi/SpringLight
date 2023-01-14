using System.Collections.Generic;
using Skin.UI;
using UnityEngine;

namespace Skin
{
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
        }

        public void ReadStringCodeInput(string s)
        {
            _code = s;
        }

        public void EnterCode()
        {
            if (SkinRegistry.Contains(_code)) RefreshSkin(SkinRegistry.GetSkinName(_code));
            else GetSkin();
        }

        public void RefreshSkin()
        {
            string currentName = _characterSkinManager.GetCurrentSkinName();
            if (currentName.Equals("Character 1") || currentName.Equals("Character")) return;
            RefreshSkin(currentName);
        }

        private void GetSkin()
        {
            if (_code.Length > 0) _networkManager.GetSprite(_code);
        }

        private void RefreshSkin(string name)
        {
            List<string> failed = new List<string>();
            // AssetDatabase.DeleteAssets(new[] { $"Assets/Artwork/Character/Resources/{name}" }, failed);
            // AssetDatabase.DeleteAsset($"Assets/Artwork/Character/Resources/Sprite_Libraries/{name}");
            if (failed.Count <= 0) GetSkin();
            else
            {
                foreach (var err in failed)
                {
                    Debug.Log(err);
                }
            }
        }
    }
}