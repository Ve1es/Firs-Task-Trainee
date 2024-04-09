using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    public Obstacle CreateObstacle(string obstacleType)
    {
        switch (obstacleType)
        {
            case "Type1":
                return new ObstacleType1();
            case "Type2":
                return new ObstacleType2();
            case "Type3":
                return new ObstacleType3();
            case "Type4":
                return new ObstacleType4();
            default:
                Debug.LogError("Unsupported obstacle type: " + obstacleType);
                return null;
        }
    }
}
