using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDeath : State
{
    private Player _player;
    public StateDeath(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        Debug.LogError("Я вошел в состояние смерти");
        Time.timeScale = 0f;
        _player.endGameCanvas.SetActive(true);
        _player.inGameCanvas.SetActive(false);
    }
    public override void Exit()
    {
        //base.Exit();
        //Debug.LogError("Я вышел из состояния покоя");
    }
}
