using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    
    public override StateType Type { get; }
    
    public IdleState() : base("Idle") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Idle");
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}