
public class DeadState : State
{
    public override StateType Type => StateType.Dead;

    public float _deadDelay;

    public DeadState() : base("Dead") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
         _deadDelay = fms.Config.DeathDelay;
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_deadDelay > 0)
        {
            _deadDelay -= deltaTime;
            if (_deadDelay <= 0)
            { 
               fms.Config.die();
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}