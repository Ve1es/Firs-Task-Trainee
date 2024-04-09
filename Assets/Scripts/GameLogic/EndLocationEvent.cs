using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndLocationEvent : MonoBehaviour
{
    public UnityEvent onPlayerCollision;
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли столкнувшийся объект игроком
        if (other.CompareTag("Player"))
        {
            // Если да, вызываем событие
            onPlayerCollision?.Invoke();
        }
    }
}
