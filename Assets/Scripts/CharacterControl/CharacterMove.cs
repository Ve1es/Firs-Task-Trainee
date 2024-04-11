using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterMove : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 10f;

    private bool isMoving = false;

    public float jumpHeight = 2f;
    public float jumpDuration = 0.5f;

    IEnumerator MoveCharacter(float movementDirection)
    {
        isMoving = true;

        float startX = transform.position.x;
        float targetX = startX + moveDistance* movementDirection;

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

        isMoving = false;
    }
    IEnumerator PerformJump()
    {
        float startY = transform.position.y;
        float targetY = startY + jumpHeight;

        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, targetY, t), transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

        yield return new WaitForSeconds(0.1f);
    }
    public void MoveRight()
    {
        StartCoroutine(MoveCharacter(1));
    }
    public void MoveLeft()
    {
        StartCoroutine(MoveCharacter(-1));
    }
    public void Jump()
    {
        StartCoroutine(PerformJump());
    }
    public void RollUp()
    {

    }
   
}
