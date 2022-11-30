using System.Collections.Generic;

namespace Skin
{
    public class SkinRegister
    {
        public string Name;
        public string Code;

        public SkinRegister(string name, string code)
        {
            this.Code = code;
            this.Name = name;
        }
    }

    public static class SkinRegistry
    {
        private static readonly List<SkinRegister> SkinRegisters = new();

        public static void AddSkin(string name, string code)
        {
            if (Contains(code)) SkinRegisters.RemoveAll(rs => rs.Code.Equals(code));
            SkinRegisters.Add(new SkinRegister(name, code));
        }

        public static bool Contains(string code)
        {
            return SkinRegisters.Exists(sr => sr.Code.Equals(code));
        }

        public static string GetSkinName(string code)
        {
            if (Contains(code)) return SkinRegisters.Find(sr => sr.Code.Equals(code)).Name;
            return "";
        }
    }
}