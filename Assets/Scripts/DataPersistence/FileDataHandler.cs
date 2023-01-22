using System;
using System.IO;
using Crops.Scripts;
using DataPersistence.Data;
using Inventory.Scripts;
using Items.Scripts;
using Newtonsoft.Json;
using UnityEngine;

namespace DataPersistence
{
    public class FileDataHandler
    {
        private readonly JsonSerializerSettings _settings;
        private readonly string _fullpath;
        
        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            _fullpath = Path.Combine(dataDirPath, dataFileName);
            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            foreach (var gameJsonConverter in CustomConverters.GetGameJsonConverters()) _settings.Converters.Add(gameJsonConverter);
        }
        
        public void Save(GameData data)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_fullpath));
                string json = JsonConvert.SerializeObject(data, Formatting.Indented, _settings);
                
                Debug.Log(json);

                using FileStream stream = new FileStream(_fullpath, FileMode.Create);
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
            GameData loadedData = null;
            if (File.Exists(_fullpath))
            {
                try
                {
                    string dataToLoad;
                    using (FileStream stream = new FileStream(_fullpath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

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