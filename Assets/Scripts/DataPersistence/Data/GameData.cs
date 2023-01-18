using System;
using System.Collections.Generic;
using Crops;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public int sceneBuildIndex;
        public float[] playerPosition;
        public int coins;
        public List<CropTileData> CropTileDataList;

        public GameData()
        {
            sceneBuildIndex = 1; // 1 is the build index for the Lobby Scene, which serves as the start of the game
            playerPosition = new float[3];
            coins = 0;
            CropTileDataList = new List<CropTileData>();
        }
    }
}
