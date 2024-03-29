using System;
using System.Collections.Generic;
using Crops;
using Inventory.Scripts;

namespace DataPersistence.Data
{
    [Serializable]
    public class GameData
    {
        public int lastSceneBuildIndex; // Saved in the DataPersistenceManager
        public float[] playerPosition; // Saved in the PlayerPersistence
        public int coins; // Saved in the CoinCounter
        public List<CropTileData> CropTileDataList; // Saved in the CropTileManager
        public List<InventorySlot> inventory; // Saved in the InventoryComponent
        public int waterCanAmount; // Saved in the inventory component
        public bool[] shopItemsBought; // Saved in the ShopPersistence

        public GameData()
        {
            lastSceneBuildIndex = 1; // 1 is the build index for the Lobby Scene, which serves as the start of the game
            playerPosition = new float[3]; // This is the position of the player in the last scene saved
            coins = 0;
            CropTileDataList = new List<CropTileData>();
            inventory = new List<InventorySlot>();
            waterCanAmount = 5; // 5 is the max water when the game begins
            shopItemsBought = Array.Empty<bool>(); // Marks the items that have been bought in the shop
        }
    }
}
