using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public DeadState() : base("Dead")
    {
    }

    public override StateType Type => StateType.Dead;
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.gameObject.SetActive(false);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
