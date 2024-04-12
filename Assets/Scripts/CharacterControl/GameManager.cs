using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public StartGame startGame;

    private void Start()
    {
        startGame.startGameEvent += GetControl;
    }
    void GetControl()
    {
        if (Application.isMobilePlatform)
        {
            playerController.SetControlStrategy(new MobileControlStrategy());
        }
        else
        {
            playerController.SetControlStrategy(new DesktopControlStrategy());
        }
    }
}
