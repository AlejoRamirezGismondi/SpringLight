using System;
using System.Collections.Generic;
using Crops;
using DataPersistence;
using DataPersistence.Data;
using UnityEngine;

public class CropManager : MonoBehaviour, IDataPersistence
{
    private CropTile[] _cropTiles;

    // Start is called before the first frame update
    void Awake()
    {
        _cropTiles = FindObjectsOfType<CropTile>();
        Array.Sort(_cropTiles, (a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
    }

    public void NextDay()
    {
        foreach (var cropTile in _cropTiles)
        {
            cropTile.NextDay();
        }
    }

    public void LoadData(GameData data)
    {
        for (var i = 0; i < _cropTiles.Length; i++)
        {
            var cropTile = _cropTiles[i];
            cropTile.Initialize();
            cropTile.LoadFromCropTileData(JsonUtility.FromJson<CropTileData>(data.cropTiles[i]));
        }
    }

    // This method assumes that the FindObjectsOfType will always get the CropTiles in the same order and that the Load will do as well
    public void SaveData(GameData data)
    {
        data.cropTiles = new List<string>();
        foreach (var cropTile in _cropTiles) 
            data.cropTiles.Add(JsonUtility.ToJson(cropTile.GetCropTileData()));
    }
}