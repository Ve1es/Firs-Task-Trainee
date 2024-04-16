using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public StartGame startGame;
    public Player player;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float moveDistance = 2f;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float maxX = 2;
    private int _moveRigt = 1;
    private int _moveLeft = -1;
    private bool _isRun = false;
    private bool _canMove = true;


    private void Start()
    {
        startGame.startGameEvent += Run;
        player._stateDeath.stopMove += Stop;
        player._stateDeath.keepMove += Run;
    }

    void Update()
    {
        if (_isRun)
        {
            Vector3 currentPosition = transform.position;

            float zMovement = speed * Time.deltaTime;
            Vector3 newPosition = currentPosition + Vector3.forward * zMovement;

            transform.position = newPosition;
            speed += 0.001f;
        }
    }
    /*public void RunStop()
    {
        if (_isRun)
        {
            _isRun = false;
        }
        else
        {
            _isRun = true;
        }
    }*/
    public void Stop()
    {
        _isRun = false;
    }
    public void Run()
    {
        _isRun = true;
    }
    public void MoveRight()
    {
        if (Math.Abs((transform.position.x + moveDistance * _moveRigt)) <= maxX && _canMove)
        {
            StartCoroutine(MoveCharacter(_moveRigt));
        }
    }
    public void MoveLeft()
    {
        if (Math.Abs((transform.position.x + moveDistance * _moveLeft)) <= maxX && _canMove)
        {
            StartCoroutine(MoveCharacter(_moveLeft));
        }
    }
    IEnumerator MoveCharacter(float movementDirection)
    {
        _canMove = false;
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
        _canMove = true;
    }
}
