using System;
using System.IO;
using UnityEngine;

namespace Skin.Savers
{
    /**
     * DEPRECATED *
 * This class gets a deserialized data from the Network Manager and saves the individual images of the sprite to the Resources folder
 * Images are saved under /Character/Resources/name of the sprite
 */
    public static class SpriteSaver
    {
        public static void SaveSprite(SpriteDto deserializedGetData)
        {
            Directory.CreateDirectory($"Assets/Artwork/Character/Resources/{deserializedGetData.name}");

            var n = 0;
            foreach (var t in deserializedGetData.front)
            {
                SaveImage(t, deserializedGetData.name, n);
                n++;
            }

            foreach (var t in deserializedGetData.back)
            {
                SaveImage(t, deserializedGetData.name, n);
                n++;
            }

            foreach (var t in deserializedGetData.right)
            {
                SaveImage(t, deserializedGetData.name, n);
                n++;
            }

            foreach (var t in deserializedGetData.left)
            {
                SaveImage(t, deserializedGetData.name, n);
                n++;
            }
        }

        private static void SaveImage(string base64, string name, int n)
        {
            byte[] imageBytes = Convert.FromBase64String(base64[22..]);
            Texture2D tex = new Texture2D(16, 32);
            tex.LoadImage(imageBytes);
            tex.filterMode = FilterMode.Point;
            Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f),
                16.0f);

            var path = $"Assets/Artwork/Character/Resources/{name}/{name}_{n}.asset";
        }
    }
}