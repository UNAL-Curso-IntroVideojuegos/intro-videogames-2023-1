using UnityEngine;

[System.Serializable]
public class IdleState : State
{
    public override StateType Type => StateType.Idle;


    public IdleState() : base("Idle") { }
    
    protected  override void OnEnterState(FiniteStateMachine fms)
    {
        Debug.Log("Octo Entering Idlestate");
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected  override void OnExitState(FiniteStateMachine fms)
    {
        Debug.Log("Octo Leaving Idlestate");
    }
}
