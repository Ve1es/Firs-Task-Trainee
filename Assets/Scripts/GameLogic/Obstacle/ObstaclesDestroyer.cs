using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Проверяем, соприкосается ли объект с нужным тегом
        if (other.CompareTag("Obstacle"))
        {
            // Получаем компонент Obstacle объекта и вызываем его метод Destroy
            Obstacle obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.Destroy();
            }
        }
    }
}
