using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IControlStrategy _controlStrategy;
    private CharacterMove _characterMove;
    //public event Action UpSignal;
    //public event Action DownSignal;
    //public event Action RightSignal;
    //public event Action LeftSignal;
    public void SetControlStrategy(IControlStrategy strategy)
    {
        _controlStrategy = strategy;
        _controlStrategy.UpSignal += _characterMove.Jump;
        _controlStrategy.DownSignal += _characterMove.RollUp;
        _controlStrategy.RightSignal += _characterMove.MoveRight;
        _controlStrategy.LeftSignal += _characterMove.MoveLeft;
    }
    void Start()
    {
        _characterMove = GetComponent<CharacterMove>();
    }
    public void Update()
    {
        if (_controlStrategy != null)
        {
            _controlStrategy.HandleInput();
        }
    }
}
