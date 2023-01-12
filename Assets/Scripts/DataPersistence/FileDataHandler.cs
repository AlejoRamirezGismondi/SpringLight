using System;
using System.IO;
using DataPersistence.Data;
using UnityEngine;

namespace DataPersistence
{
    public class FileDataHandler
    {
        private string dataDirPath = "";
        private string dataFileName = "";
        
        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }
        
        public void Save(GameData data)
        {
            string fullpath = Path.Combine(dataDirPath, dataFileName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
                string json = JsonUtility.ToJson(data, true);
                using (FileStream stream = new FileStream(fullpath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(json);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("An error has ocurred when saving the data" + e);
            }
        }
        
        public GameData Load()
        {
            string fullpath = Path.Combine(dataDirPath, dataFileName);
            GameData loadedData = null;
            if (File.Exists(fullpath))
            {
                try
                {
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    
                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
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