using System;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Skin
{
    public class SpriteLibraryGenerator : MonoBehaviour
    {
        public SpriteLibraryAsset GenerateSpriteLibrary(SpriteDto dto)
        {
            Sprite[] sprites = LoadSprites(dto);

            var spriteLib = ScriptableObject.CreateInstance<SpriteLibraryAsset>();
            spriteLib.name = dto.name;

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

            return spriteLib;
        }

        private Sprite[] LoadSprites(SpriteDto dto)
        {
            string[] deserializedSprites = new string[16];
            Array.Copy(dto.front, deserializedSprites, 4);
            Array.Copy(dto.back, 0, deserializedSprites, 4, 4);
            Array.Copy(dto.right, 0, deserializedSprites, 8, 4);
            Array.Copy(dto.left, 0, deserializedSprites, 12, 4);

            Sprite[] sprites = new Sprite[16];
            
            for (int i = 0; i < 16; i++)
                sprites[i] = ConvertToSprite(deserializedSprites[i]);

            return sprites;
        }

        private static Sprite ConvertToSprite(string base64)
        {
            byte[] imageBytes = Convert.FromBase64String(base64[22..]);
            Texture2D tex = new Texture2D(16, 32);
            tex.LoadImage(imageBytes);
            tex.filterMode = FilterMode.Point;
            Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f),
                16.0f);
            return sprite;
        }
    }
}