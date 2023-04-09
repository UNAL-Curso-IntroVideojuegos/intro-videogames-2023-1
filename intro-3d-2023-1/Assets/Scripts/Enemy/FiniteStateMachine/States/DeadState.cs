using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override StateType Type => StateType.Dead;

    private bool _isDead = false;

    public DeadState() : base("Dead") { }

    protected override void OnEnterState(FiniteStateMachine fsm)
    {
        Debug.Log("Entering Dead state");

        if (fsm.Config.CanBeDestroyed)
        {
            GameObject.Destroy(fsm.gameObject, fsm.Config.DestroyDelay);
            
        }
        else
        {
            fsm.gameObject.SetActive(false);
        }
        _isDead = true;
    }

    protected override void OnUpdateState(FiniteStateMachine fsm, float deltaTime)
    {
        // Do nothing
    }

    protected override void OnExitState(FiniteStateMachine fsm)
    {
        Debug.Log("Exiting Dead state");
    }

    public bool IsDead()
    {
        return _isDead;
    }
}




