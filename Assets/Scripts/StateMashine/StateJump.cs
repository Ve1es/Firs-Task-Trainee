using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    private Player _player;
    private bool isJumping = false;
    public StateJump(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        //base.Enter();
        //Debug.LogError("Я вошел в состояние прыжка");
        if (!isJumping)
        {
            isJumping = true;
            _player.anim.SetBool("isJumping", true);
            _player.rb.AddForce(Vector3.up * _player.jumpForce, ForceMode.Impulse);
        }
    }
    public override void Exit()
    {
        //base.Exit();
        //Debug.LogError("Я вышел из состояния прыжка");
        _player.anim.SetBool("isJumping", false);
        isJumping = false;
    }
}
