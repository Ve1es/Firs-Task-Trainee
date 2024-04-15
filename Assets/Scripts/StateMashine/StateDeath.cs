using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDeath : State
{
    private Player _player;
    
    public event Action stopMove;
    public event Action keepMove;
    public StateDeath(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        _player.anim.SetBool("isDeath", true);
        stopMove?.Invoke();
        _player.endGameCanvas.SetActive(true);
        _player.inGameCanvas.SetActive(false);
        _player.addScore.WriteScore();
    }
    public override void Exit()
    {
        _player.anim.SetBool("isDeath", false);
        keepMove?.Invoke();
        _player.endGameCanvas.SetActive(false);
        _player.inGameCanvas.SetActive(true);
    }
}
