using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "CropState", menuName = "ScriptableObjects/CropState")]
    public class CropTileObject : ScriptableObject
    {
        public CropState initialState;
        public bool watered;
        public CropState state;
        public Sprite cropSprite;
        public Sprite sprite;
    }
}