using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // ���������, ������������� �� ������ � ������ �����
        if (other.CompareTag("Obstacle"))
        {
            // �������� ��������� Obstacle ������� � �������� ��� ����� Destroy
            Obstacle obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.Destroy();
            }
        }
    }
}
