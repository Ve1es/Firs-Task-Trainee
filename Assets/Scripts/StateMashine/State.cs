using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void Enter() { }
    //public abstract void HandleInput();
    //public abstract void LogicUpdate();
    //public abstract void PhysicsUpdate();
    public virtual void Update() { }
    public virtual void Exit() { }

}
