﻿using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New Crop", menuName = "Crops/Crop")]
    public class CropObject : ScriptableObject
    {
        public Sprite seedSprite;
        public Sprite growingSprite;
        public Sprite grownSprite;
        public int daysToGrow;
    }
}