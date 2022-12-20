using Inventory.Scripts;
using UnityEngine;

public class Bed : Interactable
{
    private CropManager _cropManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _cropManager = FindObjectOfType<CropManager>();
    }
    
    public override void Interact(InventoryComponent inventoryComponent)
    {
        Sleep();
    }
    
    private void Sleep()
    { 
        // TODO Play animation of fade out
        _cropManager.NextDay();
    }
}
