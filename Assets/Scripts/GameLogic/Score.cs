using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public int scoreIncrement = 10;
    private float _previousZ;
    private void Start()
    {
        _previousZ = transform.position.z;
    }
    public int GetScore()
    {
        return score;
    }
    private void Update()
    {
        if (transform.position.z != _previousZ)
        {
            float deltaZ = transform.position.z - _previousZ;

            if (deltaZ > 0)
            {
                score += Mathf.RoundToInt(deltaZ * scoreIncrement);
            }
            _previousZ = transform.position.z;
        }
    }
}
