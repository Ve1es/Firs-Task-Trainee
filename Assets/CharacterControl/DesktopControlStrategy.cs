using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControlStrategy : IControlStrategy
{
    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //вверх
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //вниз
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           //вправо
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //влево
        }
    }
}
