using System;
using System.Collections.Generic;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public int coins;
        public List<string> cropTiles;

        public GameData()
        {
            coins = 0;
            cropTiles = new List<string>();
        }
    }
}
