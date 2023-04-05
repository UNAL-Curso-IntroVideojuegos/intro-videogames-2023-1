using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    
    public override StateType Type { get; }
    
    private float _tauntDelay = 0;
    public TauntState() : base("Taunt") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Taunt");
        _tauntDelay = fms.Config.TauntDuration;
        SetStateDuration(_tauntDelay);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
