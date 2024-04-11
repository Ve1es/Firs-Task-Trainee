using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEndEvent : MonoBehaviour
{
    public event Action EndJumpSignal;

    public void EndJump()
    {
        EndJumpSignal?.Invoke();
    }


}
