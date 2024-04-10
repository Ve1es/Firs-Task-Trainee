using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolObstacle : MonoBehaviour
{
    public static ObjectPoolObstacle Instance;

    [SerializeField]
    private List<ObjectInfo> objectsInfo;

    [Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Obstacle_1,
            Obstacle_2,
            Obstacle_3,
            Obstacle_4,
        }

        public ObjectType objectType;
        public GameObject Prefab;
        public int StartCount;
    }

    private Dictionary<ObjectInfo.ObjectType, Pool> pools;
    private void Awake()
    {
        if(Instance == null )
        Instance = this; 

        InitPool();
    }

    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

        var emptyGO = new GameObject();

        foreach(var obj in objectsInfo)
        {
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.ToString();

           // pools[obj.Type] = new Pool(container.transform);

            for(int i = 0; i<obj.StartCount; i++)
            {

            }
        }
    }
}
