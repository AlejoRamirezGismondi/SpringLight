using System;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public int coins;

        public GameData()
        {
            coins = 0;
        }
    }
}
