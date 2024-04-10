using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControlStrategy : IControlStrategy
{
    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Обработка нажатия стрелки вверх
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Обработка нажатия стрелки вниз
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Обработка нажатия стрелки вправо
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Обработка нажатия стрелки влево
        }
    }
}
