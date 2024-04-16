using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public Transform TileObj;
    private Vector3 _nextTileSpawn;
    private const int _distanceBetween2Tiles = 116;

    private void Start()
    {
        _nextTileSpawn.z = TileObj.position.z+_distanceBetween2Tiles;
    }
    public void CreateTile()
    {
        Instantiate(TileObj, _nextTileSpawn, TileObj.rotation);
    }
}
