using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    // Start is called before the first frame update
    public override StateType Type => StateType.Taunt;
    private float _stateDuration;
    public TauntState() : base("Taunt"){}
    
    protected override void
    OnEnterState(FiniteStateMachine fms){
        fms.TriggerAnimation("Taunt");
        _stateDuration = fms.Config.TauntDuration;
        SetStateDuration(_stateDuration);
        Debug.Log("Taunt");
    }
    protected override void
    OnUpdateState(FiniteStateMachine fms, float deltaTime){

    }

    protected override void
    OnExitState(FiniteStateMachine fms){
        fms.NavMeshController.StopAgent();
    }
}
