using System.Collections.Generic;
using UnityEngine.U2D.Animation;

namespace Skin
{
    public class SkinRegister
    {
        public readonly SpriteLibraryAsset SpriteLibraryAsset;
        public readonly string Name;
        public readonly string Code;

        public SkinRegister(SpriteLibraryAsset spriteLibraryAsset, string name, string code)
        {
            SpriteLibraryAsset = spriteLibraryAsset;
            Code = code;
            Name = name;
        }
    }

    public static class SkinRegistry
    {
        private static readonly List<SkinRegister> SkinRegisters = new();

        public static void AddSkin(SpriteLibraryAsset spriteLibraryAsset, string name, string code)
        {
            if (Contains(code)) SkinRegisters.RemoveAll(rs => rs.Code.Equals(code));
            SkinRegisters.Add(new SkinRegister(spriteLibraryAsset, name, code));
        }

        public static bool Contains(string code)
        {
            return SkinRegisters.Exists(sr => sr.Code.Equals(code));
        }

        public static bool ContainsName(string name)
        {
            return SkinRegisters.Exists(sr => sr.Name.Equals(name));
        }

        public static string GetCodeForName(string name)
        {
            return ContainsName(name) ? SkinRegisters.Find(sr => sr.Name.Equals(name)).Code : "";
        }

        public static void DeleteSkin(string code)
        {
            if (Contains(code)) SkinRegisters.RemoveAll(sr => sr.Code.Equals(code));
        }
        
        public static SpriteLibraryAsset[] GetSpriteLibraryAssets()
        {
            return SkinRegisters.ConvertAll(sr => sr.SpriteLibraryAsset).ToArray();
        }
    }
}