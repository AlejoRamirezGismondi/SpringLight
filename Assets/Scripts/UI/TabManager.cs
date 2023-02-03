using UnityEngine;

namespace UI
{
    public class TabManager : MonoBehaviour
    {
        private Tab[] _tabs;
        
        private void Awake()
        {
            _tabs = GetComponentsInChildren<Tab>();
        }

        private void Start()
        {
            foreach (var tab in _tabs)
                tab.GrayOut();
            _tabs[0].Activate();
        }
        
        public void ActivateTab(int index)
        {
            foreach (var tab in _tabs)
                tab.GrayOut();
            _tabs[index].Activate();
        }
    }
}
