using UnityEngine;

public class DeadState : State
{
    public override StateType Type => StateType.Dead;

    public DeadState() : base("Dead") { }
    public float delay;
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        //fms.TriggerAnimation("Dead");
        delay = fms.Config.DeadDelay;
        
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        
        if (delay > 0)
        {
            delay -= deltaTime;
            if (delay <= 0)
            {
                fms.gameObject.SetActive(false);
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
        
    }
}