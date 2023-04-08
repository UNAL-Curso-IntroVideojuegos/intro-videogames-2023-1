public class IdleState : State
{
    public override StateType Type => StateType.Idle;

    public IdleState() : base("Idle") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        //Do nothing
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        //Do nothing
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
        //Do nothing
    }
}