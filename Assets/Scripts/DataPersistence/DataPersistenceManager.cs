using System.Collections.Generic;
using System.Linq;
using DataPersistence.Data;
using UnityEngine;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        
        private GameData gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _fileDataHandler;

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
            _fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceObjects);
        }

        public void NewGame()
        {
            gameData = new GameData();
        }

        public void LoadGame()
        {
            gameData = _fileDataHandler.Load();
            
            // Load any saved data from a file using the data handler
            // if no data can be loaded, initialize a new game
            if (gameData == null)
            {
                Debug.Log("No save data found, starting a new game");
                NewGame();
            }
            // Push the loaded data to all other scripts that need it
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.LoadData(gameData);
        }
        
        public void SaveGame()
        {
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.SaveData(gameData);
            _fileDataHandler.Save(gameData);
        }

        public void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}