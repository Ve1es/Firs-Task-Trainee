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
        //base.Enter();
        Debug.LogError("� ����� � ��������� ������");
    }
    public override void Exit()
    {
        //base.Exit();
        //Debug.LogError("� ����� �� ��������� �����");
    }
}
