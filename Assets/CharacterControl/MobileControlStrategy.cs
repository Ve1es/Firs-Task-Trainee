using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlStrategy : IControlStrategy
{
    private const float swipeThreshold = 50f;
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
                            // Обработка свайпа вправо
                        }
                        else
                        {
                            // Обработка свайпа влево
                        }
                    }
                    else
                    {
                        if (swipeDelta.y > 0)
                        {
                            // Обработка свайпа вверх
                        }
                        else
                        {
                            // Обработка свайпа вниз
                        }
                    }
                }
            }
        }
    }
}
