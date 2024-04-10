using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEventSystem : MonoBehaviour
{
    public static event Action UpSignal;
    public static event Action DownSignal;
    public static event Action RightSignal;
    public static event Action LeftSignal;

    public void UpEvent()
    {
        UpSignal?.Invoke();
    }
    public void DownEvent()
    {
        DownSignal?.Invoke();
    }
    public void RightEvent()
    {
        RightSignal?.Invoke();
    }
    public void LeftEvent()
    {
        LeftSignal?.Invoke();
    }

}
