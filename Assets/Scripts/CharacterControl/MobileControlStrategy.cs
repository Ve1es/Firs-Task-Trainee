using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlStrategy : IControlStrategy
{
    private const float swipeThreshold = 0.5f;

    public event Action UpSignal;
    public event Action DownSignal;
    public event Action RightSignal;
    public event Action LeftSignal;
    public void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                
                Vector2 swipeDelta = touch.deltaPosition;
                if (swipeDelta.magnitude > swipeThreshold)
                {
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if (swipeDelta.x > 0)
                        {
                            RightSignal?.Invoke();
                        }
                        else
                        {
                            LeftSignal?.Invoke();
                        }
                    }
                    else
                    {
                        if (swipeDelta.y > 0)
                        {
                            UpSignal?.Invoke();
                        }
                        else
                        {
                            DownSignal?.Invoke();
                        }
                    }
                }
            }
        }
    }
}
