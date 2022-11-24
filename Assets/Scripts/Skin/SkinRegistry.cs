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
        private static List<SkinRegister> _skinRegisters;

        public static void AddSkin(string name, string code)
        {
            if (Contains(code)) _skinRegisters.RemoveAll(rs => rs.Code.Equals(code));
            _skinRegisters.Add(new SkinRegister(name, code));
        }

        public static bool Contains(string code)
        {
            return _skinRegisters.Exists(sr => sr.Code.Equals(code));
        }

        public static string GetSkinName(string code)
        {
            if (Contains(code)) return _skinRegisters.Find(sr => sr.Code.Equals(code)).Name;
            return "";
        }
    }
}