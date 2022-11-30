using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Skin
{
    public class SkinManager : MonoBehaviour
    {
        private string _code = "";
        private NetworkManager _networkManager;

        // Start is called before the first frame update
        void Start()
        {
            _networkManager = gameObject.GetComponent<NetworkManager>();
        }

        public void ReadStringCodeInput(string s)
        {
            _code = s;
        }

        public void EnterCode()
        {
            if (SkinRegistry.Contains(_code)) RefreshSkin();
            else GetSkin();
        }

        private void GetSkin()
        {
            if (_code.Length > 0) _networkManager.GetSprite(_code);
        }

        private void RefreshSkin()
        {
            string name = SkinRegistry.GetSkinName(_code);
            List<string> failed = new List<string>();
            AssetDatabase.DeleteAssets(new[]{$"Assets/Artwork/Character/Resources/{name}"}, failed);
            AssetDatabase.DeleteAsset($"Assets/Artwork/Character/Resources/Sprite_Libraries/{name}");
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