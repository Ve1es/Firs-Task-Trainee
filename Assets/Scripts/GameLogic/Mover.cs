using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 currentPosition = transform.position;

        float zMovement = speed * Time.deltaTime;
        Vector3 newPosition = currentPosition + Vector3.forward * zMovement;

        transform.position = newPosition;
    }
}
