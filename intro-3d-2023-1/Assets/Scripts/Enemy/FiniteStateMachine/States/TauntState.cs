using UnityEngine;

[System.Serializable]
public class TauntState : State
{
    public override StateType Type => StateType.Taunt;

    private float _navMeshRefreshTimer = 0;

    public TauntState() : base("Taunt") { }
    
    protected  override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Taunt");
        _navMeshRefreshTimer = 0;
        SetStateDuration(fms._config.TauntDuration);
        fms.NavMeshController.SetTarget(fms.Target);
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        _navMeshRefreshTimer -= deltaTime;
        if (_navMeshRefreshTimer <= 0)
        {
            _navMeshRefreshTimer = fms.Config.NavMeshTimeToRefresh;
        }
        
    }

    protected  override void OnExitState(FiniteStateMachine fms)
    {
        
    }
}
