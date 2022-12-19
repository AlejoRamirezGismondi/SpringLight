using UnityEngine;

namespace Crops
{
    public class Crop : ScriptableObject
    {
        public Sprite SeedSprite;
        public Sprite GrowingSprite;
        public Sprite GrownSprite;
        public int DaysToGrow;
        public string Name;
    }
}