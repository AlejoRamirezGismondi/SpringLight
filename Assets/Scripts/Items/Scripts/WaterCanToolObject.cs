using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Water Can Tool", menuName = "Inventory/Water Can Tool")]
    public class WaterCanToolObject : ToolObject
    {
        public int waterAmount;
        public int waterCapacity;
        private WaterMeter _waterMeter;
        
        public new void Awake()
        {
            toolType = ToolType.WaterCan;
        }

        public void AddWater(int amount)
        {
            waterAmount += amount;
            if (waterAmount >= waterCapacity) waterAmount = waterCapacity;
            UpdateWaterMeter();
        }
        
        public void UseWater()
        {
            if (waterAmount > 0) waterAmount -= 1;
            if (waterAmount < 0) waterAmount = 0;
            UpdateWaterMeter();
        }
        
        public bool HasWater()
        {
            return waterAmount > 0;
        }

        private void UpdateWaterMeter()
        {
            if (_waterMeter != null)
                _waterMeter.UpdateWater(waterAmount, waterCapacity);
        }
        
        public void AddWaterMeter(WaterMeter waterMeter)
        {
            _waterMeter = waterMeter;
            UpdateWaterMeter();
        }
    }
}