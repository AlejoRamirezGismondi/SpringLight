using System;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

namespace Skin.UI
{
    /*
     * This class is responsible for managing the character skins.
     * It loads all the skins from the Resources folder and allows the user to switch between them.
     */
    public class CharacterSkinManager : MonoBehaviour
    {
        private SpriteLibrary _spriteLibrary;
        private SpriteLibraryAsset[] _skins;
        private int _currentSkinNumber;

        private void Awake()
        {
            _spriteLibrary = FindObjectOfType<SpriteLibrary>();
        }

        // Start is called before the first frame update
        void Start()
        {
            LoadAllSpriteLibraryAssets();
            foreach (var button in FindObjectsOfType<Button>(true))
            {
                switch (button.name)
                {
                    case "Next":
                        button.onClick.AddListener(Next);
                        break;
                    case "Previous":
                        button.onClick.AddListener(Previous);
                        break;
                }
            }
        }

        private void Next()
        {
            _currentSkinNumber++;
            if (_currentSkinNumber >= _skins.Length) _currentSkinNumber = 0;
            RefreshSkin();
        }

        private void Previous()
        {
            _currentSkinNumber--;
            if (_currentSkinNumber < 0) _currentSkinNumber = _skins.Length - 1;
            RefreshSkin();
        }

        public void RefreshSpriteLibraryAssets()
        {
            LoadAllSpriteLibraryAssets();
            _currentSkinNumber = 0;
            RefreshSkin();
        }

        public int GetCurrentSkinNumber()
        {
            return _currentSkinNumber;
        }

        public int GetTotalSkins()
        {
            return _skins.Length;
        }

        public string GetCurrentSkinName()
        {
            return _skins[_currentSkinNumber].name;
        }

        private void RefreshSkin()
        {
            _spriteLibrary.spriteLibraryAsset = _skins[_currentSkinNumber];
            _spriteLibrary.RefreshSpriteResolvers();
        }

        private void LoadAllSpriteLibraryAssets()
        {
            var spriteLibs = SkinRegistry.GetSpriteLibraryAssets();
            var defaultSkins = Resources.LoadAll<SpriteLibraryAsset>("Sprite_Libraries");
            _skins = new SpriteLibraryAsset[spriteLibs.Length + defaultSkins.Length];
            Array.Copy(spriteLibs, _skins, spriteLibs.Length);
            Array.Copy(defaultSkins, 0, _skins, spriteLibs.Length, defaultSkins.Length);
            if (_currentSkinNumber > _skins.Length) _currentSkinNumber = _skins.Length - 1;
            RefreshSkin();
        }
    }
}