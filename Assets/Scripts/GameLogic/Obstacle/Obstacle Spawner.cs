using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    [SerializeField]
    private int _lineStep = 2;
    [SerializeField]
    private int _obstacleStep = 6;
    [SerializeField]
    private int _tileSize = 30;
    [SerializeField]
    private float spawnProbability = 0.5f;
    private int[] _lineXs = new int[3];
    private const int _lineNumber = 3;
    private int _obstacleQuantity;
    

    private void Start()
    {
        int position = -_lineStep;
        for(int i=0; i< _lineNumber; i++)
        {
            _lineXs[i] = position;
            position += _lineStep;
        }
        _obstacleQuantity = _tileSize / _obstacleStep;
        SpawnObstacles();
    }
    public void SpawnObstacles()
    {
       
        for (int line = 0; line < _lineNumber; line++)
        {
            int currentPosition = FindStartPosition();
            spawnPoint.position = new Vector3(_lineXs[line], spawnPoint.position.y, spawnPoint.position.z);
            for (int i = 0; i < _obstacleQuantity; i++)
            {
                float randomValue = Random.value;
                spawnPoint.position = new Vector3(spawnPoint.position.x, currentPosition, spawnPoint.position.z);
                if (randomValue < spawnProbability)
                    Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                currentPosition += _obstacleStep;
            }
        }
    }

    int FindStartPosition()
    {
        int maxPosition = -_tileSize / 2;
        int startPosition=0;
        while ((startPosition- _obstacleStep)> maxPosition)
        {
            startPosition = startPosition - _obstacleStep;
        }

        return startPosition;
    }
}
