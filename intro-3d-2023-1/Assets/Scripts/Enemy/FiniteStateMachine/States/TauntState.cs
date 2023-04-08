using UnityEngine;

public class TauntState : State
{
    public TauntState() : base("Taunt")
    {
    }

    public override StateType Type { get; }
    private float _tauntDelay = 0;

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Taunt");
        _tauntDelay = fms.Config.TauntDuration;
        SetStateDuration(fms.Config.TauntDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_tauntDelay >= 0)
        {
            _tauntDelay = _tauntDelay - deltaTime;
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}