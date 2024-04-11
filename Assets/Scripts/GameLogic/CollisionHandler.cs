using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // ����������, ����� ���������� ������������
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ���������� �� ���� ������ � ������������
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ��������� ������������ � ������������
            Debug.Log("Player collided with an obstacle!");

            // ����� ����� �������� ����� ������ ������, ��������� � ���������� ������������
        }
    }
}
