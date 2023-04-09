using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    private float _tauntDuration;

    public TauntState() : base("Taunt") { }

    public override StateType Type => StateType.Taunt;

    protected override void OnEnterState(FiniteStateMachine fsm)
    {
        Debug.Log("Entering Taunt state");
        fsm._anim.SetTrigger("Taunt");
        _tauntDuration = fsm.Config.TauntDuration;
    }

    protected override void OnUpdateState(FiniteStateMachine fsm, float deltaTime)
    {
        _tauntDuration -= deltaTime;
        if (_tauntDuration <= 0)
        {
            fsm.ToState(StateType.Idle);
        }
    }

    protected override void OnExitState(FiniteStateMachine fsm)
    {
        Debug.Log("Exiting Taunt state");
    }
}