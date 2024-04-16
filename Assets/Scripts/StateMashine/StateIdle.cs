using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : State
{
    private Player _player;
    
    public StateIdle(Player player)
    {
        _player = player;
    }
    public override void Enter() 
    {
        //base.Enter();
        //Debug.LogError("Я вошел в состояние покоя");
    }
    public override void Exit() 
    {
        base.Exit();
        //Debug.LogError("Я вышел из состояния покоя");
    }
}
