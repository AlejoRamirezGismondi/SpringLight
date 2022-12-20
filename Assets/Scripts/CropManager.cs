using Crops;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    private CropTile[] _cropTiles;
    
    // Start is called before the first frame update
    void Start()
    {
        _cropTiles = FindObjectsOfType<CropTile>();
    }

    public void NextDay()
    {
        foreach (var cropTile in _cropTiles)
        {
            cropTile.NextDay();
        }
    }
}
