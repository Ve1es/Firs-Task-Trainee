using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndLocationEvent : MonoBehaviour
{
    public UnityEvent onPlayerCollision;
    public event Action tileEndSignal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerCollision?.Invoke();
            tileEndSignal?.Invoke();
        }
    }
}
