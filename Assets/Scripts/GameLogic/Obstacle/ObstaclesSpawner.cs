using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public float timeBeforeStart = 4;
    public GameObject objectToSpawn;
    public Transform spawnObjectHelper;
    public StartGame startGame;

    [SerializeField]
    private int _obstacleStep = 6;
    [SerializeField]
    private float spawnProbability = 0.5f;
    [SerializeField]
    private int[] _lineXs = new int[3];
    private Transform _spawnpPoint;
    private Vector3 _lastPosition;
    private bool spawnObject=false;

    public void Start()
    {
        startGame.startGameEvent += StartGame;
    }
    private void StartGame()
    {
        _spawnpPoint = spawnObjectHelper;
        _lastPosition = spawnObjectHelper.position;
        StartSpawn();//!!!!! запуск по нажатию кнопки, это для теста
    }

    public void StartSpawn()
    {
        StartCoroutine(StartScriptAfterDelay(timeBeforeStart));
    }
    IEnumerator StartScriptAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
       // SpawnControll();
        spawnObject = true;
    }

    private void Update()
    {
        if (transform.position.z - _lastPosition.z >= _obstacleStep&&spawnObject)
        {
            SpawnControll();
            _lastPosition = transform.position;
        }
    }
    void SpawnControll()
    {
        for(int i=0; i< _lineXs.Length; i++)
        {
            SpawnObstacle(_lineXs[i]);
        }
    }
    void SpawnObstacle(float x)
    {
        float randomValue = Random.value;
        _spawnpPoint.position = new Vector3(x, objectToSpawn.transform.position.y, spawnObjectHelper.position.z);
        if (randomValue < spawnProbability)
        {
            //Instantiate(objectToSpawn, _spawnpPoint.position, objectToSpawn.transform.rotation);
            GameObject obstacle = ObjectPoolObstacles.instance.GetPooledObject();

            if(obstacle != null)
            {
                obstacle.transform.position = _spawnpPoint.position;
                obstacle.SetActive(true);
            }
        }
    }
}
