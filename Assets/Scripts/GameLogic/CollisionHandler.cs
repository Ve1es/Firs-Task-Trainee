using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Вызывается, когда происходит столкновение
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулся ли этот объект с препятствием
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Обработка столкновения с препятствием
            Debug.Log("Player collided with an obstacle!");

            // Здесь можно добавить любую другую логику, связанную с обработкой столкновения
        }
    }
}
