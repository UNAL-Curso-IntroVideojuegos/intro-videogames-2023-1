using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private float _deadDelay = 0;

    public DeadState() : base("Dead") { }

    public override StateType Type { get; }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        _deadDelay = fms.Config.DeadDelay;
    }
    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_deadDelay > 0)
        {
            _deadDelay -= deltaTime;
            if (_deadDelay <= 0)
            {
                fms.gameObject.SetActive(false);
            }
        }
       
    }
    protected override void OnExitState(FiniteStateMachine fms) 
    {
    }
}
