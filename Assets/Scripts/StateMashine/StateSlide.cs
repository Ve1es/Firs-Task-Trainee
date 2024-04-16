using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSlide : State
{
    private Player _player;
    private bool isSliding = false;
    public StateSlide(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {   
        if (!isSliding)
        {
            isSliding = true;
            _player.anim.SetBool("isSlide", true);
            _player.colliderSlide.enabled = true;
            _player.colliderRun.enabled = false;
        }
    }
    
    public override void Exit()
    {
        //base.Exit();
        //Debug.LogError("Я вышел из состояния подката");
        _player.anim.SetBool("isSlide", false);
        isSliding = false;
        _player.colliderRun.enabled = true;
        _player.colliderSlide.enabled = false;
    }
}
