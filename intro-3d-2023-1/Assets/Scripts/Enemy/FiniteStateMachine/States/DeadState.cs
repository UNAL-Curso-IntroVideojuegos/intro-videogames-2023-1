using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    
    public override StateType Type { get; }
    
    private float _deadDelay = 0;
    public DeadState() : base("Dead") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Dead");
        _deadDelay = fms.Config.DeadDelay;
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_deadDelay > 0)
        {
            _deadDelay -= deltaTime;
            if (_deadDelay <= 0)
            {
                GameObject enemy_octo = GameObject.Find("Enemy_Octo");
                enemy_octo.SetActive(false);
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}