public class IdleState : State
{
    public override StateType Type => StateType.Idle;

    public IdleState() : base("Idle") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.SetMovementSpeed(0);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
