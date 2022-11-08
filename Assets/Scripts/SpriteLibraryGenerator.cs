using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteLibraryGenerator : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;

    public void GenerateSpriteLibrary(string name)
    {
        var spriteLib = ScriptableObject.CreateInstance<SpriteLibraryAsset>();
        
        var sprites = Resources.LoadAll<Sprite>(name);

        for (int i = 0; i < 16; i++)
        {
            spriteLib.AddCategoryLabel(sprites[0], "Idle_Down", "0");
            spriteLib.AddCategoryLabel(sprites[4], "Idle_Up", "4");
            spriteLib.AddCategoryLabel(sprites[8], "Idle_Right", "8");
            spriteLib.AddCategoryLabel(sprites[12], "Idle_Left", "12");
            if (i < 4) spriteLib.AddCategoryLabel(sprites[i], "Walk_Down", i.ToString());
            else if (i < 8) spriteLib.AddCategoryLabel(sprites[i], "Walk_Up", i.ToString());
            else if (i < 12) spriteLib.AddCategoryLabel(sprites[i], "Walk_Right", i.ToString());
            else spriteLib.AddCategoryLabel(sprites[i], "Walk_Left", i.ToString());
        }

        AssetDatabase.CreateAsset(spriteLib, "Assets/Artwork/Character/Resources/Sprite_Libraries/" + name + ".asset");
        AssetDatabase.SaveAssets();
        
        skinManager.RefreshSpriteLibraryAssets();
    }
}