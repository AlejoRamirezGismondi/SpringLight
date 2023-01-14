using System;
using System.Collections.Generic;
using Crops;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public int coins;
        public List<CropTileData> CropTileDataList;

        public GameData()
        {
            coins = 0;
            CropTileDataList = new List<CropTileData>();
        }
    }
}
