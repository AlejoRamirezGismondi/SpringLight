using DataPersistence;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private Button[] _buttons;

        private void Awake()
        {
            _buttons = FindObjectsOfType<Button>();
        }

        public void OnNewGameClicked()
        {
            DisableAllButtons();
            DataPersistenceManager.Instance.NewGame();
        }

        public void OnLoadGameClicked()
        {
            DisableAllButtons();
            DataPersistenceManager.Instance.LoadGame();
        }

        private void DisableAllButtons()
        {
            foreach (var button in _buttons) button.interactable = false;
        }
    }
}