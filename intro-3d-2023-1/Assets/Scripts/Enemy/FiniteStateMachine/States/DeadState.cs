using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{

    public override StateType Type { get; }
    public float delay;
    public DeadState() : base("Dead") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        delay = fms.Config.DeadDelay;
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (delay > 0)
        {
            delay -= deltaTime;
            if (delay <= 0)
            {
                fms.Config.killEnemy();
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}