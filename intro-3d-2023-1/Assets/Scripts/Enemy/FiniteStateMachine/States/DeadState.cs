using UnityEngine;

[System.Serializable]
public class DeadState : State
{
    public override StateType Type { get; }
    public DeadState() : base("Dead") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
