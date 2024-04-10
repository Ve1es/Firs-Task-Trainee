using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IControlStrategy controlStrategy;

    public void SetControlStrategy(IControlStrategy strategy)
    {
        controlStrategy = strategy;
    }

    public void Update()
    {
        if (controlStrategy != null)
        {
            controlStrategy.HandleInput();
        }
    }
}
