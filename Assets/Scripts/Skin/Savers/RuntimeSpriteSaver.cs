using System;
using System.IO;
using UnityEngine;

namespace Skin.Savers
{
    /*
     * DEPRECATED *
     */
    public static class RuntimeSpriteSaver
    {
        public static void SaveSprite(SpriteDto deserializedGetData)
        {
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

            File.WriteAllBytes(Application.persistentDataPath + $"/SkinSources/{name}/{name}_{n}.png", imageBytes);
        }
    }
}