using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
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
