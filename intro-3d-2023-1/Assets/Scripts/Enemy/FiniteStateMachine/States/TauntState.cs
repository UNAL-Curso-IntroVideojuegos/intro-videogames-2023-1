using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    public override StateType Type { get; }
    private float _tauntDuration = 0;
    
    public TauntState() : base("Taunt") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
         fms.TriggerAnimation("Taunt");
        _tauntDuration = fms.Config.TauntDuration;
        SetStateDuration(fms.Config.TauntDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
