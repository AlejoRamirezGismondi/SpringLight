using DataPersistence.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataPersistence
{
    public class PlayerPersistence : MonoBehaviour, IDataPersistence
    {
        public void LoadData(GameData data)
        {
            if (data.lastSceneBuildIndex == SceneManager.GetActiveScene().buildIndex)
                transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        }

        public void SaveData(GameData data)
        {
            var position = transform.position;
            data.playerPosition = new[]
            {
                position.x,
                position.y,
                position.z,
            };
        }
    }
}