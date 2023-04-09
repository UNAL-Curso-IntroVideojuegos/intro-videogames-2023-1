using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState() : base("Idle") { }

    public override StateType Type => StateType.Idle;

    protected override void OnEnterState(FiniteStateMachine fsm)
    {
        Debug.Log("Entering Idle state");
    }

    protected override void OnUpdateState(FiniteStateMachine fsm, float deltaTime)
    {
        // Do nothing in particular, just wait for a transition
    }

    protected override void OnExitState(FiniteStateMachine fsm)
    {
        Debug.Log("Exiting Idle state");
    }
}

