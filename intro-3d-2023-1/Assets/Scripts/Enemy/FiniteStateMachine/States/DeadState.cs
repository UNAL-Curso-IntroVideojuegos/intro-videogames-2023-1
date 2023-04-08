

public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    
    private float _deathToDie = 0;
    
    
    public DeadState() : base("Dead") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        // Cree una variable en EnemyConfig para manejar el tiempo X que se demora en pasar
        // del estado Attack a Dead
        _deathToDie = fms.Config.timeToDie;
        
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        _deathToDie -= deltaTime;
        if (_deathToDie <= 0)
        {
            fms.gameObject.SetActive(false);
        }
    }
    
    protected  override void OnExitState(FiniteStateMachine fms)
    {
        
    }
    
}