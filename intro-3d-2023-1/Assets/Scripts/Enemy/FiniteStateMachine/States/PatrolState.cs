
public class PatrolState : State
{
    public override StateType Type => StateType.Patrol;

    public PatrolState() : base("Patrol")
    {
        //AddTransition(StateType.Chase, new FieldOfViewCheck());
    }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if(fms.NavMeshController.IsAtDestination())
            fms.NavMeshController.GoToNextWaypoint();
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
        fms.NavMeshController.StopAgent();
    }
}