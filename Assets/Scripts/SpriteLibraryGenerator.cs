using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

public static class SpriteLibraryGenerator
{
    public static void GenerateSpriteLibrary(string name)
    {
        // TODO save images to folder

        var spriteLib = ScriptableObject.CreateInstance<SpriteLibraryAsset>();
        
        // TODO generate methods to add all categories
        // TODO get sprites from folder
        
        var sprite = Resources.Load<Sprite>(name + "/" + name);

        spriteLib.AddCategoryLabel(null, "Idle_Down", "Entry");
        
        AssetDatabase.CreateAsset(spriteLib, "Assets/Artwork/Character/Sprite_Libraries/" + name + ".asset");
    }
}