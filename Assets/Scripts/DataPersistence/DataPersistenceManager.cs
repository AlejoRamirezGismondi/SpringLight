using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataPersistence.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour, SceneTransition.ISceneObserver
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        
        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _fileDataHandler;

        public static DataPersistenceManager Instance { get; private set; }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);

            _fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            AttachToSceneObjects();
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            AttachToSceneObjects();
            LoadSceneProgress();
        }

        public void NewGame()
        {
            Instance._gameData = new GameData();
            SceneManager.LoadSceneAsync(_gameData.sceneBuildIndex);
        }

        public void LoadGame()
        {
            GameData gameData = _fileDataHandler.Load();
            
            // Load any saved data from a file using the data handler
            // if no data can be loaded, initialize a new game
            if (gameData == null) return;

            _gameData = gameData;
            SceneManager.LoadSceneAsync(_gameData.sceneBuildIndex);
        }

        private void LoadSceneProgress()
        {
            // Push the loaded data to all other scripts that need it
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.LoadData(_gameData);
        }

        private void SaveGame()
        {
            // _gameData ??= new GameData();
            if (_gameData == null) return;
            foreach (var dataPersistenceObject in _dataPersistenceObjects) dataPersistenceObject.SaveData(_gameData);
            _gameData.sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
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

        private void AttachToSceneObjects()
        {
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            
            SceneTransition[] sceneTransitions = FindObjectsOfType<SceneTransition>();
            if (sceneTransitions.Length <= 0) return;
            foreach (var sceneTransition in sceneTransitions) sceneTransition.AddObserver(this);
        }
        
        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceObjects);
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