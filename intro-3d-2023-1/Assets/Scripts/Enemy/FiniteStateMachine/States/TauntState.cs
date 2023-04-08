using UnityEngine;

public class TauntState : State
{
    public override StateType Type => StateType.Taunt;

    public TauntState() : base("Taunt") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Taunt");
        SetStateDuration(fms.Config.TauntDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
        //fms.NavMeshController.StopAgent();
    }
}