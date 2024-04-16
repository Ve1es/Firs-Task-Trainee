using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControlStrategy : IControlStrategy
{
    public event Action UpSignal;
    public event Action DownSignal;
    public event Action RightSignal;
    public event Action LeftSignal;
    public void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            UpSignal?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            DownSignal?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightSignal?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftSignal?.Invoke();
        }
    }
}
