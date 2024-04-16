using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    private bool _gameIsPaused = false;
    public GameObject pauseMenuUI;
    public UnityEvent pauseGameEvent;
    public UnityEvent unpauseGameEvent;

    public void PauseOnOf()
    {
        if (_gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        unpauseGameEvent?.Invoke();
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseGameEvent?.Invoke();
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }
}
