using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    public TauntState() : base("Taunt") { }

    public override StateType Type { get; }
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Taunt");
        SetStateDuration(fms.Config.TauntDuration);
    }
    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime) { }
    protected override void OnExitState(FiniteStateMachine fms) { }
}
