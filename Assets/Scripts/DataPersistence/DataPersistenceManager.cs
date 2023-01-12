using System;
using DataPersistence.Data;
using UnityEngine;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        public GameData gameData;
        public static DataPersistenceManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            LoadGame();
        }

        public void NewGame()
        {
            gameData = new GameData();
        }

        public void LoadGame()
        {
            // Load any saved data from a file using the data handler
            // if no data can be loaded, initialize a new game
            if (gameData == null)
            {
                Debug.Log("No save data found, starting a new game");
                NewGame();
            }
            // Push the loaded data to all other scripts that need it
        }
        
        public void SaveGame()
        {
            
        }

        public void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}