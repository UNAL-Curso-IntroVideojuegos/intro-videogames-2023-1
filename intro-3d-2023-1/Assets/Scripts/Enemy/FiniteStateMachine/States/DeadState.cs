using UnityEngine;

[System.Serializable]
public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    public DeadState() : base("Dead") { }
    private GameObject octo = GameObject.Find("Enemy_Octo");

    private float deathDelay = 0;

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        deathDelay = 1;
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (deathDelay > 0)
        {
            deathDelay -= deltaTime;
            if (deathDelay <= 0)
            {
                octo.SetActive(false);
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
