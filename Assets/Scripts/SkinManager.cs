using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinManager : MonoBehaviour
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
    }
}