using System;
using System.IO;
using Crops;
using Crops.Scripts;
using UnityEngine;

public class CropManager : MonoBehaviour, SceneTransition.ISceneObserver
{
    private CropTile[] _cropTiles;

    // Start is called before the first frame update
    void Start()
    {
        SceneTransition[] sceneTransitions = FindObjectsOfType<SceneTransition>();
        if (sceneTransitions.Length > 0)
        {
            foreach (var sceneTransition in sceneTransitions) sceneTransition.AddObserver(this);
        }

        _cropTiles = FindObjectsOfType<CropTile>();
        Array.Sort(_cropTiles, (a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
        LoadCropTilesFromAssets();
    }

    public void NextDay()
    {
        foreach (var cropTile in _cropTiles)
        {
            cropTile.NextDay();
        }
    }

    // This method assumes that the FindObjectsOfType will always get the CropTiles in the same order and that the Load will do as well
    private void SaveCropTilesToAssets()
    {
        for (var i = 0; i < _cropTiles.Length; i++)
        {
            
        }
    }

    private void LoadCropTilesFromAssets()
    {
        for (var i = 0; i < _cropTiles.Length; i++)
        {
            
        }
    }

    public void OnSceneAboutToChange()
    {
        SaveCropTilesToAssets();
    }
}