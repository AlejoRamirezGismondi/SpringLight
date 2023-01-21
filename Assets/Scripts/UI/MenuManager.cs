using UnityEngine;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        private Menu _menu;

        private void Awake()
        {
            _menu = GetComponentInChildren<Menu>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) _menu.Toggle();
        }
    }
}