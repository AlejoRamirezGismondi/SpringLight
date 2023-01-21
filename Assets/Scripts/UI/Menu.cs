using UnityEngine;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        private void Start()
        {
            Close();
        }

        public void Toggle()
        {
            if (gameObject.activeSelf) Close();else Open();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            PauseManager.Pause();
        }

        public void Close()
        {
            gameObject.SetActive(false);
            PauseManager.Resume();
        }
    }
}
