using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    
    public override StateType Type => StateType.Taunt;
    private float _stateDuration;
    public TauntState() : base("Taunt"){}
    
    protected override void OnEnterState(FiniteStateMachine fms){
        fms.TriggerAnimation("Taunt");
        _stateDuration = fms.Config.TauntDuration;
        SetStateDuration(_stateDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime){
    }

    protected override void OnExitState(FiniteStateMachine fms){
        fms.NavMeshController.StopAgent();
    }
}
