using DataPersistence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class QuitManager : MonoBehaviour
    {
        private DataPersistenceManager _dataPersistenceManager;

        private void Awake()
        {
            _dataPersistenceManager = FindObjectOfType<DataPersistenceManager>();
        }

        public void ReturnToMainMenu()
        {
            _dataPersistenceManager.OnSceneAboutToChange();
            SceneManager.LoadSceneAsync(0); // 0 is the main menu scene
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
