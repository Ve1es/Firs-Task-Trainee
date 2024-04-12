using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRun : State
{
    private Player _player;
    public StateRun(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        //base.Enter();
        //Debug.LogError("Я вошел в состояние бега");
        _player.anim.SetBool("isRunning", true);
    }
    public override void Exit()
    {
        //base.Exit();
        //Debug.LogError("Я вышел из состояния бега");
        _player.anim.SetBool("isRunning", false);
    }
    
}
