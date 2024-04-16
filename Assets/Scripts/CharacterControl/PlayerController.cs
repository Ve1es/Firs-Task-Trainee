using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IControlStrategy _controlStrategy;
    private Player _characterMove;
    public void SetControlStrategy(IControlStrategy strategy)
    {
        _controlStrategy = strategy;
        _controlStrategy.UpSignal += _characterMove.Jump;
        _controlStrategy.DownSignal += _characterMove.Slide;
        _controlStrategy.RightSignal += _characterMove.MoveRight;
        _controlStrategy.LeftSignal += _characterMove.MoveLeft;
    }
    void Awake()
    {
        _characterMove = GetComponent<Player>();
    }
    public void Update()
    {
        if (_controlStrategy != null)
        {
            _controlStrategy.HandleInput();
        }
    }
}
