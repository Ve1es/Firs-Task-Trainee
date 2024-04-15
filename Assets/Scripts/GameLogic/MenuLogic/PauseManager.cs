using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public UnityEvent pauseGameEvent;

    public void PauseOnOf()
    {
        if (GameIsPaused)
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
        pauseGameEvent?.Invoke();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseGameEvent?.Invoke();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
