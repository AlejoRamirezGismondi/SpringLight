﻿using System;
using System.Linq;
using Skin.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Skin
{
    public class SpriteLibraryGenerator : MonoBehaviour
    {
        [SerializeField] private CharacterSkinManager characterSkinManager;

        public void GenerateSpriteLibrary(string name)
        {
            var spriteLib = ScriptableObject.CreateInstance<SpriteLibraryAsset>();
        
            var sprites = Resources.LoadAll<Sprite>(name);
            Array.Sort(
                sprites, 
                (a, b) => int.Parse(a.name.Split('_').Last()).CompareTo(int.Parse(b.name.Split('_').Last()))
                );

            spriteLib.AddCategoryLabel(sprites[0], "Idle_Down", "0");
            spriteLib.AddCategoryLabel(sprites[4], "Idle_Up", "4");
            spriteLib.AddCategoryLabel(sprites[8], "Idle_Right", "8");
            spriteLib.AddCategoryLabel(sprites[12], "Idle_Left", "12");
            for (int i = 0; i < 16; i++)
            {
                if (i < 4) spriteLib.AddCategoryLabel(sprites[i], "Walk_Down", i.ToString());
                else if (i < 8) spriteLib.AddCategoryLabel(sprites[i], "Walk_Up", i.ToString());
                else if (i < 12) spriteLib.AddCategoryLabel(sprites[i], "Walk_Right", i.ToString());
                else spriteLib.AddCategoryLabel(sprites[i], "Walk_Left", i.ToString());
            }

            AssetDatabase.CreateAsset(spriteLib, "Assets/Artwork/Character/Resources/Sprite_Libraries/" + name + ".asset");
            AssetDatabase.SaveAssets();
        
            characterSkinManager.RefreshSpriteLibraryAssets();
        }
    }
}