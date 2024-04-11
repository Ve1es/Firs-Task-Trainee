using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolObstacles : MonoBehaviour
{
    public static ObjectPoolObstacles instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private List<GameObject> obstacls;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i = 0; i< obstacls.Count; i++)
        {
            // GameObject obj = Instantiate(obstacle);
            for (int j = 0; j < amountToPool / obstacls.Count; j++)
            {
                GameObject obj = Instantiate(obstacls[i]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        List<GameObject> availableObjects = new List<GameObject>();
        // Собираем все неактивные объекты из пула
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                availableObjects.Add(pooledObjects[i]);
            }
        }
        if (availableObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, availableObjects.Count);
            return availableObjects[randomIndex];
        }
        /*for (int i=0; i<pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }*/
        return null;
    }
    
    void Update()
    {
        
    }
}
