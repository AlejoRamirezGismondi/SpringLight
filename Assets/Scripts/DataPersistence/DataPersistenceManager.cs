using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataPersistence.Data;
using UnityEngine;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour, SceneTransition.ISceneObserver
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        
        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _fileDataHandler;

        private static DataPersistenceManager Instance { get; set; }

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
            
            SceneTransition[] sceneTransitions = FindObjectsOfType<SceneTransition>();
            if (sceneTransitions.Length > 0)
                foreach (var sceneTransition in sceneTransitions) sceneTransition.AddObserver(this);
            
            // DeleteAllSaveData();
            LoadGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceObjects);
        }

        private void NewGame()
        {
            _gameData = new GameData();
        }

        private void LoadGame()
        {
            _gameData = _fileDataHandler.Load();
            
            // Load any saved data from a file using the data handler
            // if no data can be loaded, initialize a new game
            if (_gameData == null)
            {
                Debug.Log("No save data found, starting a new game");
                NewGame();
            }
            // Push the loaded data to all other scripts that need it
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.LoadData(_gameData);
        }

        private void SaveGame()
        {
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.SaveData(_gameData);
            _fileDataHandler.Save(_gameData);
        }

        public void OnApplicationQuit()
        {
            SaveGame();
        }

        public void OnSceneAboutToChange()
        {
            SaveGame();
        }

        private void DeleteAllSaveData()
        {
            foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
            {
                DirectoryInfo dataDir = new DirectoryInfo(directory);
                dataDir.Delete(true);
            }
     
            foreach (var file in Directory.GetFiles(Application.persistentDataPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                fileInfo.Delete();
            }
        }
    }
}