using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControlStrategy : IControlStrategy
{
    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // ��������� ������� ������� �����
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // ��������� ������� ������� ����
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ��������� ������� ������� ������
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ��������� ������� ������� �����
        }
    }
}
