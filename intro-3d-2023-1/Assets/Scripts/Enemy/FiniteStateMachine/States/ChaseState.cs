

[System.Serializable]
public class ChaseState : State
{
    public override StateType Type => StateType.Chase;

    private float _navMeshRefreshTimer = 0;

    public ChaseState() : base("Chase") { }
    
    protected  override void OnEnterState(FiniteStateMachine fms)
    {
        _navMeshRefreshTimer = 0;
        fms.SetMovementSpeed(fms.Config.ChaseSpeed);
        fms.NavMeshController.SetTarget(fms.Target);
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        _navMeshRefreshTimer -= deltaTime;
        if (_navMeshRefreshTimer <= 0)
        {
            fms.NavMeshController.GoToTarget();
            _navMeshRefreshTimer = fms.Config.NavMeshTimeToRefresh;
        }
    }

    protected  override void OnExitState(FiniteStateMachine fms)
    {
        fms.NavMeshController.StopAgent();
    }
}
