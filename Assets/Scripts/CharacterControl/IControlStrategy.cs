using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlStrategy
{
    event Action UpSignal;
    event Action DownSignal;
    event Action RightSignal;
    event Action LeftSignal;
    void HandleInput();
}
