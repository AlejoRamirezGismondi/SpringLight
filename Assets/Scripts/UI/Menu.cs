using UnityEngine;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void Start()
        {
            Close();
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
