public class TauntState : State
{
    public TauntState() : base("Taunt")
    {
    }

    public override StateType Type => StateType.Taunt;
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        SetStateDuration(fms.Config.TauntDuration);
        fms.TriggerAnimation("Taunt");
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
