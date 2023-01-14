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
        foreach (var cropTile in _cropTiles)
            cropTile.Initialize();
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
        for (var i = 0; i < data.CropTileDataList.Count; i++)
        {
            var cropTile = _cropTiles[i];
            cropTile.LoadFromCropTileData(data.CropTileDataList[i]);
        }
    }

    // This method assumes that the FindObjectsOfType will always get the CropTiles in the same order and that the Load will do as well
    public void SaveData(GameData data)
    {
        data.CropTileDataList = new List<CropTileData>();
        foreach (var cropTile in _cropTiles) 
            data.CropTileDataList.Add(cropTile.GetCropTileData());
    }
}