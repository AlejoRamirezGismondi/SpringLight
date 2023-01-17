using System;
using System.IO;
using DataPersistence.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace DataPersistence
{
    public class FileDataHandler
    {
        private readonly string _dataDirPath;
        private readonly string _dataFileName;
        private readonly JsonSerializerSettings _settings;
        
        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            _dataDirPath = dataDirPath;
            _dataFileName = dataFileName;
            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
        }
        
        public void Save(GameData data)
        {
            string fullpath = Path.Combine(_dataDirPath, _dataFileName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
                string json = JsonConvert.SerializeObject(data, Formatting.Indented, _settings);
                
                // TODO DELETE LATER
                Debug.Log(json);
                
                using FileStream stream = new FileStream(fullpath, FileMode.Create);
                using StreamWriter writer = new StreamWriter(stream);
                writer.Write(json);
            }
            catch (Exception e)
            {
                Debug.LogError("An error has ocurred when saving the data" + e);
            }
        }
        
        public GameData Load()
        {
            string fullpath = Path.Combine(_dataDirPath, _dataFileName);
            GameData loadedData = null;
            if (File.Exists(fullpath))
            {
                try
                {
                    string dataToLoad;
                    using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    
                    // TODO DELETE LATER
                    Debug.Log("Loading Data");
                    // Debug.Log(dataToLoad);
                    
                    loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad, _settings);
                }
                catch (Exception e)
                {
                    Debug.LogError("There was an error when loading the data: " + e);
                }
            }
            return loadedData;
        }
    }
}