using DataPersistence.Data;

namespace DataPersistence
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(GameData data);
    }
}