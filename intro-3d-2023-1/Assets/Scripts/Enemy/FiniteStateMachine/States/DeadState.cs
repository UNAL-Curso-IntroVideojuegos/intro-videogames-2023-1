using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    private float _attackDelay = 0;

    public DeadState() : base("Dead") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        _attackDelay = fms.Config.AttackDelay;
        
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_attackDelay > 0)
        {
            _attackDelay -= deltaTime;
            if (_attackDelay <= 0)
            {
                fms.This.gameObject.SetActive(false);
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
