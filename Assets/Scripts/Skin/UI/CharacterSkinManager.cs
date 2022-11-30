using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Skin.UI
{
    public class CharacterSkinManager : MonoBehaviour
    {
        [SerializeField] private SpriteLibrary spriteLibrary;
        private SpriteLibraryAsset[] _skins;
        private int _currentSkinNumber;

        // Start is called before the first frame update
        void Start()
        {
            LoadAllSpriteLibraryAssets();
        }

        public void Next()
        {
            _currentSkinNumber++;
            if (_currentSkinNumber >= _skins.Length) _currentSkinNumber = 0;
            RefreshSkin();
        }

        public void Previous()
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
            spriteLibrary.spriteLibraryAsset = _skins[_currentSkinNumber];
            spriteLibrary.RefreshSpriteResolvers();
        }

        private void LoadAllSpriteLibraryAssets()
        {
            _skins = Resources.LoadAll<SpriteLibraryAsset>("Sprite_Libraries");
            if (_currentSkinNumber > _skins.Length) _currentSkinNumber = _skins.Length - 1;
            RefreshSkin();
        }
    }
}