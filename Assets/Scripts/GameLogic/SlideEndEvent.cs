using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideEndEvent : MonoBehaviour
{
    public event Action EndSlideSignal;

    public void EndSlide()
    {
        EndSlideSignal?.Invoke();
    }
}
