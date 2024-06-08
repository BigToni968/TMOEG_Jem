using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateMachine Machine { get; protected set; }
    public State(StateMachine machine)
    {
        Machine = machine;
    }
    public abstract void OnStart();
    public abstract void OnFinish();
    public abstract void OnFixedUpdate();
    public abstract void OnUpdate();
}
