using System;
using System.Collections.Generic;
using Crops;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public float[] playerPosition;
        public int coins;
        public List<CropTileData> CropTileDataList;

        public GameData()
        {
            playerPosition = new float[3];
            coins = 0;
            CropTileDataList = new List<CropTileData>();
        }
    }
}
