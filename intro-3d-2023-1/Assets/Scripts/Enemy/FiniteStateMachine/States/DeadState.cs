using UnityEngine;

public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    
    public DeadState() : base("Dead") { }
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.Config.gameObject.SetActive(false);
    }
    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }
    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
