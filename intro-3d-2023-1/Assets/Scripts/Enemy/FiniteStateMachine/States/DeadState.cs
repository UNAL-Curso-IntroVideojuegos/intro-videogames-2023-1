using UnityEngine;

[System.Serializable]
public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    public DeadState() : base("Dead") { }
    [SerializeField] private GameObject enemy = GameObject.Find("Enemy_Octo");

    private float deathDelay = 1f;

    protected override void OnEnterState(FiniteStateMachine fms)
    {
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (deathDelay > 0)
        {
            deathDelay -= deltaTime;
            if (deathDelay <= 0)
            {
                fms.Config.dead();
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
