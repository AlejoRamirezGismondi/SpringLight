using System.Collections.Generic;
using System.Linq;
using Interact;
using Inventory.Scripts;
using UnityEngine;

namespace Widgets
{
    public class Bed : Interactable
    {
        private List<IDayChangeObserver> _dayChangeObservers;
        private SleepTransition _sleepTransition;
        
        private void Awake()
        {
            _sleepTransition = FindObjectOfType<SleepTransition>();
        }
    
        // Start is called before the first frame update
        void Start()
        {
            _dayChangeObservers = new List<IDayChangeObserver>(FindObjectsOfType<MonoBehaviour>().OfType<IDayChangeObserver>());
        }
    
        public override void Interact(InventoryComponent inventoryComponent)
        {
            Sleep();
        }
    
        private void Sleep()
        {
            _sleepTransition.StartSleepTransition();
            foreach (var dayChangeObserver in _dayChangeObservers) dayChangeObserver.NextDay();
        }
    }
}
