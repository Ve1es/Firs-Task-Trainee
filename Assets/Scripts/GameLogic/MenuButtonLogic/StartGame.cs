using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Video.VideoPlayer;

public class StartGame : MonoBehaviour
{
    public Player _player;
    public GameObject mainMenuUI;
    public GameObject gameMenuUI;
    public event Action startGameEvent;

    public void StartGameplay()
    {
        Time.timeScale = 1f;
        StartRun();
        ChangeUI();
        startGameEvent?.Invoke();
    }
    private void StartRun()
    {
        _player.Run();
    }
    private void ChangeUI()
    {
        mainMenuUI.SetActive(false);
        gameMenuUI.SetActive(true);
    }
    
}
