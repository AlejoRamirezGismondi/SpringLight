using System.Collections.Generic;
using System.Linq;
using Inventory.Scripts;
using UnityEngine;

namespace Widgets
{
    public class Bed : Interactable
    {
        private List<IDayChangeObserver> _dayChangeObservers;
    
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
            // TODO Play animation of fade out
            foreach (var dayChangeObserver in _dayChangeObservers) dayChangeObserver.NextDay();
        }
    }
}
