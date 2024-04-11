using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;
    public float moveDistance = 2f;
    public float moveSpeed = 10f;
    public float maxX = 2;
    private int moveRigt = 1;
    private int moveLeft = -1;

    void Update()
    {
        Vector3 currentPosition = transform.position;

        float zMovement = speed * Time.deltaTime;
        Vector3 newPosition = currentPosition + Vector3.forward * zMovement;

        transform.position = newPosition;
    }
    
    public void MoveRight()
    {    
        if (Math.Abs((transform.position.x + moveDistance* moveRigt)) <= maxX)
        {
            StartCoroutine(MoveCharacter(moveRigt));
        }
    }
    public void MoveLeft()
    {
        Debug.Log(transform.position.x + moveDistance * moveLeft);
        if (Math.Abs((transform.position.x + moveDistance*moveLeft)) <= maxX)
        {
            StartCoroutine(MoveCharacter(moveLeft));
        }
    }
    IEnumerator MoveCharacter(float movementDirection)
    {
        //isMoving = true;
        
            float startX = transform.position.x;
            float targetX = startX + moveDistance * movementDirection;

            float distanceToCover = Mathf.Abs(targetX - startX);
            float moveTime = distanceToCover / moveSpeed;

            float elapsedTime = 0f;

            while (elapsedTime < moveTime)
            {
                float t = elapsedTime / moveTime;
                transform.position = new Vector3(Mathf.Lerp(startX, targetX, t), transform.position.y, transform.position.z);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        //isMoving = false;
    }
}
