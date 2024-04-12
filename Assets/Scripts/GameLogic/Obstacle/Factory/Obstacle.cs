using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    //protected EndLocationEvent tileEndSignal;
    protected GameObject playerObject;
    public abstract void Activate();
    public abstract void Destroy();
}