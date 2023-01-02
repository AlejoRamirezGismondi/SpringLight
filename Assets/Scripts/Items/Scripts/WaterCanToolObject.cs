using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Water Can Tool", menuName = "Inventory/Water Can Tool")]
    public class WaterCanToolObject : ToolObject
    {
        public int waterAmount;
        
        public new void Awake()
        {
            toolType = ToolType.WaterCan;
        }

        public void AddWater()
        {
            waterAmount += 1;
        }
        
        public void UseWater()
        {
            if (waterAmount > 0) waterAmount -= 1;
        }
        
        public bool HasWater()
        {
            return waterAmount > 0;
        }
    }
}