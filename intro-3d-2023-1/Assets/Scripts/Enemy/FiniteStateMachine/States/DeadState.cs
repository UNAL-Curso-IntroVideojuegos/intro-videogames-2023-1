using UnityEngine;

[System.Serializable]
public class DeadState : State
{
    public override StateType Type => StateType.Dead;


    public DeadState() : base("Dead") { }
    
    protected  override void OnEnterState(FiniteStateMachine fms)
    {
        Debug.Log("Octo Entering Dead state");
        fms.TriggerAnimation("Dead");
        SetStateDuration(fms.Config.DeadTimer);

    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
    }

    protected  override void OnExitState(FiniteStateMachine fms)
    {
        Debug.Log("Octo Leaving Dead state");
        fms.gameObject.SetActive(false);    
    }
}
